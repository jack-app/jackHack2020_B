using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using NCMB;

public static class NiftyUtility
{
    public static void GetAllUser(UnityAction<Dictionary<string,string>> callback = null)
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("User");
        query.WhereNotEqualTo("UserName", NiftyUser.currentUser["UserName"]);
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if(e != null)
            {
                Debug.LogError(e);
                throw e;
            }
            else
            {
                var userDic = objList.ToDictionary(x => x.ObjectId, x => x["UserName"].ToString());
                callback?.Invoke(userDic);
            }
        });
    }

    public static void StartTraining(string planID, UnityAction callback = null)
    {
        SetRandomMuscleItem(planID, callback);
    }

    public static void SetRandomMuscleItem(string planID, UnityAction callback = null)
    {
        var script = new NCMBScript("ShuffleItem.js", NCMBScript.MethodType.POST);
        Dictionary<string, object> header = new Dictionary<string, object>() { { "planid", planID } };
        script.ExecuteAsync(header, null, null, (byte[] result, NCMBException e) =>
        {
            if (e != null)
            {
                Debug.LogError(e);
                throw e;
            }
            else
            {
                Debug.Log(System.Text.Encoding.ASCII.GetString(result));
                DeletePlan(planID, callback);
            }
        });
    }

    public static void GetNewItem(UnityAction<int> callback = null)
    {
        NCMBObject user = new NCMBObject("User");
        user.ObjectId = NiftyUser.GetUserID();
        user.FetchAsync((NCMBException e) =>
        {
            if (e != null)
            {
                Debug.LogError(e);
                throw e;
            }
            else
            {
                NiftyUser.currentUser = user;
                callback?.Invoke(System.Convert.ToInt32(user["MuscleItemID"]));
            }
        });
    }

    public static void SetPlan(string planName, System.DateTime scheduleTime, List<string> teamUserList, UnityAction callback = null)
    {
        NCMBObject planObj = new NCMBObject("Plan");
        planObj.Add("planName", planName);
        planObj.Add("hostName", NiftyUser.currentUser.ObjectId);
        planObj.Add("scheduleTime", scheduleTime);
        planObj.Add("userList", teamUserList);
        planObj.Add("randKey", Random.Range(0, 99999).ToString("D5"));

        planObj.SaveAsync((NCMBException e) =>
        {
            if(e != null)
            {
                Debug.LogError(e);
                throw e;
            }
            else
            {
                SavePlan(planObj);
                callback?.Invoke();
            }
        });
    }

    public static List<NiftyPlan> GetPlan()
    {
        return NiftyPlanList.Instance.GetPlan();
    }

    public static void DeletePlan(string planID, UnityAction callback)
    {
        NCMBObject planObj = new NCMBObject("Plan");
        planObj.ObjectId = planID;
        planObj.DeleteAsync((NCMBException e) =>
        {
            if (e != null)
            {
                Debug.LogError(e);
                throw e;
            }
            else
            {
                NiftyPlanList.Instance.DeletePlan(planID);
                callback?.Invoke();
            }
        });
    }

    public static void IsValidPlanID(string inputValue, UnityAction<bool> callback = null)
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("Plan");
        query.WhereEqualTo("randKey", inputValue);
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e != null)
            {
                Debug.LogError(e);
                throw e;
            }
            if (objList.Count == 0)
            {
                callback?.Invoke(false);
                return;
            }
            var userList = (ArrayList)objList[0]["userList"];

            callback?.Invoke(userList.Contains(NiftyUser.GetUserID()));
            return;
        });
    }

    public static void SavePlan(NCMBObject planObject)
    {
        NiftyPlanList.Instance.SavePlan(planObject.ObjectId, planObject["planName"].ToString(), (System.DateTime)planObject["scheduleTime"], planObject["randKey"].ToString());
    }

}

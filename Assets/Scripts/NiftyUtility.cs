using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using NCMB;

public static class NiftyUtility
{
    public static void GetAllUser(UnityAction<List<string>> callback)
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
                var userList = objList.Select(x => x["UserName"].ToString()).ToList();
                callback(userList);
            }
        });
    }

    public static void SetPlan(string planName, System.DateTime scheduleTime, List<string> teamUserList)
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
            }
        });
    }

    public static void SavePlan(NCMBObject planObject)
    {
        NiftyPlanList.Instance.SavePlan(planObject.ObjectId, planObject["planName"].ToString(), (System.DateTime)planObject["scheduleTime"], planObject["randKey"].ToString());
    }
}

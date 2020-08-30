using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class NiftyUser : MonoBehaviour
{
    public static NCMBObject currentUser = null;

    //[SerializeField]
    //string userName = "ちょん";

    private void Start()
    {
        if(currentUser != null)
        {
            return;
        }

        string userID = PlayerPrefs.GetString("UserID", "");
        if(userID != "")
        {
            NCMBObject user = new NCMBObject("User");
            user.ObjectId = userID;
            user.FetchAsync((NCMBException e) =>
            {
                if (e != null)
                {
                    Debug.LogError(e);
                    throw e;
                }
                else
                {
                    currentUser = user;
                }
            });
            return;
        }

        //CreateUser(userName);

    }

    [ContextMenu("Delete UserData")]
    private void DeleteUserData()
    {
        PlayerPrefs.DeleteKey("UserID");
    }

    public static string GetUserID()
    {
        return currentUser.ObjectId;
    }

    public static string GetUserName()
    {
        return currentUser["UserName"].ToString();
    }

    public static int GetMuscleItemID()
    {
        return (int)currentUser["MuscleItemID"];
    }

    public static void CreateUser(string name)
    {
        NCMBObject user = new NCMBObject("User");

        user.Add("UserName", name);
        user.Add("MuscleItemID", Random.Range(0, 9));

        user.SaveAsync((NCMBException e) =>
        {
            if (e != null)
            {
                throw e;
            }
            else
            {
                currentUser = user;
                Debug.LogFormat("User {0}({1}) Sign up", user["UserName"], user.ObjectId);
                PlayerPrefs.SetString("UserID", user.ObjectId);
            }
        });
    }
}

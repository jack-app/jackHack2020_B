using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Register : MonoBehaviour
{
    public DateTime date;
    public String planName;
    public List<User> participants;

}

public class User 
{
    public String userName, userId;

    public User(String username, String userid)
    {
        userName = username;
        userId=userid;
    }
}

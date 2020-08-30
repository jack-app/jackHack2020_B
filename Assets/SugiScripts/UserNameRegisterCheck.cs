using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NCMB;

public class UserNameRegisterCheck : MonoBehaviour
{
    public Text userName;

    // Start is called before the first frame update
    void Start()
    {
        string id = PlayerPrefs.GetString("UserID");
        if (id == "")
        {
            SceneManager.LoadScene("UserNameRegister");
        }else
        {
            NCMBObject c = NiftyUser.currentUser;
            userName.text = NiftyUser.GetUserName();
        }
    }

   
}

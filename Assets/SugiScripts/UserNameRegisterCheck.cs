using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserNameRegisterCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string id = PlayerPrefs.GetString("ID");
        if (id == "")
        {
            SceneManager.LoadScene("UserNameRegister");
        }
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserNameRegister : MonoBehaviour
{
    public InputField yourName;
    


    public void OnClick()
    {
        NiftyUser.CreateUser(yourName.text);
        SceneManager.LoadScene("Main");
    }
}

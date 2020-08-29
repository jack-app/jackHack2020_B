using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterButton : MonoBehaviour
{
    public InputField inputField;
    public List<User> resisteredUsers = new List<User>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        string userName = inputField.text;
        User user = Data.friends.Find(x => x.userName == userName);
        if (user!=null&& resisteredUsers.Find(x => x.userName == userName)==null)
        {
            resisteredUsers.Add(user);
            print(user.userName);
        }
    }
}

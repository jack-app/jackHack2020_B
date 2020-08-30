using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddParticipant : MonoBehaviour
{
    public InputField inputField;
    public Dictionary<string,string> participants = new Dictionary<string, string>();
    public Text participantName;
    Dictionary<string, string> users = new Dictionary<string, string>();
    // Start is called before the first frame update
    void Start()
    {
        participants.Add(NiftyUser.GetUserID(), NiftyUser.GetUserName());
        participantName.text += NiftyUser.GetUserName() + "\n";

        NiftyUtility.GetAllUser((userDic) => { users = userDic; });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        string userId = inputField.text;
        
        
       
        if (users.ContainsKey(userId) && !participants.ContainsKey(userId))
        {
            participants.Add(userId, users[userId]);
            participantName.text += users[userId]+ "\n";
        }
        
    }

   
}

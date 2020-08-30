using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddParticipant : MonoBehaviour
{
    public InputField inputField;
    public Dictionary<string,string> participants = new Dictionary<string, string>();
    public Text participantName;
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
        string userId = inputField.text;

        if (Data.users.ContainsKey(userId) && !participants.ContainsKey(userId))
        {
            participants.Add(userId, Data.users[userId]);
            participantName.text += Data.users[userId]+ "\n";
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        User user = new User("山田太郎", "asdfgh");
        Data.friends.Add(user);
        user = new User("山田花子", "qwerty");
        Data.friends.Add(user);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

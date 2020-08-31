using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Data.users.Add("aaaaaa", "山田太郎");
        Data.users.Add("aaaaab", "山田花子");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class NiftySample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetObject()
    {
        NiftyUtility.SetPlan("jackHack2020の会議", System.DateTime.UtcNow.AddMinutes(10), new List<string> { "vd9yNsXtCYkYzo1U", "dRQNcx7DitJHGIJm" });
    }
}

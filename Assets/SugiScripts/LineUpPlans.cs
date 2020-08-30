using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LineUpPlans : MonoBehaviour
{

    public RectTransform prefab;
    Node node;

    List<string> demLlist = new List<string>() { "山菜採り","釣り","jack","丑の刻参り" };
    // Start is called before the first frame update
    void Start()
    {
        node = prefab.gameObject.GetComponent<Node>();


        foreach(string name in demLlist)
        {
            node.nodeName = name;
            node.date = DateTime.Today.ToString();
            var item = Instantiate(prefab) as RectTransform;
            item.SetParent(transform, false);
        }
        

        


       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

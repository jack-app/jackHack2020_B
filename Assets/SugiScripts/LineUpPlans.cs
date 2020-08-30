using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LineUpPlans : MonoBehaviour
{

    public RectTransform prefab;
    Node node;
    // Start is called before the first frame update
    void Start()
    {
        node = prefab.gameObject.GetComponent<Node>();


        node.nodeName = "aaaaa";
        node.date = DateTime.Today.ToString();

        var item = Instantiate(prefab) as RectTransform;
        item.SetParent(transform, false);


       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

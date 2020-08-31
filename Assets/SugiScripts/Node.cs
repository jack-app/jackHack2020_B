using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public Text Name, Date;
    public string nodeName, date;

    public Node(string _name, string _date)
    {
        nodeName = _name;
        date = _date;
    }


    private void Start()
    {
        Name.text = nodeName;
        Date.text = date;
    }
}

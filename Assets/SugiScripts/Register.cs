using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Register : MonoBehaviour
{
    public DateTime date;
    public String planName;
    public Dictionary<string,string> participants;

    public Register(string _planName,DateTime _date, Dictionary<string,string> _participants)
    {
        planName = _planName;
        date = _date;
        participants = _participants;
    }

}


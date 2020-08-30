using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class RegisterPlan : MonoBehaviour
{

    public Text planName,year,month,day,hour,minutes;
    public AddParticipant addParticipant;

    public void PlanRegister()
    {
        DateTime date = new DateTime(int.Parse(year.text), int.Parse(month.text), int.Parse(day.text), int.Parse(hour.text), int.Parse(minutes.text), 0);
        Dictionary<string, string> participants = addParticipant.participants;
        Data.registers.Add(new Register(planName.text, date, participants));
        SceneManager.LoadScene("Main");
    }
}

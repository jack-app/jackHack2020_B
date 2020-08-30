using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{


    private void Start()
    {
        List<string> keyList = new List<string>(MuscleController.muscleData.Keys);

        foreach(string key in keyList)
        {
            MuscleController.muscleData[key] = PlayerPrefs.GetInt(key);
        }
    }
    public void OnClick()
    {

        SceneManager.LoadScene("Main");
    }   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{


    private void Start()
    {
        MuscleController.MuscleLoad();
    }
    public void OnClick()
    {

        SceneManager.LoadScene("Main");
    }   
}

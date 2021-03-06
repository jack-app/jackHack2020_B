﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputMuscleID : MonoBehaviour
{

    public GameObject panel;
    public Button okButton,returnButton;
    public InputField inputField;
    public GameObject errorPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        panel.SetActive(true);
        okButton.onClick.AddListener(() =>
        {
            NiftyUtility.IsValidPlanID(inputField.text, (flag) =>
            {
                if (flag)
                {
                    SceneManager.LoadScene("Training");
                }
                else
                {
                    errorPanel.SetActive(true);
                }
            });
        });

        returnButton.onClick.AddListener(() =>
        {
            okButton.onClick.RemoveAllListeners();
            returnButton.onClick.RemoveAllListeners();
            panel.SetActive(false);
        });
    }
}

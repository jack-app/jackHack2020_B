using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CallPlan : MonoBehaviour
{

    public GameObject planPanel;
    public Text planText;
    public Text randomText;
    //public InputField textField;
    public Button startButton;
    public GameObject errorText;



    void Awake()
    {
        NiftyPlanList.Instance.startTrainingEvent = TrainingStart;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlanSetTest()
    {
        NiftyUtility.SetPlan("jackHack2020の反省会", System.DateTime.Now.AddSeconds(1), new List<string> { "vd9yNsXtCYkYzo1U", "dRQNcx7DitJHGIJm", "J2MfwrF42XT0BW4f", "LOhQmnue5EwC07jO" });
    }


    private void TrainingStart(string planID, string planName, string randomKey)
    {
        planPanel.SetActive(true);
        planText.text = string.Format("{0}\nの時間だ！！", planName);
        randomText.text = randomKey;
        if (startButton != null)
        {
            startButton.onClick.AddListener(() =>
            {


                NiftyUtility.StartTraining(planID);
                SceneManager.LoadScene("Training");

                //NiftyUtility.IsValidPlanID(textField.text, (flag) =>
                //{
                //    if (flag)
                //    {
                //        NiftyUtility.StartTraining(planID);
                //        SceneManager.LoadScene("Training");

                //    }
                //    else
                //    {
                //        errorText.SetActive(true);
                //    }
                //});
            });
        }

    }


    public void UpdateMuscleItem()
    {
        NiftyUtility.GetNewItem((x) =>
        {
            Debug.Log(x);
            planPanel.SetActive(false);
        });
    }
}

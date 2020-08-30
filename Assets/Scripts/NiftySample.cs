using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class NiftySample : MonoBehaviour
{
    public GameObject planPanel;
    public Text planText;
    public Text randomText;
    public InputField textField;
    public Button startButton;
    public GameObject okText;
    public GameObject finishText;

    // Start is called before the first frame update
    void Awake()
    {
        NiftyPlanList.Instance.startTrainingEvent = TrainingStart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetObject()
    {
        NiftyUtility.SetPlan("jackHack2020の反省会", System.DateTime.UtcNow.AddSeconds(10), new List<string> { "vd9yNsXtCYkYzo1U", "dRQNcx7DitJHGIJm", "J2MfwrF42XT0BW4f" });
        //NiftyUtility.IsValidPlanID("50331", (flag) => Debug.Log(flag));
    }

    private void TrainingStart(string planID, string planName, string randomKey)
    {
        planPanel.SetActive(true);
        planText.text = string.Format("{0}の時間だぜぇ！！", planName);
        randomText.text = string.Format("トレーニングID：{0}", randomKey);
        if(startButton != null)
        {
            startButton.onClick.AddListener(() => {
                NiftyUtility.StartTraining(planID, () => finishText.SetActive(true));
            });
        }
        
    }

    public void IsCorrectID()
    {
        NiftyUtility.IsValidPlanID(textField.text, (flag) =>
        {
            if (flag)
            {
                okText.SetActive(true);
            }
        });
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

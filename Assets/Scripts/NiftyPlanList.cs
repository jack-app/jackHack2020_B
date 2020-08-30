using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NiftyPlanList : MonoBehaviour
{
    static NiftyPlanList _instance;

    string filePath;

    PlanList niftyPlan;

    public static NiftyPlanList Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("NiftyPlanList Instance is null");
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        filePath = Application.persistentDataPath + "/" + "niftyPlan.json";
    }

    private void Start()
    {
        Load();
    }

    public void SavePlan(string planID, string planName, System.DateTime scheduleTime, string randomKey)
    {
        NiftyPlan plan = new NiftyPlan();
        plan.planID = planID;
        plan.planName = planName;
        plan.scheduleTime = scheduleTime;
        plan.randomKey = randomKey;

        niftyPlan.planList.Add(plan);

        Save();
    }

    private void Save()
    {
        string json = JsonUtility.ToJson(niftyPlan);

        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();
    }

    private void Load()
    {
        if (File.Exists(filePath))
        {
            StreamReader streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();

            niftyPlan = JsonUtility.FromJson<PlanList>(data);
        }
        else
        {
            niftyPlan = new PlanList();
            niftyPlan.planList = new List<NiftyPlan>();
        }
    }
}

[System.Serializable]
public class PlanList
{
    public List<NiftyPlan> planList;
}

[System.Serializable]
public class NiftyPlan
{
    public string planID;
    public string planName;
    public System.DateTime scheduleTime;
    public string randomKey;
}
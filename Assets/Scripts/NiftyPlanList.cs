using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using NCMB;

public class NiftyPlanList : MonoBehaviour
{
    static NiftyPlanList _instance;

    string filePath;

    public UnityAction<string, string, string> startTrainingEvent;

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
        foreach (var plan in niftyPlan.planList)
        {
            var timeDelta = System.DateTime.Parse(plan.scheduleTime) - System.DateTime.UtcNow;
            Debug.Log(timeDelta);
            StartCoroutine(PlanTimer((float)timeDelta.TotalSeconds, plan));
        }
    }

    IEnumerator PlanTimer(float time, NiftyPlan plan)
    {
        yield return new WaitForSeconds(time);

        startTrainingEvent(plan.planID, plan.planName, plan.randomKey);
    }

    public List<NiftyPlan> GetPlan()
    {
        return niftyPlan.planList;
    }

    public void SavePlan(string planID, string planName, System.DateTime scheduleTime, string randomKey)
    {
        NiftyPlan plan = new NiftyPlan();
        plan.planID = planID;
        plan.planName = planName;
        plan.planTime = scheduleTime;
        plan.scheduleTime = scheduleTime.ToString();
        plan.randomKey = randomKey;

        niftyPlan.planList.Add(plan);

        var timeDelta = scheduleTime - System.DateTime.UtcNow;
        StartCoroutine(PlanTimer((float)timeDelta.TotalSeconds, plan));

        Save();
    }

    public void DeletePlan(string planID)
    {
        var removeVal = niftyPlan.planList.SingleOrDefault(x => x.planID == planID);
        niftyPlan.planList.Remove(removeVal);
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
            niftyPlan.planList.ForEach(x => x.planTime = System.DateTime.Parse(x.scheduleTime));
        }
        else
        {
            niftyPlan = new PlanList();
            niftyPlan.planList = new List<NiftyPlan>();
        }
    }

    [ContextMenu("Delete PlanData")]
    private void DeletePlanData()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
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
    public string scheduleTime;
    public System.DateTime planTime;
    public string randomKey;
}
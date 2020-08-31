using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Training : MonoBehaviour
{

    public Animator anim;
    public AnimationClip abs,chest,foreArm,foreLeg,upperArm,upperLeg,hand,face;

    Dictionary<string, AnimationClip> clipDic;

    public MuscleItemList muscleItemList;

    public GameObject icon;
    public Text trainingName;

    int muscleIndex;

    public MuscleController muscleController;
    string trainingMuscle;

    private Dictionary<int, string> muscleDic = new Dictionary<int, string>()
    {
        {8,"face"},
        {6,"hand"},
        {4,"chest" },
        {5,"abs"},
        {1,"upperArm"},
        {0,"foreArm"},
        {3,"upperLeg"},
        {2,"foreLeg"}
    };


    void Start()
    {

        clipDic = new Dictionary<string, AnimationClip>()
        {
        {"face",face },
        {"hand",hand },
        {"chest",chest },
        {"abs",abs },
        {"upperArm",upperArm },
        {"foreArm",foreArm },
        {"upperLeg",upperLeg },
        {"foreLeg",foreLeg }
        };



        muscleIndex = NiftyUser.GetMuscleItemID();
        if (0 > muscleIndex || 9 < muscleIndex) { Debug.LogError("index is wrong"); return; }
        trainingMuscle = muscleDic[muscleIndex];
        StartyTraining(muscleIndex);

        Invoke("GoToTradeScene", 15);
    }

   
    void AddMuscle(string muscle,int effect)
    {
        MuscleController.MuscleTraining(muscle, effect);
    }

    void TrainingAnimation(string muscle)
    {
        AnimatorOverrideController overrideController;

        overrideController = new AnimatorOverrideController();
        overrideController.runtimeAnimatorController = anim.runtimeAnimatorController;

        AnimationClip clip = (AnimationClip)Instantiate(clipDic[muscle]);
        AnimationClipPair[] clipPairs = overrideController.clips;
        clipPairs[0].overrideClip = clip;
        overrideController.clips = clipPairs;


        anim.runtimeAnimatorController = overrideController;
    }


    void StartyTraining(int index)
    {
        
        MuscleItemData data = muscleItemList.Get(index);
        string trainingMuscle = muscleDic[index];
        InvokeRepeating("Growing", 0, 0.1f);

        GameObject newIcon = GameObject.Instantiate(data.prefab) ;
        newIcon.transform.SetParent(icon.transform.parent);
        newIcon.transform.localScale = icon.transform.localScale;
        newIcon.transform.position = icon.transform.position;
        Destroy(icon);

        trainingName.text = data.trainingBodyName;

        int arm = MuscleController.GetMuscle("upperArm") + MuscleController.GetMuscle("foreArm");
        int leg = MuscleController.GetMuscle("upperLeg") + MuscleController.GetMuscle("foreLeg");
        
        if (arm > 40 && leg > 40)
        {
            TrainingAnimation(trainingMuscle);
        }
        else
        {
            anim.enabled = false;
        }
        MuscleController.MuscleSave();
    }


    void GoToTradeScene()
    {
        CancelInvoke("Growing");
        SceneManager.LoadScene("TradeItem");
    }

    void Growing()
    {
        AddMuscle(trainingMuscle, 1);
        muscleController.SetMuscle();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MuscleController : MonoBehaviour
{

    public static Dictionary<string, int> muscleData = new Dictionary<string, int>() {
        {"face",0 },
        {"body",0 },
        {"hand",0 },
        {"chest",0 },
        {"abs",0 },
        {"upperArm",0 },
        {"foreArm",0 },
        {"upperLeg",0 },
        {"foreLeg",0 }

    };
    
    //public static int facePower, handPower, chestPower, absPower, upperArmPower, foreArmPower, upperLegPower, foreLegPower;
    [HideInInspector]
    public int face, hand, chest, abs, upperArm, foreArm, upperLeg, foreLeg, shrinkArm,shrinkLeg, shrinkBody;

    public SkinnedMeshRenderer skin;

    private void Start()
    {
        face =skin.sharedMesh.GetBlendShapeIndex("HideFace");
        shrinkBody = skin.sharedMesh.GetBlendShapeIndex("ShrinkBody");
        shrinkArm = skin.sharedMesh.GetBlendShapeIndex("ShrinkArm");
        hand = skin.sharedMesh.GetBlendShapeIndex("ShrinkHand");
        shrinkLeg = skin.sharedMesh.GetBlendShapeIndex("ShrinkLeg");
        chest = skin.sharedMesh.GetBlendShapeIndex("ChestMuscle");
        abs = skin.sharedMesh.GetBlendShapeIndex("AbsMuscle");
        upperArm = skin.sharedMesh.GetBlendShapeIndex("UpperArm");
        foreArm= skin.sharedMesh.GetBlendShapeIndex("ForeArm");
        upperLeg = skin.sharedMesh.GetBlendShapeIndex("UpperLeg");
        foreLeg = skin.sharedMesh.GetBlendShapeIndex("ForeLeg");


        SetMuscle();
    }


    private void Update()
    {
        SetMuscle();

        List<string> keyList = new List<string>(muscleData.Keys);
        foreach (string key in keyList)
        {
            muscleData[key] += 1;
        }
    }

    


    void SetMuscle()
    {
        skin.SetBlendShapeWeight(face, 100-muscleData["face"]);
        skin.SetBlendShapeWeight(abs, muscleData["abs"]);
        skin.SetBlendShapeWeight(chest, muscleData["chest"]);
        skin.SetBlendShapeWeight(hand, 100-muscleData["hand"]);
        skin.SetBlendShapeWeight(upperArm, muscleData["upperArm"]);
        skin.SetBlendShapeWeight(foreArm, muscleData["foreArm"]);
        skin.SetBlendShapeWeight(shrinkArm, 100 - (muscleData["upperArm"] + muscleData["foreArm"]) / 2);
        skin.SetBlendShapeWeight(upperLeg, muscleData["upperLeg"]);
        skin.SetBlendShapeWeight(foreLeg, muscleData["foreLeg"]);
        skin.SetBlendShapeWeight(shrinkLeg, 100 - (muscleData["upperLeg"] + muscleData["foreLeg"]) / 2);
        skin.SetBlendShapeWeight(shrinkBody, 100 - (muscleData["chest"] + muscleData["abs"]) / 2);


        foreach(KeyValuePair<string,int> pair in muscleData)
        {
            PlayerPrefs.SetInt(pair.Key, pair.Value);
        }


    }



    


}

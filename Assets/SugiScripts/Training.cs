using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class Training : MonoBehaviour
{

    public Animator anim;
    public AnimationClip abs,chest,foreArm,foreLeg,upperArm,upperLeg,hand,face;

    Dictionary<string, AnimationClip> clipDic;
    
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





        TrainingAnimation("foreArm");

        
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
    
}

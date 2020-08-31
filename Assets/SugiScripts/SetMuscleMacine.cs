using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMuscleMacine : MonoBehaviour
{
    public MuscleItemList muscleItemList;
    public GameObject icon;

    private void Start()
    {
        int id= NiftyUser.GetMuscleItemID();
        GameObject newIcon =Instantiate(muscleItemList.Get(id).prefab);

        newIcon.transform.SetParent(icon.transform.parent);
        newIcon.transform.localScale = icon.transform.localScale;
        newIcon.transform.position = icon.transform.position;
        Destroy(icon);
    }
}

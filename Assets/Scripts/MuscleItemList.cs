using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/MuscleItemList")]
public class MuscleItemList : ScriptableObject
{
    public List<MuscleItemData> muscleItemList = new List<MuscleItemData>();

    public MuscleItemData Get(int index)
    {
        return muscleItemList.SingleOrDefault(x => x.index == index);
    }
}

[System.Serializable]
public class MuscleItemData
{
    public string name;
    public string trainingBodyName;
    public int index;
    public GameObject prefab;
}

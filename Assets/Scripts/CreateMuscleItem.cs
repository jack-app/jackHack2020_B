using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMuscleItem : MonoBehaviour
{
    public MuscleItemList muscleItemList;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetImage", 2f);
    }

    void SetImage()
    {
        var muscleItem = muscleItemList.Get(NiftyUser.GetMuscleItemID());
        Debug.Log(muscleItem.name);
        GameObject instance = Instantiate(muscleItem.prefab, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

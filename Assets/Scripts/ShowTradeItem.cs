using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowTradeItem : MonoBehaviour
{
    public Text itemText;
    public Text trainingText;
    public Transform itemParent;
    public MuscleItemList muscleItemList;

    // Start is called before the first frame update
    void Start()
    {
        NiftyUtility.GetNewItem((x) =>
        {
            var muscleItem = muscleItemList.Get(x);
            itemText.text = muscleItem?.name;
            trainingText.text = string.Format("{0}が鍛えられる！", muscleItem?.trainingBodyName);
            Instantiate(muscleItem?.prefab, itemParent);
        });
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Main");
    }
 
}

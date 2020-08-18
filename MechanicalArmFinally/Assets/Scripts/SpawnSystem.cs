using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject boxPref;
    List<GameObject> boxList = new List<GameObject>();

    public static SpawnSystem instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    //拿取，没有就生产
    public GameObject GetBox()
    {
        GameObject boxG = null;

        if(boxList.Count > 0)
        {
            boxG = boxList[0];
            boxList.RemoveAt(0);
        }
        else
        {
            boxG = Instantiate(boxPref);
        }

        boxG.SetActive(true);
        return boxG;
    }
    //放回
    public void PutBox(GameObject _box)
    {
        _box.SetActive(false);
        boxList.Add(_box);
    }
}

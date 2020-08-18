using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScrollView : MonoBehaviour
{
    public GameObject menuItemPref;
    public Transform contentTrans;

    private void Start()
    {
        //根据场景管理器创建UI
        ScenesPart[] scenesParts = AllScenes.instance.GetAllScenesMassage();
        foreach (var item in scenesParts)
        {
            GameObject menuItem = Instantiate(menuItemPref, contentTrans);
            menuItem.GetComponent<MenuItem>().Setup(item.sceneName);
        }
    }
}

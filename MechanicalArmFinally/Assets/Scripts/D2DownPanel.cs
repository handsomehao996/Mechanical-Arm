using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D2DownPanel : MonoBehaviour
{
    public static D2DownPanel instance;

    public GameObject itemPref;
    public Transform content;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    public void CreateItem(string _name)
    {
        GameObject item = Instantiate(itemPref, content);
        item.GetComponent<D2Item>().Setup(_name);
    }
}

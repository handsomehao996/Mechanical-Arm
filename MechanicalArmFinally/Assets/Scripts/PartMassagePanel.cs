using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 显示机械臂信息的左面板
/// 触发时会去机械臂信息管理器获取信息
/// </summary>
public class PartMassagePanel : MonoBehaviour
{
    public static PartMassagePanel instance;

    public Text partNameText;
    public Image image;
    public Text introduceText;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void UpdateMassage(string _name)
    {
        PartMassage partM = PartMassageManager.instance.GetPartMassage(_name);
        partNameText.text = partM.partName;
        image.sprite = partM.sprite;
        introduceText.text = partM.introduce;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}

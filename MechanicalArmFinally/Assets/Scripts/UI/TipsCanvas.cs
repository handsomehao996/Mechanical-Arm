using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 拆装1里的提示信息头
/// 显示机械臂名字、跟踪机械臂位置、面向摄像机
/// </summary>
public class TipsCanvas : MonoBehaviour
{
    public Text tipText;

    Transform partTrans;
    Vector3 offset;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.forward);
        transform.position = partTrans.position + offset;
    }

    public void SetText(string _name, Transform _partTrans, Vector3 _offset)
    {
        tipText.text = _name;
        partTrans = _partTrans;
        offset = _offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 挂载在UI上的脚本，点击按钮的方法在这启动
/// 根据点击的按钮控制摄像机和机械臂控制器、以及返回机械臂全貌
/// </summary>
public class PartChoicePanel : MonoBehaviour
{
    public void ChangePart(string _name)
    {
        if (PartMassagePanel.instance.gameObject.activeSelf)
            return;

        ArmDisassembly.instance.ChangeDisassemBlyTarget(_name);
        Transform targetPart = ArmDisassembly.instance.GetPartTrans(_name);
        Vector3 targetOffset = targetPart.GetComponent<PartController>().cameraOffset;
        CameraController.instance.SwitchTarget(targetPart, targetOffset);
    }

    public void BackOriginal()
    {
        if (PartMassagePanel.instance.gameObject.activeSelf)
            return;

        CameraController.instance.BackOriginal();
        ArmDisassembly.instance.BackDisassemBlyTarget();
    }
}

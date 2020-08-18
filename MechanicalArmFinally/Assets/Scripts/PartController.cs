using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 此脚本负责鼠标与机械臂部件的互动、变换颜色
/// 点击部件控制摄像机和机械臂控制器
/// </summary>
public class PartController : MonoBehaviour
{
    public Vector3 cameraOffset;

    public GameObject[] ChangeColorObject;
    public Color changeColor = Color.white;
    Color[] originalColor;

    bool mouseDown;

    private void Start()
    {
        if(ChangeColorObject.Length != 0)
        {
            originalColor = new Color[ChangeColorObject.Length];
            for (int i = 0; i < ChangeColorObject.Length; i++)
            {
                originalColor[i] = ChangeColorObject[i].GetComponent<Renderer>().material.color;
            }
        }
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        for (int i = 0; i < ChangeColorObject.Length; i++)
        {
            ChangeColorObject[i].GetComponent<Renderer>().material.color = changeColor;
        }
    }

    private void OnMouseExit()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        for (int i = 0; i < ChangeColorObject.Length; i++)
        {
            ChangeColorObject[i].GetComponent<Renderer>().material.color = originalColor[i];
        }

        mouseDown = false;
    }

    private void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!mouseDown)
            return;

        //Debug.Log(gameObject.name);
        CameraController.instance.SwitchTarget(transform, cameraOffset);
        PartMassagePanel.instance.UpdateMassage(name);

        mouseDown = false;
    }

    private void OnMouseDown()
    {
        mouseDown = true;
    }
}

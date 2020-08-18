using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 控制摄像机
/// 右键旋转像机、滚轮放大缩小
/// 接近部件、返回原始位置
/// </summary>
public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Transform targetStart;
    public float aroundSpeed = 5f;

    public float scrollSpeed = 0.1f;
    public float minScroll = 1f;
    public float maxScroll = 10f;

    public float smoothSpeed = 3f;

    bool cameraMove;
    Transform target;
    Vector3 originalVec;
    Vector3 movePoint;

    bool catchOne;

    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    private void Start()
    {
        target = targetStart;
        originalVec = transform.position;
    }

    private void Update()
    {
        //右键旋转
        RotateMove();

        //放大缩小
        ScrollMove();

        //点击靠近部件
        ClickMove();
    }

    void RotateMove()
    {
        if (Input.GetButton("Fire2"))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.RotateAround(target.position, Vector3.up, mouseX * aroundSpeed);
            transform.RotateAround(target.position, transform.right, -mouseY * aroundSpeed);
        }
    }

    void ScrollMove()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Vector3.Distance(transform.position, target.position) > minScroll)
            {
                transform.Translate(transform.forward * scrollSpeed, Space.World);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Vector3.Distance(transform.position, target.position) < maxScroll)
            {
                transform.Translate(-transform.forward * scrollSpeed, Space.World);
            }
        }
    }

    void ClickMove()
    {
        if (cameraMove)
        {
            transform.position = Vector3.Lerp(transform.position, movePoint, smoothSpeed * Time.deltaTime);
            transform.LookAt(target);
            if (Vector3.Distance(transform.position, movePoint) < 0.01f || Input.GetButton("Fire2") || Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                transform.position = movePoint;
                transform.LookAt(target);
                cameraMove = false;
            }
        }
    }

    //看向目标位置，切换选择目标
    public void SwitchTarget(Transform _target, Vector3 _offset)
    {
        if (!catchOne)
        {
            originalVec = transform.position;
            catchOne = true;
        }
        target = _target;
        movePoint = target.position + _offset;
        cameraMove = true;
    }

    //返回观看整体的位置
    public void BackOriginal()
    {
        target = targetStart;
        movePoint = originalVec;
        cameraMove = true;

        PartMassagePanel.instance.Close();

        catchOne = false;
    }
}

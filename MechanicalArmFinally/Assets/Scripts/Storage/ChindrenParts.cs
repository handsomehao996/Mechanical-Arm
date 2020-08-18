using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChindrenParts
{
    //部件名字、控制位置、移动末端位置
    public string partName;
    public Transform myTrans;
    public Transform end;

    //要显示的信息头、信息头显示位置
    public GameObject[] armTip;
    public Vector3 tipOffset;
}

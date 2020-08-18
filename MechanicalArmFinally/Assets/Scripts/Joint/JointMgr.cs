using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointMgr : MonoBehaviour
{
    public Transform tip;
    public Transform target;
    public Joint[] joints;

    public float times = 50f;

    private void Update()
    {
        for(int i = 0; i < times; i++)
        {
            for(int j = 0; j < joints.Length; j++)
            {
                joints[j].UpdateJoint(tip, target);
            }
        }
    }
}

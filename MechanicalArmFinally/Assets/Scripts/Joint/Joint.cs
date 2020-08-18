using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public Vector3 axis = Vector3.right;
    public float maxAngle = 180;
    Vector3 perpendicular;

    private void Start()
    {
        perpendicular = axis.Perpendicular();
    }

    public void UpdateJoint(Transform _tip, Transform _target)
    {
        transform.rotation = Quaternion.FromToRotation(_tip.position - transform.position, _target.position - transform.position) * transform.rotation;
        transform.rotation = Quaternion.FromToRotation(transform.rotation * axis, transform.parent.rotation * axis) * transform.rotation;
        transform.rotation = Quaternion.FromToRotation(transform.rotation * perpendicular, (transform.rotation * perpendicular).ConstrainToNormal(transform.parent.rotation * perpendicular, maxAngle)) * transform.rotation;
    }
}

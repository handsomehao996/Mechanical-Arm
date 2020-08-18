using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBelt : MonoBehaviour
{
    public float moveSpeed;
    public bool useAlarm;

    public bool stop;

    Rigidbody rb;
    public int boxExitNum;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (stop)
            return;

        if (useAlarm)
        {
            if (Alarm.instance.alarm)
                return;
        }

        Vector3 pos = rb.position;
        rb.position += -transform.forward * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Box"))
        {
            if (useAlarm)
            {
                boxExitNum--;
                if (boxExitNum <= 0)
                {
                    Alarm.instance.alarm = false;
                    if (boxExitNum < 0)
                        boxExitNum = 0;
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Box"))
        {
            if (ArmCatch.instance.catchBox)
                return;

            if (useAlarm)
            {
                Alarm.instance.alarm = true;
                boxExitNum++;
            }
        }
    }
}

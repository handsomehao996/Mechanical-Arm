using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float waitTime = 1f;
    public bool stopSpawn;

    float waitTimeP;

    public static Spawn instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private void Start()
    {
        GameObject box = SpawnSystem.instance.GetBox();
        box.transform.position = transform.position;
        box.transform.SetParent(transform);
    }

    private void Update()
    {
        if (stopSpawn)
            return;

        if(Alarm.instance != null)
        {
            if (Alarm.instance.alarm)
                return;
        }

        if(waitTimeP > waitTime)
        {
            GameObject box = SpawnSystem.instance.GetBox();
            box.transform.position = transform.position;
            box.transform.SetParent(transform);
            waitTimeP = 0;
        }
        else
        {
            waitTimeP += Time.deltaTime;
        }
    }
}

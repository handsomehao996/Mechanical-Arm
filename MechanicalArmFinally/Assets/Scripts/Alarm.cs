using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public bool alarm;
    public GameObject redLight;
    public GameObject greenLight;

    bool triggerOne;

    public static Alarm instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private void Update()
    {
        if (alarm)
        {
            if (triggerOne)
            {
                redLight.SetActive(true);
                greenLight.SetActive(false);

                triggerOne = false;
            }
        }
        else
        {
            if (!triggerOne)
            {
                redLight.SetActive(false);
                greenLight.SetActive(true);

                triggerOne = true;
            }
        }
    }
}

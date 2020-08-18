using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    Animator ani;

    public static MenuCamera instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void MoveToTarget2()
    {
        ani.SetBool("Target2", true);
    }

    public void MoveToTarget1()
    {
        ani.SetBool("Target2", false);
    }
}

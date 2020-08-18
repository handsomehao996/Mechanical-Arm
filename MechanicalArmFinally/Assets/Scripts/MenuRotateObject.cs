using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRotateObject : MonoBehaviour
{
    public float speed = 50f;

    GameObject[] arms;
    int index;

    private void Start()
    {
        arms = new GameObject[transform.childCount];
        for (int i = 0; i < arms.Length; i++)
        {
            arms[i] = transform.GetChild(i).gameObject;
        }
        arms[index].SetActive(true);
    }

    private void Update()
    {
        transform.Rotate(0f, speed * Time.deltaTime, 0f);
    }

    public void Previous()
    {
        arms[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = arms.Length - 1;
        }
        arms[index].SetActive(true);
    }

    public void Next()
    {
        arms[index].SetActive(false);
        index++;
        if (index > arms.Length - 1)
        {
            index = 0;
        }
        arms[index].SetActive(true);
    }
}

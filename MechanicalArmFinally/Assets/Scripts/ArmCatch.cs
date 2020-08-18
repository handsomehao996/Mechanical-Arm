using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmCatch : MonoBehaviour
{
    public Transform targetBox;
    Transform boxParent;

    public bool catchBox;

    public static ArmCatch instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            if (catchBox)
                return;

            targetBox = other.transform;
            boxParent = targetBox.parent;
            targetBox.SetParent(transform);
            targetBox.GetComponent<Rigidbody>().isKinematic = true;

            catchBox = true;
        }
    }

    public void PutBox()
    {
        targetBox.GetComponent<Rigidbody>().isKinematic = false;
        targetBox.SetParent(boxParent);
        targetBox = null;
        StartCoroutine(Recover());
    }

    IEnumerator Recover()
    {
        yield return new WaitForSeconds(0.5f);
        catchBox = false;
    }
}

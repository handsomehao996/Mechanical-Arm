using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIsappearTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            SpawnSystem.instance.PutBox(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTrigger : MonoBehaviour
{
    public Animator ani;
    public StandardBelt standard;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            ani.SetBool("Move", true);
            standard.stop = true;
            Spawn.instance.stopSpawn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            ani.SetBool("Move", false);
            standard.stop = false;
            Spawn.instance.stopSpawn = false;
        }
    }
}

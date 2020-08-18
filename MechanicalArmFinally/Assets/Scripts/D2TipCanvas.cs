using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D2TipCanvas : MonoBehaviour
{
    public Vector3 offset;
    public Text armName;

    Transform followTrans;

    public static D2TipCanvas instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform.forward + transform.position);
        transform.position = followTrans.position + offset;
    }

    public void CreateItem()
    {
        D2DownPanel.instance.CreateItem(followTrans.name);
        followTrans.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Setup(string _name)
    {
        D2ArmPartMassage targetArm = D2ArmMassageManager.instance.GetArmMass(_name);
        armName.text = targetArm.armGaOb.name;
        followTrans = targetArm.armGaOb.transform;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D2Item : MonoBehaviour
{
    public Image image;
    public Text text;

    GameObject arm;

    public void Setup(string _name)
    {
        D2ArmPartMassage targetArm = D2ArmMassageManager.instance.GetArmMass(_name);
        image.sprite = targetArm.sprite;
        text.text = targetArm.armGaOb.name;
        arm = targetArm.armGaOb;
    }

    public void Click()
    {
        arm.SetActive(true);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D2RightPanel : MonoBehaviour
{
    public Image image;
    public Text armName;

    public static D2RightPanel instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    public void Setup(string _armName)
    {
        D2ArmPartMassage apm = D2ArmMassageManager.instance.GetArmMass(_armName);
        image.sprite = apm.sprite;
        armName.text = apm.armGaOb.name;
    }
}

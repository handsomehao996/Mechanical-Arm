using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D2ArmMassageManager : MonoBehaviour
{
    //螺丝组
    public GameObject[] screws;
    public Sprite screwSprite;

    public D2ArmPartMassage[] armPartMass;
    Dictionary<string, D2ArmPartMassage> armPartMDic = new Dictionary<string, D2ArmPartMassage>();

    public static D2ArmMassageManager instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private void Start()
    {
        foreach (var item in screws)
        {
            string name = item.name;
            D2ArmPartMassage newAPM = new D2ArmPartMassage();
            newAPM.armGaOb = item;
            newAPM.sprite = screwSprite;
            armPartMDic.Add(name, newAPM);

            item.AddComponent<D2ArmPart>();
        }

        foreach (var item in armPartMass)
        {
            string name = item.armGaOb.name;
            armPartMDic.Add(name, item);

            item.armGaOb.AddComponent<D2ArmPart>();
        }
    }

    public D2ArmPartMassage GetArmMass(string _name)
    {
        return armPartMDic[_name];
    }
}

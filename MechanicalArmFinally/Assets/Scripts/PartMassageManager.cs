using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 机械臂信息管理器
/// 根据名字返回所需要的信息
/// </summary>
public class PartMassageManager : MonoBehaviour
{
    public static PartMassageManager instance;
    public PartMassage[] partMassages;

    Dictionary<string, PartMassage> partsMas = new Dictionary<string, PartMassage>();

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < partMassages.Length; i++)
        {
            string name = partMassages[i].partName;
            partsMas.Add(name, partMassages[i]);
        }
    }

    public PartMassage GetPartMassage(string _name)
    {
        return partsMas[_name];
    }
}

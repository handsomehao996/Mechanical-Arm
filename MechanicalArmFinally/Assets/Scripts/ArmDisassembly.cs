using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 拆装1控制主体
/// 控制机械臂所有部件移动(包括子部件)、控制提示显示、播放声音
/// </summary>
public class ArmDisassembly : MonoBehaviour
{
    public float moveSpeed = 5f;
    public ChindrenParts[] chindrenParts;

    bool targetMove;
    int index;
    Transform targetTrans;
    Vector3 targetVec;
    bool allDisassem;
    bool allInstall;
    Transform[] myChildren;
    Vector3[] endChindren;
    Vector3[] startChindren;
    List<GameObject> partsGO = new List<GameObject>();
    public static ArmDisassembly instance;
    bool canDisassembly;

    public GameObject tipCanvasPref;
    public Transform tipParent;
    GameObject[] tipCanvas;

    AudioSource disassembleSource;
    AudioSource installSource;
    public AudioClip disassembleClip;
    public AudioClip installClip;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private void Start()
    {
        Setup(chindrenParts[0]);

        //存储六轴机械臂所有部件，用于部件显示和隐藏
        for (int i = 0; i < myChildren.Length; i++)
        {
            partsGO.Add(myChildren[i].gameObject);
        }

        SetupSound();
    }

    private void Update()
    {
        //根据当前目标移动部件
        PartMove();
    }

    //初始化操纵部件
    void Setup(ChindrenParts _chindrenParts)
    {
        if (myChildren != null)
        {
            index = 0;
            for (int i = 0; i < myChildren.Length; i++)
            {
                myChildren[i].position = startChindren[i];
                CloseAllTip();
            }
        }

        if (_chindrenParts.end != null)
        {
            canDisassembly = true;
            myChildren = new Transform[_chindrenParts.myTrans.childCount];
            for (int i = 0; i < myChildren.Length; i++)
            {
                myChildren[i] = _chindrenParts.myTrans.GetChild(i);
            }
            endChindren = SetupTransChindren(endChindren, _chindrenParts.end);
            startChindren = SetupTransChindren(startChindren, _chindrenParts.myTrans);

            TipSetup(_chindrenParts);
        }
        else
        {
            canDisassembly = false;
        }
    }

    void PartMove()
    {
        if (targetMove)
        {
            if (targetTrans == null)
                return;

            targetTrans.position = Vector3.MoveTowards(targetTrans.position, targetVec, moveSpeed * Time.deltaTime);
            if (targetTrans.position == targetVec)
            {
                if (allDisassem)
                {
                    if (index >= myChildren.Length)
                    {
                        allDisassem = false;
                        return;
                    }
                    DisassemControl();
                }
                else if (allInstall)
                {
                    if (index <= 0)
                    {
                        allInstall = false;
                        return;
                    }
                    InstallControl();
                }
                else
                {
                    targetMove = false;
                }
            }
        }
    }

    //拆、装、全拆、全装
    public void Disassem()
    {
        if (PartMassagePanel.instance.gameObject.activeSelf)
            return;

        if (!canDisassembly)
            return;

        if (targetMove)
            return;

        if (index >= myChildren.Length)
            return;

        //Debug.Log("Disassem");
        DisassemControl();
    }
    public void Install()
    {
        if (PartMassagePanel.instance.gameObject.activeSelf)
            return;

        if (!canDisassembly)
            return;

        if (targetMove)
            return;

        if (index <= 0)
            return;

        //Debug.Log("Install");
        InstallControl();
    }
    public void AllDisassem()
    {
        if (PartMassagePanel.instance.gameObject.activeSelf)
            return;

        if (!canDisassembly)
            return;

        if (targetMove)
            return;

        if (index >= myChildren.Length)
            return;

        allDisassem = true;
        DisassemControl();
    }
    public void AllInstall()
    {
        if (PartMassagePanel.instance.gameObject.activeSelf)
            return;

        if (!canDisassembly)
            return;

        if (targetMove)
            return;

        if (index <= 0)
            return;

        allInstall = true;
        InstallControl();
    }
    void DisassemControl()
    {
        OpenTip();

        SetTargetMove(myChildren[index], endChindren[index]);
        index++;

        disassembleSource.Play();
    }
    void InstallControl()
    {
        index--;
        SetTargetMove(myChildren[index], startChindren[index]);

        CloseTip();

        installSource.Play();
    }
    void SetTargetMove(Transform _trans, Vector3 _targetVec)
    {
        targetTrans = _trans;
        targetVec = _targetVec;
        targetMove = true;
    }
    Vector3[] SetupTransChindren(Vector3[] _chindrenVec, Transform partent)
    {
        _chindrenVec = new Vector3[partent.childCount];
        for (int i = 0; i < _chindrenVec.Length; i++)
        {
            _chindrenVec[i] = partent.GetChild(i).position;
        }
        return _chindrenVec;
    }

    //只是关闭其他部件
    public void CloseOtherPart(string _name)
    {
        for (int i = 0; i < partsGO.Count; i++)
        {
            if (!partsGO[i].name.Equals(_name))
            {
                partsGO[i].SetActive(false);
            }
            else
            {
                partsGO[i].SetActive(true);
            }
        }
    }

    //只是打开其他部件
    public void OpenOriginal()
    {
        for (int i = 0; i < partsGO.Count; i++)
        {
            partsGO[i].SetActive(true);
        }
    }

    //关闭其他部件并且切换拆装目标
    public void ChangeDisassemBlyTarget(string _name)
    {
        CloseOtherPart(_name);
        for (int i = 0; i < chindrenParts.Length; i++)
        {
            if (chindrenParts[i].partName.Equals(_name))
            {
                Setup(chindrenParts[i]);
                break;
            }
        }
    }
    //打开其他部件并且切换拆装目标
    public void BackDisassemBlyTarget()
    {
        OpenOriginal();
        Setup(chindrenParts[0]);
    }

    //拿想要的部件位置
    public Transform GetPartTrans(string _name)
    {
        Transform partTran = null;
        for (int i = 0; i < partsGO.Count; i++)
        {
            if (partsGO[i].name.Equals(_name))
            {
                partTran = partsGO[i].transform;
            }
        }
        return partTran;
    }

    //tip初始化、装载、打开、关闭、全部关闭
    void TipSetup(ChindrenParts _chindrenParts)
    {
        if(_chindrenParts.end != null)
        {
            GameObject[] newTips = new GameObject[_chindrenParts.end.childCount];

            for (int i = 0; i < newTips.Length; i++)
            {
                GameObject tipCanvas = Instantiate(tipCanvasPref, tipParent);
                tipCanvas.GetComponent<TipsCanvas>().SetText(_chindrenParts.myTrans.GetChild(i).name, _chindrenParts.myTrans.GetChild(i), _chindrenParts.tipOffset);
                tipCanvas.SetActive(false);

                newTips[i] = tipCanvas;
            }

            _chindrenParts.armTip = newTips;

            ChangeTip(_chindrenParts);
        }
    }
    void ChangeTip(ChindrenParts _chindrenParts)
    {
        tipCanvas = _chindrenParts.armTip;
    }
    void OpenTip()
    {
        tipCanvas[index].SetActive(true);
    }
    void CloseTip()
    {
        tipCanvas[index].SetActive(false);
    }
    void CloseAllTip()
    {
        for (int i = 0; i < tipCanvas.Length; i++)
        {
            tipCanvas[i].SetActive(false);
        }
    }

    //声音初始化
    void SetupSound()
    {
        disassembleSource = gameObject.AddComponent<AudioSource>();
        installSource = gameObject.AddComponent<AudioSource>();

        disassembleSource.clip = disassembleClip;
        installSource.clip = installClip;
    }
}

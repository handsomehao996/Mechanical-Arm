using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class D2ArmPart : MonoBehaviour
{
    public Color heightColor = Color.white;

    Renderer[] renderers;
    Color[] recoverColors;

    bool mouseDown;

    private void Start()
    {
        ColorSetup();
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        ColorChange();
        D2RightPanel.instance.Setup(name);
    }

    private void OnMouseExit()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        ColorOriginal();
        mouseDown = false;
    }

    private void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!mouseDown)
            return;
        ColorOriginal();
        mouseDown = false;

        D2TipCanvas.instance.gameObject.SetActive(true);
        D2TipCanvas.instance.Setup(name);
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        mouseDown = true;
    }

    void ColorSetup()
    {
        renderers = new Renderer[transform.childCount];
        recoverColors = new Color[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i] = transform.GetChild(i).GetComponent<Renderer>();
            recoverColors[i] = renderers[i].material.color;
        }
    }
    void ColorChange()
    {
        foreach (Renderer item in renderers)
        {
            item.material.color = heightColor;
        }
    }
    void ColorOriginal()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = recoverColors[i];
        }
    }
}

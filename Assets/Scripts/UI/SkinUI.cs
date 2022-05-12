using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinUI : MonoBehaviour
{
    public ElementSkin[] elementSkins;

    private void Awake()
    {
        SetData();
    }

    private void OnValidate()
    {
        if(elementSkins == null || elementSkins.Length == 0)
        {
            elementSkins = GetComponentsInChildren<ElementSkin>();
        }
    }

    public void SetData()
    {
        for (int i = 0; i < elementSkins.Length; i++)
        {
            elementSkins[i].SetData(i + 1);
        }
    }
}

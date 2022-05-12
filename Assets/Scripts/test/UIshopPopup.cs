using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIshopPopup : MonoBehaviour
{
    public test[] tests;
    private void Awake()
    {
        SetData();
    }

    private void OnValidate()
    {
        if (tests == null || tests.Length == 0)
        {
            tests = GetComponentsInChildren<test>();
        }
    }

    void SetData()
    {
        for (int i = 0; i < tests.Length; i++)
        {
            tests[i].SetData(i + 1);
        }
    }
}

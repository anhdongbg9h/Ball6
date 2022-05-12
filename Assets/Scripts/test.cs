using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public int id, cost;
    public Text costText;
    public Button purchaseBtn;


    private void Awake()
    {
        purchaseBtn.onClick.AddListener(OnPurchase);
    }

    public void UpdateView()
    {
        costText.text = cost.ToString();
    }

    private void OnPurchase()
    {
        Debug.Log("Messege Purchase");
    }


    public void SetData(int id)
    {
        this.id = id;
        cost = id * 100;
        UpdateView();
    }
}

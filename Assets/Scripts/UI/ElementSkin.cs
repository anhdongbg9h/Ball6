using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementSkin : MonoBehaviour
{
    public int id;
    public bool isClock;
    public Button clickBtn;
    public GameObject clock;
    public Image imageShow;
    public GameObject BtnOwner, BtnNotOwner;



    private GameObject prefab;
    private GameObject skin;

    private void Awake()
    {
        clickBtn.onClick.AddListener(OnClickBtn);
    }

    private void OnClickBtn()
    {
        //Debug.Log("Click into Element");
        imageShow.sprite = transform.GetChild(0).GetComponent<Image>().sprite;
        // kiểm tra xem Skin thuộc nhóm nào
        if (id >= 1 && id <= 8)
        {
            ShowBtn(id);
        }
        else if (id > 8 && id <=20)
        {
            ShowBtn(id);
        }
        else
        {
            ShowBtn(id);
        }
    }

    public void ShowBtn(int id)
    {
        // nếu Skin đã được sở hữu
        if (IsOwner(id))
        {
            Debug.Log("Da so huu");
            BtnOwner.SetActive(true);
            BtnNotOwner.SetActive(false);
        }
        // Nếu Skin chưa được sở hữu
        else
        {
            Debug.Log("Chua so huu");
            BtnOwner.SetActive(false);
            BtnNotOwner.SetActive(true);
        }
    }

    public bool IsOwner(int id) {
        var isOwner = DataPlayer.IsOwnerSkinList(id);
        return isOwner;
    }

    public void UpdateView(int id)
    {
        if (!IsOwner(id))
        {
            clock.SetActive(true);
        }
    }

    public void SetData(int id) {
        this.id = id;
        InitSkin();
        UpdateView(id);
    }

    public void InitSkin()
    {
        prefab = Resources.Load<GameObject>($"Skin/skin {id}");
        skin = Instantiate(prefab, transform);
    }
}

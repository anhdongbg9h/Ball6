using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCanvas : MonoBehaviour
{
    public static MainCanvas instance;
    //public List<Sprite> spirPlayer;
    public SkinUI skinUI;
    public Image imgPlayer;
    public GameObject canvasHome, canvasAds,
        canvasGamePlay, canvasOffer, canvasShop,
        canvasWheel, canvasGift, canvasSkin;
    public GameObject btnBack;
    public GameObject player, background;
    private GameObject obj;
    public int idex;
    public UIHome uIHome;
    public GameObject eventSystem;
    void Awake(){
        if(instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(eventSystem);
        idex = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        //imgPlayer.sprite = spirPlayer[idex];
        imgPlayer.sprite = Resources.Load<GameObject>($"Skin/skin {idex + 1}").GetComponent<Image>().sprite;
        player.GetComponent<SpriteRenderer>().sprite = imgPlayer.sprite;
    }

    public void _Next(){
        idex ++;
        if (idex == skinUI.elementSkins.Length)
        {
            idex = 0;
        }
        ChangeSpirePlayer();
    }
    public void _Prev(){
        idex --;
        if(idex < 0){
            idex = skinUI.elementSkins.Length - 1;
        }
        ChangeSpirePlayer();
    }
    public void ChangeSpirePlayer(){
        /*imgPlayer.sprite = spirPlayer[idex];
        player.GetComponent<SpriteRenderer>().sprite = imgPlayer.sprite;*/

        imgPlayer.sprite = Resources.Load<GameObject>($"Skin/skin {idex + 1}").GetComponent<Image>().sprite;
        player.GetComponent<SpriteRenderer>().sprite = imgPlayer.sprite;
    }
    public void NextRoomButton(){
        canvasHome.SetActive(false);
        canvasAds.SetActive(false);
        canvasGamePlay.SetActive(true);
        player.SetActive(true);
        background.SetActive(true);
        obj = Instantiate(Resources.Load("1/Lv" + DataPlayer.GetIdRoom()) as GameObject);
    }
    public void GoToHome(){
        Destroy(obj);
        player.SetActive(false);
        background.SetActive(false);
        canvasGamePlay.SetActive(false);
        if (DataPlayer.GetIdRoom() == 9)
        {
            obj = Instantiate(Resources.Load("RoomBoss/" + 1) as GameObject);
            player.SetActive(true);
            background.SetActive(true);
            canvasGamePlay.SetActive(false);
        }
        else
        {
            canvasHome.SetActive(true);
            canvasAds.SetActive(true);
            
        }
    }

    public void Wheel()
    {
        uIHome.audioSource.Pause();
        canvasWheel.SetActive(true);
        btnBack.SetActive(true);
    }
    public void Gift()
    {
        canvasAds.SetActive(false);
        canvasGift.SetActive(true);
        btnBack.SetActive(true);
    }
    public void Offer()
    {
        canvasOffer.SetActive(true);
        canvasAds.SetActive(false);
    }
    public void TurnOffCanvasOffer()
    {
        canvasOffer.SetActive(false);
        canvasAds.SetActive(true);
    }
    public void Shop()
    {
        canvasShop.SetActive(true);
        btnBack.SetActive(true);
    }
    public void Skin()
    {
        canvasSkin.SetActive(true);
        btnBack.SetActive(true);
        //test observer parten
        /*for(int i  = 0; i < DataManager.instance.datas.Count; i++)
        {
            if(DataManager.instance.datas[i].id == 100100)
            {
                DataManager.instance.datas[i].temp = 2;
            }
        }

        MessageManager.Instance.SendMessage(new Message(TeeMessageType.OnChangeData, new object[] { "200100" }));*/
    }
    public void AddHeartQC()
    {
        Debug.Log("Button AddHeartQC");
    }
    public void AddCoinQC()
    {
        Debug.Log("Button AddCoinQC");
    }
    public void BtnBack()
    {
        if (canvasShop.activeSelf == true)
        {
            canvasShop.SetActive(false);
            btnBack.SetActive(false);
        }
        if (canvasWheel.activeSelf == true)
        {
            uIHome.audioSource.Play();
            canvasWheel.SetActive(false);
            btnBack.SetActive(false);
        }
        if (canvasGift.activeSelf == true)
        {
            canvasAds.SetActive(true);
            canvasGift.SetActive(false);
            btnBack.SetActive(false);
        }
        if (canvasSkin.activeSelf == true)
        {
            canvasSkin.SetActive(false);
            btnBack.SetActive(false);
        }
    }
}

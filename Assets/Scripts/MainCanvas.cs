using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCanvas : MonoBehaviour
{
    public static MainCanvas instance;
    public List<Sprite> spirPlayer;
    public Image imgPlayer;
    public GameObject canvasHome, canvasAds;
    public GameObject player, background;
    private GameObject obj;
    public int idex;
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
        imgPlayer.sprite = spirPlayer[idex];
    }
    public void _Next(){
        idex ++;
        if(idex == spirPlayer.Count){
            idex = 0;
        }
        ChangeSpirePlayer();
    }
    public void _Prev(){
        Debug.Log(1);
        idex --;
        if(idex < 0){
            idex = spirPlayer.Count - 1;
        }
        ChangeSpirePlayer();
    }
    public void ChangeSpirePlayer(){
        imgPlayer.sprite = spirPlayer[idex];
        player.GetComponent<SpriteRenderer>().sprite = imgPlayer.sprite;
    }
    public void NextRoomButton(){
        canvasHome.SetActive(false);
        canvasAds.SetActive(false);
        player.SetActive(true);
        background.SetActive(true);
        obj = Instantiate(Resources.Load("1/Lv" + GameManager.instance.idRoom) as GameObject);
    }
    public void GoToHome(){
        canvasHome.SetActive(true);
        canvasAds.SetActive(true);
        player.SetActive(false);
        background.SetActive(false);
        //obj.SetActive(false);
        Destroy(obj);
    }

    public void Wheel()
    {
        Debug.Log("Button Wheel");
    }
    public void Gift()
    {
        Debug.Log("Button Gift");
    }
    public void Offer()
    {
        Debug.Log("Button Offer");
    }
    public void Shop()
    {
        Debug.Log("Button Shop");
    }
    public void Skin()
    {
        Debug.Log("Button Skin");
    }
    public void AddHeartQC()
    {
        Debug.Log("Button AddHeartQC");
    }
    public void AddCoinQC()
    {
        Debug.Log("Button AddCoinQC");
    }
}

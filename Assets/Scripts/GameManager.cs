using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public MainCanvas mainCanvas;
    [HideInInspector] public ObjectPool pool;
    [HideInInspector] public Transform bullets;
    [HideInInspector] public Transform canvasCoins;
    [HideInInspector] public Transform canvasHeart;
    public Transform canvasEnemyBanal;

    public List<GameObject> ListLV;
    public int lv;

    public int idRoom = 1;

    void Awake(){
        if(instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        //TestResouces();
    }


    //public GameObject prefabs;
    public void TestResouces(){
        Instantiate(Resources.Load("1/Lv" + lv) as GameObject);
    }
}

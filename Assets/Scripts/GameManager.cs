using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public MainCanvas mainCanvas;
    public ObjectPool pool;
    [HideInInspector] public Transform bullets;
    [HideInInspector] public Transform darts;
    [HideInInspector] public Transform canvasCoins;
    [HideInInspector] public Transform canvasHeart;
    public Transform canvasEnemyBanal;


    void Awake(){
        if(instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

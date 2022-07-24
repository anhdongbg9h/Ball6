﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : pool
{
    public List<GameObject> poolledObject;
    public List<GameObject> poolledObjectDart;
    public List<GameObject> poolledCanvasCoins;
    public List<GameObject> poolledCanvasHeart;
    public List<GameObject> poolledCanvasEnemyBanal;
    public GameObject objectToPool;
    public GameObject dartToPool;
    public GameObject canvasCoinToPool;
    public GameObject canvasHeartToPool;
    public GameObject canvasEnemyBanalToPool;
    
    

    private void Awake() {
        poolledObject = new List<GameObject>();
        poolledObjectDart = new List<GameObject>();
        poolledCanvasCoins = new List<GameObject>();
        poolledCanvasHeart = new List<GameObject>();
        poolledCanvasEnemyBanal = new List<GameObject>();
    }

    private void Start() {
        SetPool(objectToPool, GameManager.instance.bullets, poolledObject);
        SetPool(dartToPool, GameManager.instance.darts, poolledObjectDart);
        SetPool(canvasCoinToPool, GameManager.instance.canvasCoins, poolledCanvasCoins);
        SetPool(canvasHeartToPool, GameManager.instance.canvasHeart, poolledCanvasHeart);
        SetPool(canvasEnemyBanalToPool, GameManager.instance.canvasEnemyBanal, poolledCanvasEnemyBanal);
    }

    
}

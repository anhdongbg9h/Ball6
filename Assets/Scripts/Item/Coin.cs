﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    private float speed = 10;

    public Transform pos;

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if(other.CompareTag("Player"))
        {
            //MessageManager.Instance.SendMessage(new Message(TeeMessageType.OnChangeData, new object[] {"Dong", 1,   }));
            item.SetActive(false);
            showText = GameManager.instance.pool.GetPooledObject(GameManager.instance.pool.canvasCoinToPool, GameManager.instance.canvasCoins, GameManager.instance.pool.poolledCanvasCoins);
            showText.transform.position = pos.position;
            showText.SetActive(true);
            showText.GetComponent<DeleteAfterTime>().delaytime();
            StartCoroutine(DeleteGameobject());
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("MagnetPlayer"))
        {
            transform.position += (other.transform.parent.position - transform.position) * speed * Time.deltaTime; 
        }
    }
}
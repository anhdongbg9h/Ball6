using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Item
{
    public Transform pos;
    public override void OnTriggerEnter2D(Collider2D other) {
        base.OnTriggerEnter2D(other);
        if (other.CompareTag("Player"))
        {
            item.SetActive(false);
            showText = GameManager.instance.pool.GetPooledObject(GameManager.instance.pool.canvasHeartToPool,
                GameManager.instance.canvasHeart, GameManager.instance.pool.poolledCanvasHeart);
            showText.transform.position = pos.position;
            showText.SetActive(true);
            showText.GetComponent<DeleteAfterTime>().delaytime(GameManager.instance.canvasHeart);
            StartCoroutine(DeleteGameobject());
        }
    }
}

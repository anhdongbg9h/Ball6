using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetCoin : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}

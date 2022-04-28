using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Coin")){
            Debug.Log("Add 50 coin");
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Heart")){
            Debug.Log("Add 1 heart");
            Destroy(other.gameObject);
        }
    }
}

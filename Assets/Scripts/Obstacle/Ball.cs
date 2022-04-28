using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            if((transform.position.y + gameObject.GetComponent<CircleCollider2D>().radius/2) <
            (other.gameObject.transform.position.y - other.gameObject.GetComponent<CircleCollider2D>().radius /2)){ 
                other.gameObject.GetComponent<MovePlayer2D>().isAtTopBall = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<MovePlayer2D>().isAtTopBall = false;
        }
    }
}

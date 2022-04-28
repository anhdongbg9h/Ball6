using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorChildren : MonoBehaviour
{
    private Transform tempTrans;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            tempTrans = other.transform.parent;
            other.transform.parent = transform;
        }
    }
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
           other.transform.GetComponent<MovePlayer2D>().isCollisisonGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            other.transform.parent = tempTrans;
            other.transform.GetComponent<MovePlayer2D>().isCollisisonGround = false;
        }
    }
}

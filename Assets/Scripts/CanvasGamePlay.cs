using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGamePlay : MonoBehaviour
{
    public MovePlayer2D movePlayer2D;
    public void MoveRight(){
        movePlayer2D.isMove = true;
        movePlayer2D.GetComponent<Rigidbody2D>().velocity = 
        new Vector2(movePlayer2D.speed, movePlayer2D.GetComponent<Rigidbody2D>().velocity.y);
    }
    public void MoveLeft(){
        movePlayer2D.isMove = true;
        movePlayer2D.GetComponent<Rigidbody2D>().velocity = 
        new Vector2(- movePlayer2D.speed, movePlayer2D.GetComponent<Rigidbody2D>().velocity.y);
    }

    public void Jump(){
        if(movePlayer2D.isCollisisonGround){
            movePlayer2D.GetComponent<Rigidbody2D>().velocity = 
            new Vector2( movePlayer2D.GetComponent<Rigidbody2D>().velocity.x,movePlayer2D.jumpForce);
            movePlayer2D.isCollisisonGround = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SquareEnemyBanal : Enemy
{
    public float speed, angularVelocity;

    public Transform pos, pos1;
    public Vector2 movement;

    private void Start() {
        if(state == State.idle){
            // Do nothing
        }
        else{
            movement = new Vector2(-1,0);
            StartCoroutine(DelayMove());
        }
    }
    protected override void Move(){
        if(transform.position.x < pos.position.x){
            movement = -movement;
            angularVelocity = -angularVelocity;
        }
        else if(transform.position.x > pos1.position.x){
            movement = -movement;
            angularVelocity = -angularVelocity;
        }
        rb.AddForce(movement* speed);
        rb.angularVelocity = angularVelocity;
    }
    IEnumerator DelayMove(){
        yield return new WaitForSeconds(1.5f);
        Move();
        StartCoroutine(DelayMove());
    }
}

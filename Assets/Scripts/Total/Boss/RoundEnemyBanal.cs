using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEnemyBanal : Enemy
{
    public float speed;

    /*private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            rb.velocity = new Vector2( -10, rb.velocity.y);
        }      
    }*/
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            if(other.transform.position.x < transform.position.x){
                rb.velocity = new Vector2( -speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2( speed, rb.velocity.y);
            }
            
        }
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("Giam mau cua nguoi choi");
        }
    }
}

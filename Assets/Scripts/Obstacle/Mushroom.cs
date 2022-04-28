using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private float jumpForce = 50;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            if((transform.position.y + gameObject.GetComponent<CircleCollider2D>().radius/2) <
            (other.gameObject.transform.position.y - other.gameObject.GetComponent<CircleCollider2D>().radius /2)){
                other.gameObject.GetComponent<Rigidbody2D>().velocity 
                = new Vector2( other.gameObject.GetComponent<Rigidbody2D>().velocity.x, jumpForce);
                other.gameObject.GetComponent<AudioManager>().BounceVoice();
            }
        }
    }
}
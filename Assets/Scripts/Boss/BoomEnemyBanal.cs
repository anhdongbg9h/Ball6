using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEnemyBanal : Enemy
{
    private Animator anim;
    private bool isInRange;
    [HideInInspector]
    public AudioSource audioSource;
    public AudioClip boom;

    private Vector2 movement;
    
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if(state == State.idle){
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(state == State.attack){
                audioSource.Play();
                anim.SetTrigger("BoomExplode");
                isInRange = true;
                StartCoroutine(ExplodeBoom(other.gameObject));
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(state == State.attack){
                movement = new Vector2(transform.position.x,other.transform.position.x);
                rb.AddForce(-movement,ForceMode2D.Force);
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        isInRange = false;
    }

    IEnumerator ExplodeBoom(GameObject obj){
        yield return new WaitForSeconds(2f);
        if(isInRange){
            Debug.Log("Giam mang");
        }
        audioSource.PlayOneShot(boom, 1);
        Destroy(gameObject, 0.5f);
    }
}

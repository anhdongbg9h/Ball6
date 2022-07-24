using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float speed = 8;
    private MainCanvas mainCanvas;
    private void Start() {
        mainCanvas = GameManager.instance.mainCanvas;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && 
        !other.gameObject.GetComponent<MovePlayer2D>().isCollisisonGround){
            other.GetComponent<Rigidbody2D>().gravityScale = 1;
            StartCoroutine(DelayLoadScene());
            DataPlayer.SetIdRoom(1);
        } 
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            if(!other.gameObject.GetComponent<MovePlayer2D>().isCollisisonGround)
            {
                other.transform.localRotation = Quaternion.identity;
                other.transform.position += (transform.position - other.transform.position) * speed * Time.deltaTime;
                //StartCoroutine(DelayLoadScene());
            }
        }
    }
    public IEnumerator DelayLoadScene()
    {
        yield return new WaitForSeconds(1f);
        mainCanvas.GoToHome();
    }
}

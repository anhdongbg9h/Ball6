using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{
    #region Variables
    public ShapeEnemy shape;
    public State state;
    [HideInInspector]
    public bool isGold;
    [HideInInspector]
    public bool one;
    [HideInInspector]
    int count = 0;
    [HideInInspector]
    public bool atTop;
    [HideInInspector]
    public bool isOne;
    private GameObject canvas;
    public Transform posCanvas;
    public enum ShapeEnemy
    {
        circle,
        rectangle
    }
    public enum State
    {
        idle,
        attack
    }
    #endregion

    protected override void Move(){
    }
    protected override void Attack()
    {
    }
    protected override void Die()
    {
    }
    protected override void Dizzy()
    {
    }
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        if(state == State.idle){
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    protected virtual void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            if(shape == ShapeEnemy.circle){
                float sizePlayer = other.gameObject.GetComponent<CircleCollider2D>().radius/2;
                float sizeEnemy = this.transform.gameObject.GetComponent<CircleCollider2D>().radius/2;
                float tranform_y_pla = other.transform.position.y - sizePlayer;
                float tranform_y_enemy = transform.position.y + sizeEnemy;
                if(tranform_y_pla - tranform_y_enemy >= -0.1f){
                    CheckStypeEnemy(other.gameObject);
                }
            }
            else if(shape == ShapeEnemy.rectangle){
                float sizePlayer = other.gameObject.GetComponent<CircleCollider2D>().radius/2;
                float sizeEnemy = this.transform.gameObject.GetComponent<BoxCollider2D>().size.y/2;
                float tranform_y_pla = other.transform.position.y - sizePlayer;
                float tranform_y_enemy = transform.position.y + sizeEnemy;
                if(tranform_y_pla - tranform_y_enemy >= -0.1f){
                    CheckStypeEnemy(other.gameObject);
                }
            }
        }
    }
    public void CheckStypeEnemy(GameObject obj){
        atTop = true;
        if(!isOne){
            if(isGold){
                obj.GetComponent<AudioManager>().YeahVoice();
                StartCoroutine(ShowCoinForGold());
            }
            else{
                canvas = GameManager.instance.pool.GetPooledObject(GameManager.instance.pool.canvasEnemyBanalToPool
                ,GameManager.instance.canvasEnemyBanal, GameManager.instance.pool.poolledCanvasEnemyBanal);
                canvas.transform.position = posCanvas.transform.position;
                canvas.SetActive(true);
                canvas.GetComponent<DeleteAfterTime>().delaytime(); 
            } 
            isOne = true; 
            Destroy(gameObject, .5f);
        }
    }
    IEnumerator ShowCoinForGold(){
        count++;
        if(count <= 5){
            canvas = GameManager.instance.pool.GetPooledObject(GameManager.instance.pool.canvasEnemyBanalToPool
            ,GameManager.instance.canvasEnemyBanal, GameManager.instance.pool.poolledCanvasEnemyBanal);
            canvas.transform.position = posCanvas.transform.position;
            canvas.SetActive(true);
            canvas.GetComponent<DeleteAfterTime>().delaytime();
            yield return new WaitForSeconds(.2f);
            StartCoroutine(ShowCoinForGold());
        }
    }
}

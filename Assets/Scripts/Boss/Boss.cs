using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public float speed, jumpForce, hp =3;
    public StateBoss stateBoss;

    public GameObject darts;
    public List<Transform> posDart;
    public GameObject actiDizzyDart, actiDizzyStar, actiDizzyInEye;

    public Transform pos1, pos2;
    GameObject tmp;
    //bool isMove;
    bool isJump;
    int countAttack = 1;

    public enum StateBoss
    {
        Idle =0,
        Move,
        Attack,
        Dizzy,
        Die
    }
    private void Awake() {
        //isMove = false;
        isJump = false;
    }

    private void Start() {
        stateBoss = StateBoss.Idle;
        StartCoroutine(TimeIdle());
    }
    private void Update() {
        if(stateBoss == StateBoss.Move){
            Move();
            if(transform.position.x < pos1.position.x){
                transform.position = new Vector2(pos1.position.x, transform.position.y);
                Debug.Log(transform.position);
                stateBoss = StateBoss.Attack;
                countAttack = 1;
                /*if(!isMove){
                    isMove = true;
                    speed = -speed;
                }*/
            }
            else if(transform.position.x > pos2.position.x){
                transform.position = new Vector2(pos2.position.x, transform.position.y);
                stateBoss = StateBoss.Attack;
                countAttack = 1;
            }
            else{
                //isMove = false;
            }
            
        }
        else if(stateBoss == StateBoss.Attack){
            
            //Jump();
        }
    }

    private void OnEnable() {
        //Move();
    }

    protected override void Move(){
        rb.angularVelocity = speed;
    }

    protected override void Attack()
    {
        Debug.Log("Tấn công lần " + countAttack);

        /*for (i = 0; i < 5; i++)
        {
            tmp = Instantiate(darts,posDart[i].transform);
            tmp.transform.parent = posDart[i].transform;
            tmp.transform.localRotation = Quaternion.identity;
            tmp.transform.localPosition = Vector2.zero;
        }*/
    }

    void Jump(){
        transform.localRotation = Quaternion.identity;
        if(!isJump){
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }    

    void TimeAttack(){
        if(countAttack <= 2){
            Attack();
            countAttack ++;
            isJump = false;
            Jump();
            //StartCoroutine(TimeIdle());
        }
        
        //Attack();
        
    }  
    protected override void Die()
    {
        
    }
    protected override void Dizzy()
    {
        actiDizzyDart.SetActive(false);
        actiDizzyInEye.SetActive(false);
        actiDizzyStar.SetActive(true);
    }
    IEnumerator TimeDizzy(){
        Dizzy();
        yield return new WaitForSeconds(3f);
        actiDizzyDart.SetActive(true);
        actiDizzyInEye.SetActive(true);
        actiDizzyStar.SetActive(false);
        StartCoroutine(TimeIdle());
    } 

    /*protected override void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            if(isJump){
                //TimeAttack();
            }
        }
    }*/
    IEnumerator TimeIdle(){
        yield return new WaitForSeconds(3f);
        if(stateBoss == StateBoss.Idle){
            stateBoss = StateBoss.Move;
        }
        /*else if(state == StateBoss.Move){
            state = StateBoss.Attack;
        }
        else if(state == StateBoss.Attack){
            state = StateBoss.Dizzy;
        }
        else if(state == StateBoss.Dizzy){
            state = StateBoss.Move;
        }*/
        //StartCoroutine(TimeIdle());
    }
    
}

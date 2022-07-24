using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer2D : MonoBehaviour
{
    public float speed, jumpForce;
    [HideInInspector]
    public bool isCollisisonGround, isMove, isAtTopBox, isAtTopBall, isJumped, isOnBoat;
    bool isCollisisonEdge;
    public Rigidbody2D rb;


    Vector3 lastVelocity;
    [HideInInspector]
    public Vector2 movement;
    public GameObject children;
    public AudioManager audioManager;
    private void OnEnable() {
        transform.position = new Vector3(-3.51f,1.94f,0f);
        children.SetActive(false);
        transform.GetComponent<Rigidbody2D>().gravityScale = 5;
    }
    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"),0);
    }
    private void FixedUpdate() {
        //CheckGround();
        lastVelocity = rb.velocity;
        MoveCharacter(movement);
        JumpCharacter();
    }

    public void AddForceOnPlayer(Vector2 dir)
    {
        if (dir != new Vector2(0, 0))
        {
            if (isCollisisonGround)
            {
                rb.AddForce(dir * speed * 15);
            }
            else
            {
                rb.AddForce(dir * speed * 30);
            }
            isMove = true;
        }
        else
        {
            isMove = false;
        }
    }
    public void MoveCharacter(Vector2 dir)
    {
        if (movement != new Vector2(0, 0))
        {
            if (isCollisisonGround)
            {
                rb.AddForce(dir * speed * 15);
            }
            else
            {
                rb.AddForce(dir * speed * 30);
            }
            isMove = true;
        }
        else
        {
            isMove = false;
        }
    }
    public void JumpCharacter()
    {
        if (Input.GetKeyDown(KeyCode.W) && (isCollisisonGround
                                                                    || isAtTopBox
                                                                    || isAtTopBall
                                                                    || isJumped
                                                                    || isOnBoat))
        {
            Jump();
        }
    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isCollisisonGround = false;
        audioManager.Jump();
    }
    public void JumpCharacterUI() {
        if (isCollisisonGround || isAtTopBox || isAtTopBall || isJumped || isOnBoat)
        {
            Jump();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Jumped"))
        {
            isJumped = true;
        }
        if(other.gameObject.CompareTag("Enemy")){
            if (!other.gameObject.GetComponent<Enemy>().isGold)
            {
                var speed = lastVelocity.magnitude;
                var direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);
                rb.velocity = direction * Mathf.Max(speed * 1.5f, 0f);
                if (!other.gameObject.GetComponent<Enemy>().one)
                {
                    audioManager.CollisionEnemySquare(other.gameObject);
                    other.gameObject.GetComponent<Enemy>().one = true;
                }
            }
        }
        if(other.gameObject.CompareTag("Box")){
            if((transform.position.y - gameObject.GetComponent<CircleCollider2D>().radius/2) >
            (other.gameObject.transform.position.y + other.gameObject.GetComponent<BoxCollider2D>().size.y /2)){
                isAtTopBox = true;
            }
        }
        if (other.gameObject.CompareTag("Boat"))
        {
            isOnBoat = true;
            if (isMove)
            {
                audioManager.MoveBoat();
            }
        }
        if (other.gameObject.CompareTag("WoodSpike"))
        {
            Debug.Log("Giam mau cua nguoi choi");
            audioManager.HeyVoice();
        }
    }
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Box")){
            if((transform.position.y - gameObject.GetComponent<CircleCollider2D>().radius/2) >
            (other.gameObject.transform.position.y + other.gameObject.GetComponent<BoxCollider2D>().size.y /2)){
                if(isMove && isAtTopBox && isCollisisonEdge){
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(-movement * 500);
                }
            }
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            for (int i = 0; i < other.contacts.Length; i++)
            {
                if (transform.position.y - other.contacts[i].point.y > 0.4f)
                {
                    isCollisisonGround = true;
                }
                if (other.contacts[i].point.x - transform.position.x > 0.4f)
                {
                    isCollisisonEdge = true;
                }
                if (transform.position.x - other.contacts[i].point.x > 0.4f)
                {
                    isCollisisonEdge = true;
                }
            }
        }
    }
    void CheckGround()
    {
        /*isCollisisonGround = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isCollisisonGround = true;
        }*/
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            isCollisisonGround = false;
            isCollisisonEdge = false;
        }
        if (other.gameObject.CompareTag("Jumped"))
        {
            isJumped = false;
        }
        if (other.gameObject.CompareTag("Box")){
            if((transform.position.y - gameObject.GetComponent<CircleCollider2D>().radius/2) >
            (other.gameObject.transform.position.y + other.gameObject.GetComponent<BoxCollider2D>().size.y /2)){
                isAtTopBox = false;
            }
        }
        if (other.gameObject.CompareTag("Boat"))
        {
            isOnBoat = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MagnetCoin"))
        {
            audioManager.CollisionMagnetCoin();
        }
    }
}
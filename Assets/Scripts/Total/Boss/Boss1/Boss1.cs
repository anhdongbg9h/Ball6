using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    [HideInInspector]
    public int number = 1;
    public bool isMoveLeft = true;
    public Animator anim;

    public int hp;
    public bool isDizzy;

    public Slider sliderBar;

    public List<Transform> posDart;

    GameObject dart;


    private void Update()
    {
        sliderBar.value = hp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pos1"))
        {
            anim.SetTrigger("isIdle");
            number++;
            isMoveLeft = false;
        }
        if (collision.CompareTag("Pos2"))
        {
            anim.SetTrigger("isIdle");
            number++;
            isMoveLeft = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if ((collision.transform.position.y - collision.gameObject.GetComponent<CircleCollider2D>().radius / 2) >
            (transform.position.y + gameObject.GetComponent<BoxCollider2D>().size.y / 2))
            {
                if (isDizzy)
                {
                    hp--;
                }
            }
        }
    }

    public void Attack()
    {
        for (int i = 0; i < 5; i++)
        {
            dart = GameManager.instance.pool.GetPooledObject(GameManager.instance.pool.dartToPool,
                GameManager.instance.darts, GameManager.instance.pool.poolledObjectDart);
            dart.transform.parent = posDart[i].transform;
            dart.transform.localRotation = Quaternion.identity;
            dart.transform.localPosition = Vector2.zero;
            dart.transform.rotation = posDart[i].transform.rotation;
            dart.SetActive(true);
            dart.GetComponent<DeleteAfterTime>().delaytime(GameManager.instance.darts.transform);
        }
    }
}

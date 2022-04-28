using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform pos;
    private GameObject bullet;

    public float timeShoot;
    public float nextTime;

    void Update(){
        if(nextTime <= Time.time){
            nextTime = Time.time + timeShoot;
            bullet = GameManager.instance.pool.GetPooledObject(GameManager.instance.pool.objectToPool
            ,GameManager.instance.bullets, GameManager.instance.pool.poolledObject);
            bullet.transform.parent = pos;
            bullet.transform.localRotation = Quaternion.identity;
            bullet.transform.localPosition = Vector2.zero;
            bullet.gameObject.SetActive(true);
            bullet.GetComponent<DeleteAfterTime>().delaytime(); 
        }
    }
}

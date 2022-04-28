using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterTime : MonoBehaviour
{
    public float timeDelayDelete;
    public void delaytime(){
        StartCoroutine(TimeDelayDelete());
    }
    IEnumerator TimeDelayDelete(){
        yield return new WaitForSeconds(timeDelayDelete);
        //transform.parent = GameManager.instance.bullets;
        gameObject.SetActive(false);
    }
}

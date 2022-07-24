using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterTime : MonoBehaviour
{
    public float timeDelayDelete;

    
    public void delaytime(Transform parent){
        StartCoroutine(TimeDelayDelete(parent));
    }
    IEnumerator TimeDelayDelete(Transform parent){
        yield return new WaitForSeconds(timeDelayDelete);
        transform.parent = parent;
        gameObject.SetActive(false);
    }
}

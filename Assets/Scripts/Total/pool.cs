using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool : MonoBehaviour
{
    public int amountToPool;
    GameObject tmp;
    public void SetPool(GameObject origin, Transform parent, List<GameObject> list){
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(origin, parent);
            tmp.SetActive(false);
            list.Add(tmp);
        }
    }
    public GameObject GetPooledObject(GameObject origin, Transform parent, List<GameObject> list){
        /*foreach (var _object in list)
        {
            if (!_object.activeSelf)
                return _object;
        }*/
        for (int i = 0; i < amountToPool; i++)
        {
            if (!list[i].activeInHierarchy)
            {
                return list[i];
            }
        }
        tmp = Instantiate(origin, parent);
        tmp.SetActive(false);
        list.Add(tmp);
        return tmp;
    }
}

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
            tmp.gameObject.SetActive(false);
            list.Add(tmp);
        }
    }
    public GameObject GetPooledObject(GameObject origin, Transform parent, List<GameObject> list){
        foreach (var _object in list)
        {
            if (!_object.activeSelf)
                return _object;
        }
        var obj = Instantiate(origin, parent);
        list.Add(obj);
        return obj;
        /*int i = 0;
        int count = 1;
        while(i < count && count < list.Count + 1){
            if(list[i].activeSelf){
                count ++;
            }
            i ++;
        }
        if(count == list.Count + 1){
            //sinh ra 1 đối tượng mới
            SetPool(origin, parent, list);
            i++;
        }
        return list[i - 1];*/
    }
}

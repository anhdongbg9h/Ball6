using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public static test instance;
    public List<GameObject> pooledObjects;
    public GameObject objToPool;
    public int amountToPool;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
    }

    public void SetPool(GameObject poolObject, Transform parent, List<GameObject> poolObjects)
    {
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(poolObject,parent);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPoolObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
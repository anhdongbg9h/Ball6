using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public List<DataSkin> datas;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    /*private void OnEnable()
    {
        foreach(var  data in datas)
        {
            data.Register();
        }
    }

    private void OnDisable()
    {
        foreach (var data in datas)
        {
            data.UnRegister();
        }
    }

    public void */
}

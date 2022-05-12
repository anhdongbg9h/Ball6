using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*[CreateAssetMenu(fileName = "DataSkin", menuName = "Game Data")]
public class DataSkin : ScriptableObject
{
    public List<StypeSkin> stypeSkins;
}
[Serializable]
public class StypeSkin
{
    public string name;
    public List<Skin> skins;
}

[Serializable]
public class Skin
{
    public int id;
    public Sprite image;
    public bool clock;
}*/

[CreateAssetMenu(fileName = "StypeSkin", menuName = "Data Stype Skin")]
public class DataSkin : ScriptableObject, IMessageHandle
{
    public int id;
    public Sprite image;
    public bool clock;
    public int temp;

    public void Handle(Message message)
    {
        if((int)message.data[0] == id)
        {
            temp = 1;
        }
    }

    /*public void Register()
    {
        Debug.Log(MessageManager.Instance.gameObject.gameObject);
        MessageManager.Instance.AddSubcriber(TeeMessageType.OnChangeData, this);
    }

    public void UnRegister()
    {
        MessageManager.Instance.RemoveSubcriber(TeeMessageType.OnChangeData, this);
    }*/
}











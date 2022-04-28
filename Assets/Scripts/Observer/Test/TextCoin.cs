using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCoin : MonoBehaviour, IMessageHandle
{
    public Text textCoin;
    public int t = 2;
    public void Handle(Message message)
    {
        textCoin.text = "10";//
    }

    private void Start()
    {
        MessageManager.Instance.AddSubcriber(TeeMessageType.OnChangeData, this);
    }

    private void OnDestroy()
    {
        MessageManager.Instance.RemoveSubcriber(TeeMessageType.OnChangeData, this);
    }
}

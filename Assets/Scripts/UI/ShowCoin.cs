using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCoin : MonoBehaviour
{
    private void Start()
    {
        this.PostEvent(EventID.ShowCoin);
        this.PostEvent(EventID.ShowHeart);
    }

    private void OnEnable()
    {
        this.PostEvent(EventID.ShowCoin);
        this.PostEvent(EventID.ShowHeart);
    }
}

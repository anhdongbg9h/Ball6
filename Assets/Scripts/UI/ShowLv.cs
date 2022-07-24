using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class ShowLv : MonoBehaviour
{
    private void OnEnable()
    {
        this.PostEvent(EventID.ShowLv);
    }
    private void Start()
    {
        this.PostEvent(EventID.ShowLv);
    }
}

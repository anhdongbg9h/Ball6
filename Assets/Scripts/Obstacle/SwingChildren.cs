using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingChildren : MonoBehaviour
{
    public Swing swingParent;

    public void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            swingParent.OnCollisionEnter2D(other);
        }
    }
}

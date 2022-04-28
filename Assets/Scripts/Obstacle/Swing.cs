using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Swing : MonoBehaviour
{
    public Transform posButton,posSwing;

    private Vector3 posMoveButton, posMoveSwing, reMoveButton, reMoveSwing;

    public GameObject button, swing;
    
    private void Start() {
        posMoveButton = posButton.position;
        posMoveSwing = posSwing.position;
        reMoveButton = button.transform.position;
        reMoveSwing = swing.transform.position;
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            button.transform.DOMove(posMoveButton,.3f,false).SetEase(Ease.Linear);
            swing.transform.DOMove(posMoveSwing,3f,false).SetEase(Ease.Linear);
        }
    }

    public void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            button.transform.DOMove(reMoveButton,.3f,false).SetEase(Ease.Linear);
            swing.transform.DOMove(reMoveSwing,3f,false).SetEase(Ease.Linear);
        }
    }

    
}

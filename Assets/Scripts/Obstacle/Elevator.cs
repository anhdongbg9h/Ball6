using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Elevator : MonoBehaviour
{
    public Transform posDown, posTop;

    public Transform wheelObject;
    private Vector3 posOrigin, posFinal;
    public GameObject wheelMove;
    private void Start() {
        posOrigin = posDown.position;
        posFinal = posTop.position;
        wheelMove.transform.DOMove(posFinal,10f,false)
        .SetEase(Ease.Linear).
        SetLoops(-1,LoopType.Yoyo);

        
        wheelObject.DORotate(new Vector3(0,0,-360),10f,RotateMode.WorldAxisAdd)
        .SetLoops(-1,LoopType.Yoyo)
        .SetEase(Ease.Linear);
    }
}

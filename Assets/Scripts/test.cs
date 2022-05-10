using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class test : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public StateMove stateMove;
    public Direction direction;
    public MovePlayer2D movePlayer2;
    Vector2 dir;
    public enum StateMove
    {
        idle,
        left,
        right
    }
    public enum Direction
    {
        dirLeft,
        dirRight,
        jump
    }
    private void FixedUpdate()
    {
        if (stateMove == StateMove.left)
        {
            dir = new Vector2(-1, 0);
            movePlayer2.AddForceOnPlayer(dir);
        }
        else if (stateMove == StateMove.right)
        {
            dir = new Vector2(1, 0);
            movePlayer2.AddForceOnPlayer(dir);
        }
        else
        {
            dir = new Vector2(0, 0);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (direction == Direction.dirLeft)
        {
            stateMove = StateMove.left;
        }
        else if (direction == Direction.dirRight)
        {
            stateMove = StateMove.right;
        }
        else
        {
            movePlayer2.JumpCharacterUI();
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        stateMove = StateMove.idle;
    }
}

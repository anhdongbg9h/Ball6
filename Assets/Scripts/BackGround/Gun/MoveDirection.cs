using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirection : MonoBehaviour
{
    public int speed;
    public Direction dir;
    public enum Direction
    {
        left = 0, 
        right = 1,
        top = 2,
        down = 3
    }
    // Update is called once per frame
    void Update()
    {
        MoveObstacle();
    }
    public void MoveObstacle()
    {
        Vector3 temp = transform.localPosition;
        temp.y += speed * Time.deltaTime;
        transform.localPosition = temp;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllowPlayer : MonoBehaviour
{
    public Transform player;
    //public Vector3 offset;

    void Update()
    {
        if(player.position.x > -3.52f){
            // Camera follows the player
            transform.position = new Vector3 (player.position.x, player.position.y, -10);
        }
    }
}

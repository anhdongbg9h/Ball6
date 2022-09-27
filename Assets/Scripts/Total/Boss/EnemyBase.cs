using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected abstract void Move();
    protected abstract void Attack();
    protected abstract void Dizzy();
    protected abstract void Die();

}

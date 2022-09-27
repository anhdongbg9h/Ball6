using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBoss
{
    protected Boss boss;
    protected StateMachine stateMachine;

    protected StateBoss(Boss boss, StateMachine stateMachine)
    {
        this.boss = boss;
        this.stateMachine = stateMachine;
    }
    public virtual void Enter()
    {

    }
    public virtual void Exit()
    {

    }
    public virtual void HandleInput()
    {

    }

    public virtual void LogicUpdate()
    {

    }
    public virtual void PhysicsUpdate()
    {

    }
}

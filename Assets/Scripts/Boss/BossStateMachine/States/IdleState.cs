﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateBoss
{
    public IdleState(Boss boss, StateMachine stateMachine): base(boss, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

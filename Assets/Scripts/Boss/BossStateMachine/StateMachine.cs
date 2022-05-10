using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public StateBoss currentState { get; private set; }

    public void Initialize(StateBoss startedState)
    {
        currentState = startedState;
        startedState.Enter();
    }

    public void ChangeState(StateBoss newState)
    {
        currentState.Exit();
        currentState = newState;
        newState.Enter();
    }
}

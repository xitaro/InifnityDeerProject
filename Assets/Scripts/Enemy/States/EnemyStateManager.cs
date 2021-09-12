using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager
{
    //The state that will be played on the StateMachine 
    public EnemyState CurrentState { get; private set; }

    public void Initialize(EnemyState startingState)
    {
        CurrentState = startingState;
        CurrentState.OnEnter();
    }

    //Switch the current state to the state passed in the parameter
    public void ChangeState(EnemyState newState)
    {
        CurrentState.OnExit();
        CurrentState = newState;
        CurrentState.OnEnter();
    }
}

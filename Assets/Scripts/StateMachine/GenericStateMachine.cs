using StatePattern.Enemy;
using StatePattern.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericStateMachine<T> where T : EnemyController
{
    protected T Owner;
    protected IState currentState;
    protected Dictionary<States, IState> states = new Dictionary<States, IState>();

    public GenericStateMachine(T Owner)
    {
        this.Owner = Owner;
    }

    protected void SetOwner()
    {
        foreach (IState state in states.Values)
        {
            state.Owner = Owner;
        }
    }

    public void Update() => currentState?.Update();

    protected void ChangeState(IState newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState?.OnStateEnter();
    }

    public void ChangeState(States newState) => ChangeState(states[newState]);
}

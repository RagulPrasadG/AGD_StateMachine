using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolManStateMachine : IStateMachine
{
    private PatrolManController Owner;
    private IState currentState;
    protected Dictionary<EnemyStates, IState> States = new Dictionary<EnemyStates, IState>();

    public PatrolManStateMachine(PatrolManController Owner)
    {
        this.Owner = Owner;
        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        States.Add(EnemyStates.IDLE, new IdleState(this));
        States.Add(EnemyStates.ROTATING, new RotatingState(this));
        States.Add(EnemyStates.PATROLLING, new PatrolState(this));
        States.Add(EnemyStates.CHASING, new ChaseState(this));
        States.Add(EnemyStates.SHOOTING, new ShootingState(this));
    }

    private void SetOwner()
    {
        foreach (IState state in States.Values)
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

    public void ChangeState(EnemyStates state) => ChangeState(States[state]);

}

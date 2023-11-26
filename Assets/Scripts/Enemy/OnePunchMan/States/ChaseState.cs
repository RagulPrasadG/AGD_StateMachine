using StatePattern.Enemy;
using StatePattern.Main;
using StatePattern.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IState
{
    public EnemyController Owner { get; set; }
    private IStateMachine statemachine;
    private PlayerController target;

    public ChaseState(IStateMachine statemachine) => this.statemachine = statemachine;

    public void OnStateEnter()
    {
        SetTarget();
        Owner.Agent.SetDestination(target.Position);
    }

    public void OnStateExit()
    {
        
    }

    public void SetTarget() => target = GameService.Instance.PlayerService.GetPlayer();

    public void Update()
    {
        if (HasReachedPlayerThreshold())
            statemachine.ChangeState(EnemyStates.SHOOTING);
    }

    public bool HasReachedPlayerThreshold()
    {
        return (Owner.Agent.remainingDistance <= Owner.Data.PlayerStoppingDistance);
    }

}

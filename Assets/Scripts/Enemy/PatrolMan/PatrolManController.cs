using StatePattern.Enemy;
using StatePattern.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolManController : EnemyController
{
    private PatrolManStateMachine stateMachine;

    public PatrolManController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
    {
        enemyView.SetController(this);
        CreateStateMachine();
        stateMachine.ChangeState(EnemyStates.IDLE);
    }

    private void CreateStateMachine() => stateMachine = new PatrolManStateMachine(this);

    public override void UpdateEnemy()
    {
        if (currentState == EnemyState.DEACTIVE)
            return;

        stateMachine.Update();
    }

    public override void PlayerEnteredRange(PlayerController targetToSet)
    {
        base.PlayerEnteredRange(targetToSet);
        stateMachine.ChangeState(EnemyStates.CHASING);
    }

    public override void PlayerExitedRange() => stateMachine.ChangeState(EnemyStates.IDLE);
}

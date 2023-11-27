using StatePattern.Enemy;
using StatePattern.Player;
using StatePattern.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitmanController : EnemyController
{
    private HitmanStateMachine<HitmanController> stateMachine;

    public HitmanController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
    {
        enemyView.SetController(this);
        CreateStateMachine();
        stateMachine.ChangeState(States.IDLE);
    }

    private void CreateStateMachine() => stateMachine = new HitmanStateMachine<HitmanController>(this);

    public override void UpdateEnemy()
    {
        if (currentState == EnemyState.DEACTIVE)
            return;

        stateMachine.Update();
    }

    public override void Shoot()
    {
        base.Shoot();
        stateMachine.ChangeState(States.TELEPORTING);
    }

    public override void PlayerEnteredRange(PlayerController targetToSet)
    {
        base.PlayerEnteredRange(targetToSet);
        stateMachine.ChangeState(States.CHASING);
    }

    public override void PlayerExitedRange() => stateMachine.ChangeState(States.IDLE);
}

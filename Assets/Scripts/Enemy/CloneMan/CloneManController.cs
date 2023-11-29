using StatePattern.Enemy;
using StatePattern.Main;
using StatePattern.Player;
using StatePattern.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneManController : EnemyController
{
    private CloneManStateMachine stateMachine;


    public CloneManController(EnemyScriptableObject enemyScriptableObject,bool isClone = false) : base(enemyScriptableObject)
    {
        enemyView.SetController(this);
        CreateStateMachine();
        this.isClone = isClone;

        if (this.isClone)
            stateMachine.ChangeState(States.TELEPORTING);
        else
            stateMachine.ChangeState(States.IDLE);
    }

    private void CreateStateMachine() => stateMachine = new CloneManStateMachine(this);

    public override void UpdateEnemy()
    {
        if (currentState == EnemyState.DEACTIVE)
            return;

        stateMachine.Update();
    }

    public override void Die()
    {
        if (currentCloneDepth < Data.cloneDepth)
        {
            this.currentHealth = Data.MaximumHealth;
            stateMachine.ChangeState(States.CLONING);
        }
        base.Die();
    }


    public override void PlayerEnteredRange(PlayerController targetToSet)
    {
        base.PlayerEnteredRange(targetToSet);
        stateMachine.ChangeState(States.CHASING);
    }

    public override void PlayerExitedRange() => stateMachine.ChangeState(States.IDLE);
}

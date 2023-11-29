using StatePattern.Enemy;
using StatePattern.Main;
using StatePattern.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloningState<T> : IState where T : EnemyController
{
    public EnemyController Owner { get; set; }
    private GenericStateMachine<T> stateMachine;


    public CloningState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {
        CreateClone();
    }

    public void CreateClone()
    {
        if (Owner.currentCloneDepth < Owner.Data.cloneDepth)
        {
            Owner.currentCloneDepth++;
            for (int i = 0; i < Owner.Data.clonesPerDeath; i++)
            {
                GameService.Instance.EnemyService.CreateClonedEnemy(Owner.Data, Owner.currentCloneDepth);
            }
        }
    }



    public void Update() { }

    public void OnStateExit() { }


   
}

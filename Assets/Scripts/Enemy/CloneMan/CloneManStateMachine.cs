using StatePattern.Enemy;
using StatePattern.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneManStateMachine: GenericStateMachine<CloneManController>
{
    public CloneManStateMachine(CloneManController Owner) : base(Owner)
    {
        this.Owner = Owner;
        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        states.Add(States.IDLE, new IdleState<CloneManController>(this));
        states.Add(States.PATROLLING, new PatrollingState<CloneManController>(this));
        states.Add(States.TELEPORTING, new TeleportingState<CloneManController>(this));
        states.Add(States.CHASING, new ChasingState<CloneManController>(this));
        states.Add(States.SHOOTING, new ShootingState<CloneManController>(this));
        states.Add(States.CLONING, new CloningState<CloneManController>(this));

    }

}

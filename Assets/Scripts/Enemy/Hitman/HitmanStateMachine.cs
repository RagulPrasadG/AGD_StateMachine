using StatePattern.Enemy;
using StatePattern.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitmanStateMachine<T> : GenericStateMachine<HitmanController>
{
    public HitmanStateMachine(HitmanController Owner) : base(Owner)
    {
        this.Owner = Owner;
        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        states.Add(States.IDLE, new IdleState<HitmanController>(this));
        states.Add(States.PATROLLING, new PatrollingState<HitmanController>(this));
        states.Add(States.TELEPORTING, new TeleportingState<HitmanController>(this));
        states.Add(States.CHASING, new ChasingState<HitmanController>(this));
        states.Add(States.SHOOTING, new ShootingState<HitmanController>(this));
        
    }
}

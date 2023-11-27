using StatePattern.StateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class PatrolManStateMachine : GenericStateMachine<PatrolManController>
    {
        public PatrolManStateMachine(PatrolManController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            states.Add(States.IDLE, new IdleState<PatrolManController>(this));
            states.Add(States.PATROLLING, new PatrollingState<PatrolManController>(this));
            states.Add(States.CHASING, new ChasingState<PatrolManController>(this));
            states.Add(States.SHOOTING, new ShootingState<PatrolManController>(this));
        }

    }
}
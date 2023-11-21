using UnityEngine;
using StatePattern.Enemy.Bullet;
using StatePattern.Main;
using StatePattern.Player;

namespace StatePattern.Enemy
{
    public class OnePunchManController : EnemyController
    {
        private PlayerController target;
        private OnePunchManStateMachine onePunchManStateMachine;

        public OnePunchManController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
        {
            enemyView.SetController(this);
            CreateStateMachine();
            onePunchManStateMachine.ChangeState(OnePunchManStates.Idle);
        }

        private void CreateStateMachine() => this.onePunchManStateMachine = new OnePunchManStateMachine(this);

        public override void UpdateEnemy()
        {
            if (currentState == EnemyState.DEACTIVE)
                return;

            onePunchManStateMachine.Update();

        }

        public bool IsFacingPlayer(Quaternion desiredRotation) => Quaternion.Angle(Rotation, desiredRotation) < Data.RotationThreshold;

        public Quaternion CalculateRotationTowardsPlayer()
        {
            Vector3 directionToPlayer = target.Position - Position;
            directionToPlayer.y = 0f;
            return Quaternion.LookRotation(directionToPlayer, Vector3.up);
        }
        
        public Quaternion RotateTowards(Quaternion desiredRotation) => Quaternion.LerpUnclamped(Rotation, desiredRotation, enemyScriptableObject.RotationSpeed / 30 * Time.deltaTime);

        public override void PlayerEnteredRange(PlayerController targetToSet)
        {
            base.PlayerEnteredRange(targetToSet);
            this.target = targetToSet;
            onePunchManStateMachine.ChangeState(OnePunchManStates.Shooting);
        }

        public override void PlayerExitedRange() => onePunchManStateMachine.ChangeState(OnePunchManStates.Idle);

    }
}
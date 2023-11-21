
using StatePattern.Enemy;
using UnityEngine;

public class ShootingState : IState
{
    public OnePunchManController Owner { get; set; }
    private OnePunchManStateMachine stateMachine;
    private float shootTimer;

    public ShootingState(OnePunchManStateMachine stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter() => shootTimer = Owner.Data.RateOfFire;


    public void OnStateExit() => shootTimer = 0;


    public void Update()
    {
        Quaternion targetRotation = Owner.CalculateRotationTowardsPlayer();
        Owner.SetRotation(Owner.RotateTowards(targetRotation));

        if (Owner.IsFacingPlayer(targetRotation))
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                shootTimer = Owner.Data.RateOfFire;
                Owner.Shoot();
            }
        }
    }
}

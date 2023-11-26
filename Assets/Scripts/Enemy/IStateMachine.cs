using StatePattern.Enemy;

public interface IStateMachine
{
    public void ChangeState(EnemyStates state);
}

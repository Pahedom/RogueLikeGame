using UnityEngine;

public class SM_ShooterEnemy : StateMachine
{
    private enum States
    {
        SHOOTING
    }

    [SerializeField, ReadOnly] private States state;

    [SerializeField] private Gun gun;

    void Start()
    {
        state = States.SHOOTING;

        EnterState();
    }

    void Update()
    {
        UpdateState();
    }

    private void ChangeState(States newState)
    {
        ExitState();

        state = newState;

        EnterState();
    }

    private void EnterState()
    {
        if (state == States.SHOOTING)
        {
            gun.TryShoot();
        }
    }

    private void UpdateState()
    {
        if (state == States.SHOOTING)
        {
            gun.TryShoot();
        }
    }

    private void ExitState()
    {
        if (state == States.SHOOTING)
        {

        }
    }
}

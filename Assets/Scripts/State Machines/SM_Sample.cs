using UnityEngine;

public class SM_Sample : StateMachine
{
    private enum States
    {
        STATE1, STATE2, STATE3
    }

    [SerializeField, ReadOnly] private States state;

    void Start()
    {
        state = States.STATE1;

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
        if (state == States.STATE1)
        {

        }
        else if (state == States.STATE2)
        {

        }
        else if (state == States.STATE3)
        {

        }
    }

    private void UpdateState()
    {
        if (state == States.STATE1)
        {

        }
        else if (state == States.STATE2)
        {

        }
        else if (state == States.STATE3)
        {

        }
    }

    private void ExitState()
    {
        if (state == States.STATE1)
        {

        }
        else if (state == States.STATE2)
        {

        }
        else if (state == States.STATE3)
        {

        }
    }
}
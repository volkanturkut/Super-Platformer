using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State currentState;

    public void ChangeState(State newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }
}
using UnityEngine;

public class IdleState : State
{
    public IdleState(GameManager gameManager) : base(gameManager) { }

    public override void Enter()
    {
        Debug.Log("Entering Idle State");
    }

    public override void Execute()
    {

    }

    public override void Exit()
    {
        Debug.Log("Exiting Idle State");
    }
}
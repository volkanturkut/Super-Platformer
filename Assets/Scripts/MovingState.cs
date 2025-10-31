using UnityEngine;

public class MovingState : State
{
    public MovingState(GameManager gameManager) : base(gameManager) { }

    public override void Enter()
    {
        Debug.Log("Entering Moving State");
    }

    public override void Execute()
    {
 
    }

    public override void Exit()
    {
        Debug.Log("Exiting Moving State");
    }
}
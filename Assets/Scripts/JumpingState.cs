using UnityEngine;

public class JumpingState : State
{
    public JumpingState(GameManager gameManager) : base(gameManager) { }

    public override void Enter()
    {
        Debug.Log("Entering Jumping State");
    }

    public override void Execute()
    {
    }

    public override void Exit()
    {
        Debug.Log("Exiting Jumping State");
    }
}
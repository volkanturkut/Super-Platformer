using UnityEngine;

public class DeadState : State
{
    public DeadState(GameManager gameManager) : base(gameManager) { }

    public override void Enter()
    {
        Debug.Log("Entering Dead State");
    }

    public override void Execute()
    {
    }

    public override void Exit()
    {
        Debug.Log("Exiting Dead State");
    }
}
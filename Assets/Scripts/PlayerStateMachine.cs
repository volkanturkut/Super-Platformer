using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();
        ChangeState(new IdleState(gameManager));
    }

    public void Move()
    {
        ChangeState(new MovingState(gameManager));
    }

    public void Jump()
    {
        ChangeState(new JumpingState(gameManager));
    }

    public void Die()
    {
        ChangeState(new DeadState(gameManager));
    }
}
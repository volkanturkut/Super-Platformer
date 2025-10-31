using UnityEngine;

public abstract class State
{
    protected GameManager gameManager;

    public State(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}
using UnityEngine;

public abstract class BaseState
{
    protected readonly Character character;
    protected readonly StateMachine stateMachine;

    public BaseState(Character character,StateMachine stateMachine)
    {
        this.character = character;
        this.stateMachine = stateMachine;
    }

    public abstract void Enter();
    public abstract void Exit();

    public abstract void Run();

    public abstract void Revive();

    public abstract void EndRoll();

    public abstract void Collision(Collision collision);
    public abstract void TriggerEnter(Collider trigger);

    public abstract void HandleInput(InputDetector inputDetector);

}
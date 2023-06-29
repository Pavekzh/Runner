using UnityEngine;

public class RunState : BaseState
{
    public RunState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    public override void Run()
    {
        character.Move.Move();
    }

    public override void Enter()
    {
        Debug.Log("Run enter");
    }

    public override void Exit()
    {
        Debug.Log("Run exit");
    }

    public override void HandleInput(InputDetector inputDetector)
    {
        Vector2 input = inputDetector.CheckInputDirection();

        if (input.x == 1)
            character.Move.ChangeLaneRight(); 
        if (input.x == -1)
            character.Move.ChangeLaneLeft();    
        if (input.y == 1)
            stateMachine.ChangeState(character.JumpState);
        if (input.y == -1)
            stateMachine.ChangeState(character.RollState);
    }

    public override void Collision(Collision collision) { }

    public override void TriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.layer == character.Death.LowerObstacleLayer)
        {
            stateMachine.ChangeState(character.DeathState);
        }
        else if(trigger.gameObject.layer == character.Death.UpperObstacleLayer)
        {
            stateMachine.ChangeState(character.DeathState);
        }
    }
}


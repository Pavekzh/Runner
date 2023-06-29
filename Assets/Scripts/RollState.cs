using UnityEngine;

public class RollState:RunState
{
    public RollState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    public override void Enter()
    {
        character.Roll.Roll();
        character.Roll.OnRollEnd += EndRoll;
        Debug.Log("RollState enter");
    }

    public override void Exit()
    {
        character.Roll.StopRoll();
        character.Roll.OnRollEnd -= EndRoll;
        Debug.Log("RollState exit");
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
    }

    public override void TriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.layer == character.Death.LowerObstacleLayer)
        {
            stateMachine.ChangeState(character.DeathState);
        }
    }    
    
    
    private void EndRoll()
    {
        stateMachine.ChangeState(character.RunState);
    }

}


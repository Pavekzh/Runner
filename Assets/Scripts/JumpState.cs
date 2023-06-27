using System;


public class JumpState:RunState
{
    public JumpState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    public override void Enter()
    {
        throw new NotImplementedException();
    }

    public override void Exit()
    {
        throw new NotImplementedException();
    }

    public override void HandleInput(InputDetector inputDetector)
    {
        throw new NotImplementedException();
    }

    public override void LowerCollision()
    {
        throw new NotImplementedException();
    }

    public override void UpperCollision()
    {
        throw new NotImplementedException();
    }
}

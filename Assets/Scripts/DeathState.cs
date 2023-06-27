using System;

public class DeathState:BaseState
{
    public DeathState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

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

    public override void LowerCollision() { }

    public override void UpperCollision() { }
    
    public override void Run() { }

    public override void EarnItem() { }
}

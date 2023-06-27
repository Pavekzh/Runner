
public class StandState : BaseState
{
    public StandState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    public override void Enter() { }

    public override void Exit() { }

    public override void HandleInput(InputDetector inputDetector)
    {
        if (inputDetector.CheckStartInput())
            stateMachine.ChangeState(character.RunState);

    }

    public override void LowerCollision() { }

    public override void UpperCollision() { }  
    
    public override void Run() { }

    public override void EarnItem() { }

}


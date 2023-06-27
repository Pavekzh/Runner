using UnityEngine;

public class JumpState:RunState
{
    public JumpState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    public override void Enter()
    {
        character.Jump.Jump();
        Debug.Log("JumpState enter");
    }

    public override void Exit()
    {
        Debug.Log("JumpState exit");
    }

    public override void HandleInput(InputDetector inputDetector)
    {
        if (inputDetector.CheckLeftInput())
            character.Move.ChangeLaneLeft();
        if (inputDetector.CheckRightInput())
            character.Move.ChangeLaneRight();
        inputDetector.CheckUpInput();
    }

    public override void Collision(Collision collision)
    {
        if (collision.collider.gameObject.layer == character.Jump.GroundLayer)
            stateMachine.ChangeState(character.RunState);
    }

}

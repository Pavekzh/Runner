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
        Vector2 input = inputDetector.CheckInputDirection();

        if (input.x == 1)
            character.Move.ChangeLaneRight();
        if (input.x == -1)
            character.Move.ChangeLaneLeft();
    }

    public override void Collision(Collision collision)
    {
        if (collision.collider.gameObject.layer == character.Jump.GroundLayer)
            stateMachine.ChangeState(character.RunState);
    }

}

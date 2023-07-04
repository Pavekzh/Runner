using UnityEngine;

public class JumpState:RunState
{
    public JumpState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    private bool jumpStarted = false;

    public override void Enter()
    {
        character.Animations.Jump();
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
        if (jumpStarted)
        {
            LayerMask layerMask = character.Jump.GroundLayers;
            int layer = collision.collider.gameObject.layer;

            bool isColliderGround = layerMask == (layerMask | (1 << layer));

            if (isColliderGround)
            {
                stateMachine.ChangeState(character.RunState);
                jumpStarted = false;
            }
        }
    }

    public override void CollisionExit(Collision collision)
    {
        LayerMask layerMask = character.Jump.GroundLayers;
        int layer = collision.collider.gameObject.layer;

        bool isColliderGround = layerMask == (layerMask | (1 << layer));

        if (isColliderGround)
            jumpStarted = true;
    }

}

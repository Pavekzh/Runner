using UnityEngine;

public class JumpState:RunState
{
    public JumpState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    private bool jumpStarted = false;

    public override void Enter()
    {
        Debug.Log("JumpState enter");        
        Jump();
    }

    public override void Exit()
    {
        Debug.Log("JumpState exit");
    }

    public override void HandleInput(InputDetector inputDetector)
    {
        Vector2 input = inputDetector.CheckInputDirection();

        if (input.x == 1)
            ChangeLaneRight();
        if (input.x == -1)
            ChangeLaneLeft();
    }

    public override void Collision(Collision collision)
    {
        if (jumpStarted)
        {
            LayerMask layerMask = character.GroundLayers;
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
        LayerMask layerMask = character.GroundLayers;
        int layer = collision.collider.gameObject.layer;

        bool isColliderGround = layerMask == (layerMask | (1 << layer));

        if (isColliderGround)
            jumpStarted = true;
    }

    protected void Jump()
    {
        character.Animator.SetTrigger(character.JumpTrigger);
        character.Rigidbody.AddForce(Vector3.up * character.JumpPower, ForceMode.VelocityChange);
    }

}

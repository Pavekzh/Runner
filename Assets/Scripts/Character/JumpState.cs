using System;
using UnityEngine;

public class JumpState:RunState
{
    public JumpState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    private bool jumpStarted = false;
    private bool downInput = false;

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
        if (input.y == -1)
            SpeededFall();
      
    }

    private void SpeededFall()
    {
        Debug.Log("Fall");
        downInput = true;
        character.Rigidbody.velocity = Vector3.zero;
        character.Rigidbody.AddForce(Vector3.down * character.SpeededFallPower, ForceMode.VelocityChange);
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
                if (downInput)
                    stateMachine.ChangeState(character.RollState);
                else
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
        downInput = false;
        character.Animator.SetTrigger(character.JumpTrigger);
        character.Rigidbody.AddForce(Vector3.up * character.JumpPower, ForceMode.VelocityChange);
    }

}

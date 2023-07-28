using System;
using UnityEngine;

public class JumpState:RunState
{
    public JumpState(CharacterModel character, StateMachine stateMachine) : base(character, stateMachine) { }

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
        character.Rigidbody.AddForce(Vector3.down * character.jumpSettings.SpeededFallPower, ForceMode.VelocityChange);
    }

    public override void Collision(Collision collision)
    {
        if (jumpStarted)
        {

            if (collision.collider.tag == character.jumpSettings.GroundTag)
            {
                if (downInput)
                    stateMachine.ChangeState<RollState>();
                else
                    stateMachine.ChangeState<RunState>();

                jumpStarted = false;
            }
        }
    }

    public override void CollisionExit(Collision collision)
    {  
        if (collision.collider.tag == character.jumpSettings.GroundTag)
            jumpStarted = true;
    }

    protected void Jump()
    {
        downInput = false;
        character.Animator.SetTrigger(character.animationSettings.JumpTrigger);
        character.Rigidbody.AddForce(Vector3.up * character.jumpSettings.JumpPower, ForceMode.VelocityChange);
    }

}

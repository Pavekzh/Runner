using System;
using UnityEngine;

public class InvulnerableState:RunState
{
    public InvulnerableState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    public override void Enter()
    {
        character.Invulnerability.OnInvulnerabilityEnd += InvulnerabilityEnd;
        character.Invulnerability.EnableInvulnerability();
        Debug.Log("Invulnerable enter");
    }

    public override void Exit()
    {
        character.Invulnerability.OnInvulnerabilityEnd -= InvulnerabilityEnd;
        character.Invulnerability.DisableInvulnerability();
        Debug.Log("Invulnerable exit");
    }

    public override void TriggerEnter(Collider trigger) 
    {
        AddItem(trigger);
    }

    public override void Collision(Collision collision) { }

    public override void HandleInput(InputDetector inputDetector)
    {
        Vector2 input = inputDetector.CheckInputDirection();

        if (input.x == 1)
        {
            stateMachine.ChangeState(character.RunState);
            character.Move.ChangeLaneRight();
        }
        if (input.x == -1)
        {
            stateMachine.ChangeState(character.RunState);
            character.Move.ChangeLaneLeft();
        }
        if (input.y == 1)
            stateMachine.ChangeState(character.JumpState);
        if (input.y == -1)
            stateMachine.ChangeState(character.RollState);
    }

    private void InvulnerabilityEnd()
    {
        stateMachine.ChangeState(character.RunState);
    }
    
}


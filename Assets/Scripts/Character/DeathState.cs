using System;
using UnityEngine;

public class DeathState:BaseState
{
    public DeathState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    public override void Enter()
    {
        character.Animations.Die();
        Debug.Log("Death enter");
        character.Death.Die();
        character.UISwitcher.OpenGameOver(character.ScoreCounter.Score, character.Items.Coins, character.Death.CanBeRevived,Revive);
        character.Move.StopLaneChanging();
    }

    public override void Exit()
    {
        Debug.Log("Death exit");
    }

    public override void HandleInput(InputDetector inputDetector) { }
    
    public override void Run() { }

    public override void TriggerEnter(Collider trigger) { }   
    
    public override void Collision(Collision collision) { }   
    
    
    private void Revive()
    {
        character.Animations.Revive();
        stateMachine.ChangeState(character.InvulnerableState);        
        character.Move.InstantGetInLane();
        character.UISwitcher.OpenInRunUI();
    }

    public override void CollisionExit(Collision collision) { }
}

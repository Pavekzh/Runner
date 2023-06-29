using System;
using UnityEngine;

public class DeathState:BaseState
{
    public DeathState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Death enter");
        character.Death.OnRevived += Revive;
        character.Death.Die((int)character.DistanceCounter.Distance, character.Items.Coins);
        character.Move.StopLaneChanging();
    }

    public override void Exit()
    {
        character.Death.OnRevived -= Revive;
        Debug.Log("Death exit");
    }

    public override void HandleInput(InputDetector inputDetector) { }
    
    public override void Run() { }

    public override void TriggerEnter(Collider trigger) { }   
    
    public override void Collision(Collision collision) { }   
    
    
    private void Revive()
    {        
        stateMachine.ChangeState(character.InvulnerableState);        
        character.Move.InstantGetInLane();
    }
}

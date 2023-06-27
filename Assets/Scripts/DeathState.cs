using System;
using UnityEngine;

public class DeathState:BaseState
{
    public DeathState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Death enter");
    }

    public override void Exit()
    {
        Debug.Log("Death exit");
    }

    public override void HandleInput(InputDetector inputDetector) { }
    
    public override void Run() { }

    public override void Revive()
    {
        throw new NotImplementedException();
    }

    public override void TriggerEnter(Collider trigger) { }   
    
    public override void Collision(Collision collision) { }


}

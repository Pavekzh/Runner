﻿using UnityEngine;

public class StandState : BaseState
{
    public StandState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    public override void Enter() 
    {
        Debug.Log("Stand enter");
    }

    public override void Exit() 
    {
        Debug.Log("Stand exit");
        character.UISwitcher.OpenInRunUI();
    }

    public override void HandleInput(InputDetector inputDetector)
    {
        if (inputDetector.CheckAnyInput())
            stateMachine.ChangeState(character.RunState);
    }
    
    public override void Run() { }

    public override void TriggerEnter(Collider trigger) { }    
    
    public override void Collision(Collision collision) { }
}


﻿using System;
using UnityEngine;

public class JumpState:RunState
{
    public JumpState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    public override void Enter()
    {
        Debug.Log("JumpState enter");
    }

    public override void Exit()
    {
        Debug.Log("JumpState exit");
    }

    public override void HandleInput(InputDetector inputDetector)
    {
        throw new NotImplementedException();
    }

    public override void TriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.layer == character.Death.UpperObstacleLayer)
        {
            stateMachine.ChangeState(character.DeathState);
        }
    }
}

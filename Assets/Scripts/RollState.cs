using System;
using UnityEngine;

public class RollState:RunState
{
    public RollState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    public override void Enter()
    {
         Debug.Log("RollState enter");
    }

    public override void Exit()
    {
        Debug.Log("RollState exit");
    }

    public override void HandleInput(InputDetector inputDetector)
    {
        throw new NotImplementedException();
    }

    public override void TriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.layer == character.Death.LowerObstacleLayer)
        {
            stateMachine.ChangeState(character.DeathState);
        }
    }
}


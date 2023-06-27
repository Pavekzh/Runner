using System;
using UnityEngine;

public class RunState : BaseState
{
    public RunState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    public override void Run()
    {
        float speed =  character.Move.Speed + character.Move.Acceleration * Time.deltaTime;
        character.Move.Move(speed, character.Move.Direction);
    }

    public override void Enter()
    {
        Debug.Log("Run enter");
    }

    public override void Exit()
    {
        Debug.Log("Run exit");
    }

    public override void HandleInput(InputDetector inputDetector)
    {
        throw new NotImplementedException();
    }

    public override void Collision(Collision collision) { }

    public override void TriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.layer == character.Death.LowerObstacleLayer)
        {
            stateMachine.ChangeState(character.DeathState);
        }
        else if(trigger.gameObject.layer == character.Death.UpperObstacleLayer)
        {
            stateMachine.ChangeState(character.DeathState);
        }
    }

    public override void Revive() { }
}


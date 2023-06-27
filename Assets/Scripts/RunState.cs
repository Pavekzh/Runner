using System;
using UnityEngine;

public class RunState : BaseState
{
    public RunState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    public override void Run()
    {
        float speed = character.Speed + character.Acceleration * Time.deltaTime;
        character.Move(speed, character.Direction);
    }

    public override void EarnItem()
    {
        throw new NotImplementedException();
    }

    public override void Enter()
    {
        Debug.Log("Run enter");
    }

    public override void Exit()
    {
        throw new NotImplementedException();
    }

    public override void HandleInput(InputDetector inputDetector)
    {
        Debug.Log("HandleInput - RunState");       
    }

    public override void LowerCollision()
    {
        throw new NotImplementedException();
    }

    public override void UpperCollision()
    {
        throw new NotImplementedException();
    }
}


﻿using System.Collections;
using System;
using UnityEngine;

public class RollState:RunState
{
    public RollState(CharacterModel character, StateMachine stateMachine) : base(character, stateMachine) { }

    private Coroutine rollCoroutine;

    public override void Enter()
    {
        Debug.Log("RollState enter");        
        Roll();
    }

    public override void Exit()
    {
        StopRoll();
        Debug.Log("RollState exit");
    }

    public override void HandleInput(InputDetector inputDetector)
    {
        Vector2 input = inputDetector.CheckInputDirection();

        if (input.x == 1)
            ChangeLaneRight();
        if (input.x == -1)
            ChangeLaneLeft();
        if (input.y == 1)
            stateMachine.ChangeState<JumpState>();
    }

    public override void TriggerEnter(Collider trigger)
    {
        if (AddItem(trigger))
            return;
        else if (trigger.gameObject.tag == character.deathSettings.LowerObstacleTag)
            Death();
    }    

    protected void Roll()
    {
        character.Animator.SetTrigger(character.animationSettings.RollTrigger);
        rollCoroutine = character.StartCoroutine(RollTimer());
    }    
    
    protected void StopRoll()
    {
        if(rollCoroutine != null)
        {
            character.StopCoroutine(rollCoroutine);
            rollCoroutine = null;
        }
    }    
    
    private void EndRoll()
    {
        stateMachine.ChangeState<RunState>();
    }

    private IEnumerator RollTimer()
    {
        yield return new WaitForSeconds(character.rollSettings.RollTime);

        rollCoroutine = null;
        EndRoll();
    }
}


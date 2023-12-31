﻿using System;
using UnityEngine;

public class DeathState:BaseState
{
    public DeathState(CharacterModel character, StateMachine stateMachine) : base(character, stateMachine) { }

    protected bool canBeRevived
    {
        get => deathCount <= character.deathSettings.TimesCanBeRevived;
    }

    protected int deathCount { get; private set; } = 0;


    public override void Enter()
    {
        Debug.Log("Death enter");
        Die();
    }

    public override void Exit()
    {
        Debug.Log("Death exit");

    }

    public override void HandleInput(InputDetector inputDetector) { }
    
    public override void Run() { }

    public override void TriggerEnter(Collider trigger) { }   
    
    public override void Collision(Collision collision) { }   
    
    public override void CollisionExit(Collision collision) { }

    private void Revive()
    {        
        character.GameOverUI.OnRevive -= Revive;
        character.Animator.SetTrigger(character.animationSettings.RunTrigger);
        stateMachine.ChangeState<InvulnerableState>();

        character.InRunUI.Open();
        character.GameOverUI.Close();
    }

    protected void Die()
    {
        deathCount++;        
        character.Animator.SetTrigger(character.animationSettings.DieTrigger);

        character.InRunUI.Close();
        character.GameOverUI.Open(character.ScoreCounter.Score, character.Coins, canBeRevived);
        character.GameOverUI.OnRevive += Revive;
    }

}

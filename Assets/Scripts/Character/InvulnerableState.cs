using System.Collections;
using UnityEngine;

public class InvulnerableState:RunState
{
    public InvulnerableState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    private Coroutine timerCoroutine;

    public override void Enter()
    {
        Debug.Log("Invulnerable enter");
        character.Animator.SetTrigger(character.ReviveTrigger);
        InstantGetInLane();
        EnableInvulnerability();
    }

    public override void Exit()
    {
        DisableInvulnerability();
        Debug.Log("Invulnerable exit");
    }

    public override void TriggerEnter(Collider trigger) 
    {
        AddItem(trigger);
    }

    public override void Collision(Collision collision) { }

    public override void HandleInput(InputDetector inputDetector)
    {
        Vector2 input = inputDetector.CheckInputDirection();

        if (input.x == 1)
        {
            stateMachine.ChangeState(character.RunState);
            ChangeLaneRight();
        }
        if (input.x == -1)
        {
            stateMachine.ChangeState(character.RunState);
            ChangeLaneLeft();
        }
        if (input.y == 1)
        {
            stateMachine.ChangeState(character.JumpState);
        }
        if (input.y == -1)
        {            
            stateMachine.ChangeState(character.RollState);
        }

    }

    protected void EnableInvulnerability()
    {
        Physics.IgnoreLayerCollision(character.gameObject.layer, character.InvulnerableToLayer, true);
        timerCoroutine = character.StartCoroutine(Timer());
    }

    protected void DisableInvulnerability()
    {
        if (timerCoroutine != null)
        {
            character.StopCoroutine(timerCoroutine);
            Physics.IgnoreLayerCollision(character.gameObject.layer, character.InvulnerableToLayer, false);
            timerCoroutine = null;
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(character.InvulnerabilityTime);
        stateMachine.ChangeState(character.RunState);
    }

}


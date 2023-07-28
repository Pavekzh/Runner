using System.Collections;
using UnityEngine;

public class InvulnerableState:RunState
{
    public InvulnerableState(CharacterModel character, StateMachine stateMachine) : base(character, stateMachine) { }

    private Coroutine timerCoroutine;

    public override void Enter()
    {
        Debug.Log("Invulnerable enter");
        character.Animator.SetTrigger(character.animationSettings.ReviveTrigger);
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
            stateMachine.ChangeState<RunState>();
            ChangeLaneRight();
        }
        if (input.x == -1)
        {
            stateMachine.ChangeState<RunState>();
            ChangeLaneLeft();
        }
        if (input.y == 1)
        {
            stateMachine.ChangeState<JumpState>();
        }
        if (input.y == -1)
        {            
            stateMachine.ChangeState<RollState>();
        }

    }

    protected void EnableInvulnerability()
    {
        Physics.IgnoreLayerCollision(character.gameObject.layer, character.invulnerabilitySettings.InvulnerableToLayer, true);
        timerCoroutine = character.StartCoroutine(Timer());
    }

    protected void DisableInvulnerability()
    {
        if (timerCoroutine != null)
        {
            character.StopCoroutine(timerCoroutine);
            Physics.IgnoreLayerCollision(character.gameObject.layer, character.invulnerabilitySettings.InvulnerableToLayer, false);
            timerCoroutine = null;
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(character.invulnerabilitySettings.InvulnerabilityTime);
        stateMachine.ChangeState<RunState>();
    }

}


using UnityEngine;

public class StandState : BaseState
{
    public StandState(CharacterModel character, StateMachine stateMachine) : base(character, stateMachine) { }

    public override void Enter() 
    {
        Debug.Log("Stand enter");
    }

    public override void Exit() 
    {
        Debug.Log("Stand exit");
        character.Animator.SetTrigger(character.animationSettings.RunTrigger);
        character.MenuUI.Close();
        character.InRunUI.Open();
    }

    public override void HandleInput(InputDetector inputDetector)
    {
        if (inputDetector.CheckAnyInput())
            stateMachine.ChangeState<RunState>();
    }
    
    public override void Run() { }

    public override void TriggerEnter(Collider trigger) { }    
    
    public override void Collision(Collision collision) { }

    public override void CollisionExit(Collision collision) { }
}


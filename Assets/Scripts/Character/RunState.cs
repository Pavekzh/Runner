using UnityEngine;
using System.Collections;

public class RunState : BaseState
{
    public RunState(CharacterModel character, StateMachine stateMachine) : base(character, stateMachine) { }

    protected int Lane
    {
        get => character.Lane;
        set => character.Lane = value;
    }

    public override void Enter()
    {
        Debug.Log("Run enter");
        character.Animator.SetTrigger(character.animationSettings.RunTrigger);
    }

    public override void Exit()
    {
        Debug.Log("Run exit");
    }

    public override void Run()
    {
        character.CurrentSpeed += character.moveSettings.Acceleration * Time.deltaTime;

        Vector3 delta = character.MoveDirection * character.CurrentSpeed * Time.deltaTime;

        character.transform.Translate(delta, Space.World);
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
        if (input.y == -1)
            stateMachine.ChangeState<RollState>();
    }

    public override void Collision(Collision collision) { }

    public override void TriggerEnter(Collider trigger)
    {
        if (AddItem(trigger))
            return;
        else if (trigger.tag == character.deathSettings.LowerObstacleTag)
            Death();
        else if (trigger.tag == character.deathSettings.UpperObstacleTag)
            Death();
        
    }

    public override void CollisionExit(Collision collision) { }

    protected void Death()
    {
        StopLaneChanging();
        stateMachine.ChangeState<DeathState>();
    }

    protected bool AddItem(Collider collider)
    {
        if (collider.tag == character.itemsSettings.ItemsTag)
        {
            Item item = collider.gameObject.GetComponent<Item>();
            item.Collected();
            ItemData itemData = item.ItemData;


            if (itemData.Type == character.itemsSettings.CoinsType)
                character.Coins += itemData.Count;
            else
            {
                if (character.Items.ContainsKey(itemData.Type))
                    character.Items[itemData.Type] += itemData.Count;
                else
                    character.Items.Add(itemData.Type, itemData.Count);
            }

            return true;
        }
        else
            return false;
    }

    protected void ChangeLaneRight()
    {
        if (Lane == 2)
            return;

        Lane++;

        StopLaneChanging();

        character.ChangingLaneCoroutine = character.StartCoroutine(ChangingLane());
    }

    protected void ChangeLaneLeft()
    {
        if (Lane == 0)
            return;

        Lane--;

        StopLaneChanging();

        character.ChangingLaneCoroutine = character.StartCoroutine(ChangingLane());
    }

    protected void InstantGetInLane()
    {
        if(character.transform.position.x != character.XPositions[Lane])
        {
            character.transform.position = new Vector3(character.XPositions[Lane], character.transform.position.y, character.transform.position.z);
        }
    }

    protected void StopLaneChanging()
    {
        if (character.ChangingLaneCoroutine != null)
            character.StopCoroutine(character.ChangingLaneCoroutine);

        character.ChangingLaneCoroutine = null;
    }

    private IEnumerator ChangingLane()
    {
        yield return null;
        float startingDelta = Mathf.Abs(character.XPositions[Lane] - character.transform.position.x);
        float startingPos = character.transform.position.x;

        while (Mathf.Abs(character.transform.position.x - startingPos) < startingDelta)
        {
            Vector3 toLane = new Vector3(character.XPositions[Lane] - character.transform.position.x, 0, 0).normalized;
            Vector3 delta = toLane * character.moveSettings.ChangingLaneSpeed * Time.deltaTime;

            character.transform.Translate(delta);

            yield return null;
        }
        InstantGetInLane();
        character.ChangingLaneCoroutine = null;
    }

}


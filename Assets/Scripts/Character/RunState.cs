using UnityEngine;
using System.Collections;

public class RunState : BaseState
{
    public RunState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

    protected int Lane
    {
        get => character.Lane;
        set => character.Lane = value;
    }

    public override void Enter()
    {
        Debug.Log("Run enter");
        character.Animator.SetTrigger(character.RunTrigger);
    }

    public override void Exit()
    {
        Debug.Log("Run exit");
    }

    public override void Run()
    {
        character.Speed += character.Acceleration * Time.deltaTime;

        Vector3 delta = character.MoveDirection * character.Speed * Time.deltaTime;

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
            stateMachine.ChangeState(character.JumpState);
        if (input.y == -1)
            stateMachine.ChangeState(character.RollState);
    }

    public override void Collision(Collision collision) { }

    public override void TriggerEnter(Collider trigger)
    {
        if (AddItem(trigger))
            return;
        else if (trigger.gameObject.layer == character.LowerObstacleLayer)
            Death();
        else if (trigger.gameObject.layer == character.UpperObstacleLayer)
            Death();
        
    }

    public override void CollisionExit(Collision collision) { }

    protected void Death()
    {
        StopLaneChanging();
        stateMachine.ChangeState(character.DeathState);
    }

    protected bool AddItem(Collider collider)
    {
        if (collider.gameObject.layer == character.ItemsLayer)
        {
            Item item = collider.gameObject.GetComponent<Item>();
            item.Collected();
            ItemData itemData = item.ItemData;


            if (itemData.TypeId == character.CoinsTypeId)
                character.Coins += itemData.Count;
            else
            {
                if (character.Items.ContainsKey(itemData.TypeId))
                    character.Items[itemData.TypeId] += itemData.Count;
                else
                    character.Items.Add(itemData.TypeId, itemData.Count);
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
            Vector3 delta = toLane * character.ChangingLaneSpeed * Time.deltaTime;

            character.transform.Translate(delta);

            yield return null;
        }
        InstantGetInLane();
        character.ChangingLaneCoroutine = null;
    }

}


using System;
using System.Collections;
using UnityEngine;

public class CharacterMove:MonoBehaviour
{
    [Header("Lanes")]
    [SerializeField] private float leftLaneOffset = -2;
    [SerializeField] private float rightLaneOffset = 2;
    [SerializeField] private float changingLaneSpeed = 10;
    [Header("Run")]
    [SerializeField] private float speed = 2;
    [SerializeField] private float acceleration = 0.1f;

    private Vector3 direction { get => Vector3.forward; }

    private int Lane = 1;
    private float[] XPositions;

    public float Speed { get => speed; }
    public float Acceleration { get => acceleration; }

    public event Action<Vector3> OnMoved;

    private Coroutine currentChangeLaneCoroutine;

    private void Start()
    {
        XPositions = new float[3]{
            transform.position.x + leftLaneOffset,
            transform.position.x,
            transform.position.x + rightLaneOffset };
    }

    public void InstantGetInLane()
    {
        transform.position = new Vector3(XPositions[Lane], transform.position.y, transform.position.z);
    }

    public void StopLaneChanging()
    {
        if(currentChangeLaneCoroutine != null)
            StopCoroutine(currentChangeLaneCoroutine);

        currentChangeLaneCoroutine = null;
    }

    public void ChangeLaneLeft()
    {
        if (Lane == 0)
            return;

        Lane--;

        if(currentChangeLaneCoroutine != null)
            StopCoroutine(currentChangeLaneCoroutine);

        currentChangeLaneCoroutine = StartCoroutine(ChangingLane());
    }

    public void ChangeLaneRight()
    {
        if (Lane == 2)
            return;

        Lane++;

        if(currentChangeLaneCoroutine != null)
            StopCoroutine(currentChangeLaneCoroutine);

        currentChangeLaneCoroutine = StartCoroutine(ChangingLane());
    }

    private IEnumerator ChangingLane()
    { 
        yield return null;
        float startingDelta = Mathf.Abs(XPositions[Lane] - transform.position.x);
        float startingPos = transform.position.x;

        while(Mathf.Abs(transform.position.x - startingPos) < startingDelta)
        {
            Vector3 toLane = new Vector3(XPositions[Lane] - transform.position.x,0,0).normalized;
            transform.Translate(toLane * changingLaneSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = new Vector3(XPositions[Lane],transform.position.y,transform.position.z);
        currentChangeLaneCoroutine = null;
    }

    public void Move()
    {
        this.speed += acceleration * Time.deltaTime;

        Vector3 delta = direction * speed * Time.deltaTime;

        transform.Translate(delta, Space.World);
        OnMoved?.Invoke(delta);
    }
}


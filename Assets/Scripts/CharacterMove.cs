using System;
using UnityEngine;

public class CharacterMove:MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private Vector3 direction = Vector3.forward;

    public float Speed { get => speed; }
    public float Acceleration { get => acceleration; }
    public Vector3 Direction { get => direction; }

    public event Action<Vector3> OnMoved;

    public void Move(float speed, Vector3 direction)
    {
        this.speed = speed;
        this.direction = direction;

        Vector3 delta = direction * speed * Time.deltaTime;

        transform.Translate(delta, Space.World);
        OnMoved?.Invoke(delta);
    }
}


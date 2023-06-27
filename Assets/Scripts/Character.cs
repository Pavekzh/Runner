using System;
using UnityEngine;

public class Character:MonoBehaviour
{
    [SerializeField] private InputDetector inputDetector;

    [SerializeField] private float speed = 1;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private Vector3 direction = Vector3.forward;


    public float Speed { get => speed; }
    public float Acceleration { get => acceleration; }
    public Vector3 Direction { get => direction; }

    public event Action<Vector3> OnMoved;

    private StateMachine stateMachine;

    public RunState RunState { get; private set; }
    public DuckState DuckState { get; private set; }
    public JumpState JumpState { get; private set; }
    public DeathState DeathState { get; private set; }
    public StandState StandState { get; private set; }

    private void Start()
    {
        stateMachine = new StateMachine();

        RunState = new RunState(this, stateMachine);
        DuckState = new DuckState(this, stateMachine);
        JumpState = new JumpState(this, stateMachine);
        DeathState = new DeathState(this, stateMachine);
        StandState = new StandState(this, stateMachine);

        stateMachine.Init(StandState);
    }

    private void Update()
    {
        stateMachine.CurrentState.HandleInput(inputDetector);
        stateMachine.CurrentState.Run();
    }

    private void OnTriggerEnter(Collider other)
    {
        //check item
        //state earn item
    }

    private void OnCollisionEnter(Collision collision)
    {
        //check upper
        //state upper collision

        //check lower 
        //state lower collision
    }

    public void Move(float speed,Vector3 direction)
    {
        this.speed = speed;
        this.direction = direction;

        Vector3 delta = direction * speed * Time.deltaTime;

        transform.Translate(delta,Space.World);
        OnMoved?.Invoke(delta);
    }
}

using System;
using UnityEngine;

public class Character:MonoBehaviour
{
    [SerializeField] private InputDetector inputDetector;
    [SerializeField] private CharacterMove move;
    [SerializeField] private CharacterDeath death;

    public CharacterDeath Death { get => death; }
    public CharacterMove Move { get => move; }

    private StateMachine stateMachine;

    public RunState RunState { get; private set; }
    public RollState DuckState { get; private set; }
    public JumpState JumpState { get; private set; }
    public DeathState DeathState { get; private set; }
    public StandState StandState { get; private set; }

    private void Start()
    {
        stateMachine = new StateMachine();

        RunState = new RunState(this, stateMachine);
        DuckState = new RollState(this, stateMachine);
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
        stateMachine.CurrentState.TriggerEnter(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        stateMachine.CurrentState.Collision(collision);
    }

}

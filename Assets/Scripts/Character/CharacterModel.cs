using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class CharacterModel:MonoBehaviour
{
    public MoveSettings moveSettings;
    public JumpSettings jumpSettings;
    public RollSettings rollSettings;
    public ItemsSettings itemsSettings;    
    public DeathSettings deathSettings;
    public InvulnerabilitySettings invulnerabilitySettings;
    public AnimationSettings animationSettings;

    public Vector3 MoveDirection { get => Vector3.forward; }
    public float[] XPositions { get; private set; }

    public Coroutine ChangingLaneCoroutine { get; set; }

    public int Lane { get; set; } = 1;
    public float CurrentSpeed { get; set; }

    public Dictionary<ItemType, int> Items { get; private set; } = new Dictionary<ItemType, int>();
    public int Coins { get; set; }

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }


    private InputDetector inputDetector;
    private ScoreCounter scoreCounter;
    private StateMachine stateMachine;
    
    public InRunUIController InRunUI { get; private set; }
    public MainMenuController MenuUI { get; private set; }
    public GameOverController GameOverUI { get; private set; }

    public ScoreCounter ScoreCounter { get => scoreCounter; }

    public void InitDependecies(InputDetector inputDetector,ScoreCounter scoreCounter,InRunUIController inRunUI,MainMenuController menuUI,GameOverController gameOverUI)
    {
        this.inputDetector = inputDetector;
        this.scoreCounter = scoreCounter;
        this.InRunUI = inRunUI;
        this.MenuUI = menuUI;
        this.GameOverUI = gameOverUI;
    }

    private void Awake()
    {
        this.Rigidbody = GetComponent<Rigidbody>();
        this.Animator = GetComponentInChildren<Animator>();
        XPositions = new float[]
        {
            transform.position.x + moveSettings.LeftLaneOffset,
            transform.position.x,
            transform.position.x + moveSettings.RightLaneOffset
        };
        this.CurrentSpeed = moveSettings.StartSpeed;
    }

    private void Start()
    {
        stateMachine = new StateMachine(this);
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

    private void OnCollisionExit(Collision collision)
    {
        stateMachine.CurrentState.CollisionExit(collision);
    }
}

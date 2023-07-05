using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class Character:MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float leftLaneOffset = -2;
    [SerializeField] private float rightLaneOffset = 2;
    [SerializeField] private float changingLaneSpeed = 10;
    [SerializeField] private float speed = 2;
    [SerializeField] private float acceleration = 0.1f;
    [Header("Death")]
    [SerializeField] private int lowerObstacleLayer;
    [SerializeField] private int upperObstacleLayer;
    [SerializeField] private int timesCanBeRevived = 1;
    [Header("Jump")]
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float power = 5;
    [Header("Roll")]
    [SerializeField] private float rollTime;
    [Header("Items")]
    [SerializeField] private string coinsTypeId;
    [SerializeField] private int itemsLayer;
    [Header("Invulnerability")]
    [SerializeField] private float invulnerabilityTime = 3;
    [SerializeField] private int invulnerableTo;
    [Header("Animations")]
    [SerializeField] private Animator animator;
    [SerializeField] private string runTrigger = "Run";
    [SerializeField] private string jumpTrigger = "Jump";
    [SerializeField] private string rollTrigger = "Roll";
    [SerializeField] private string dieTrigger = "Die";
    [SerializeField] private string reviveTrigger = "Revive";
    
    public float[] XPositions { get; private set; }
    public Coroutine ChangingLaneCoroutine { get; set; }
    public int Lane { get; set; } = 1;
    public Vector3 MoveDirection { get => Vector3.forward; }

    public Rigidbody Rigidbody { get; private set; }

    public Dictionary<string, int> Items { get; private set; } = new Dictionary<string, int>();
    public int Coins { get; set; }

    public float LeftLaneOffset { get => leftLaneOffset; }
    public float RightLaneOffset { get => rightLaneOffset; }
    public float ChangingLaneSpeed { get => changingLaneSpeed; }
    public float Speed { get => speed; set => speed = value; }
    public float Acceleration { get => acceleration; }

    public int LowerObstacleLayer { get => lowerObstacleLayer; }
    public int UpperObstacleLayer { get => upperObstacleLayer; }
    public int TimesCanBeRevived { get => timesCanBeRevived; }  

    public LayerMask GroundLayers { get => groundLayers; }
    public float JumpPower { get => power; }

    public float RollTime { get => rollTime; }

    public int ItemsLayer { get => itemsLayer; }
    public string CoinsTypeId { get => coinsTypeId; }

    public float InvulnerabilityTime { get => invulnerabilityTime; }
    public int InvulnerableToLayer { get => invulnerableTo; }

    public Animator Animator { get => animator; }
    public string RunTrigger { get => runTrigger; }
    public string JumpTrigger { get => jumpTrigger; }
    public string RollTrigger { get => rollTrigger; }
    public string DieTrigger { get => dieTrigger; }
    public string ReviveTrigger { get => reviveTrigger; }


    private InputDetector inputDetector;
    private ScoreCounter scoreCounter;
    private StateMachine stateMachine;
    
    public InRunUIController InRunUI { get; private set; }
    public MainMenuController MenuUI { get; private set; }
    public GameOverController GameOverUI { get; private set; }

    public ScoreCounter ScoreCounter { get => scoreCounter; }

    public RunState RunState { get; private set; }
    public RollState RollState { get; private set; }
    public JumpState JumpState { get; private set; }
    public DeathState DeathState { get; private set; }
    public StandState StandState { get; private set; }
    public InvulnerableState InvulnerableState { get; private set; }

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
        XPositions = new float[]
        {
            transform.position.x + leftLaneOffset,
            transform.position.x,
            transform.position.x + rightLaneOffset
        };
    }

    private void Start()
    {
        stateMachine = new StateMachine();

        RunState = new RunState(this, stateMachine);
        RollState = new RollState(this, stateMachine);
        JumpState = new JumpState(this, stateMachine);
        DeathState = new DeathState(this, stateMachine);
        StandState = new StandState(this, stateMachine);
        InvulnerableState = new InvulnerableState(this, stateMachine);

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

    private void OnCollisionExit(Collision collision)
    {
        stateMachine.CurrentState.CollisionExit(collision);
    }
}

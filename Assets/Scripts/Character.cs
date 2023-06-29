using UnityEngine;

public class Character:MonoBehaviour
{
    [SerializeField] private CharacterMove move;
    [SerializeField] private CharacterDeath death;
    [SerializeField] private CharacterJump jump;
    [SerializeField] private CharacterRoll roll;
    [SerializeField] private CharacterItems items;
    [SerializeField] private CharacterInvulnerability invulnerability;
    [SerializeField] private UISwitcher uiSwitcher;

    private InputDetector inputDetector;
    private ScoreCounter scoreCounter;
    private StateMachine stateMachine;


    public ScoreCounter ScoreCounter { get => scoreCounter; }

    public UISwitcher UISwitcher { get => uiSwitcher; }
    public CharacterDeath Death { get => death; }
    public CharacterMove Move { get => move; }
    public CharacterJump Jump { get => jump; }
    public CharacterRoll Roll { get => roll; }
    public CharacterItems Items { get => items; }
    public CharacterInvulnerability Invulnerability { get => invulnerability; }

    public RunState RunState { get; private set; }
    public RollState RollState { get; private set; }
    public JumpState JumpState { get; private set; }
    public DeathState DeathState { get; private set; }
    public StandState StandState { get; private set; }
    public InvulnerableState InvulnerableState { get; private set; }

    public void InitDependecies(InputDetector inputDetector,ScoreCounter scoreCounter)
    {
        this.inputDetector = inputDetector;
        this.scoreCounter = scoreCounter;
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
}

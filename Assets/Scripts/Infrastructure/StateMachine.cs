using System.Collections.Generic;
using System.Linq;

public class StateMachine
{
    private BaseState currentState;

    public BaseState CurrentState 
    {
        get => currentState;

        private set
        {
            if (currentState != null)
                currentState.Exit();

            value.Enter();
            currentState = value;
        }
    }

    private List<BaseState> allStates;

    public StateMachine(CharacterModel characterModel)
    {
        allStates = new List<BaseState>()
        {
            new RunState(characterModel, this),
            new RollState(characterModel, this),
            new JumpState(characterModel, this),
            new DeathState(characterModel, this),
            new StandState(characterModel, this),
            new InvulnerableState(characterModel, this)
        };

        ChangeState<StandState>();
    }
    
    public void ChangeState<T> () where T : BaseState
    {
        BaseState state = allStates.FirstOrDefault(state => state is T);
        CurrentState = state;
    }
}


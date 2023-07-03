

public class StateMachine
{
    public BaseState CurrentState { get; private set; }

    public void Init(BaseState startingState)
    {
        startingState.Enter();
        CurrentState = startingState;
    }

    public void ChangeState(BaseState state)
    {
        CurrentState.Exit();

        state.Enter();
        CurrentState = state;
    }
}


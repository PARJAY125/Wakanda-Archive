public class CharacterStateMachine {
    protected CharacterState CurrentCharacterState {get; set;}

    public void Initialize(CharacterState startingState) {
        CurrentCharacterState = startingState;
        CurrentCharacterState.EnterState();
    }

    public void ChangeState(CharacterState newState) {
        CurrentCharacterState.ExitState();
        CurrentCharacterState = newState;
        CurrentCharacterState.EnterState();
    }
}
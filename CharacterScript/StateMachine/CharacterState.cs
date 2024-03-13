public class CharacterState {
    protected CharacterBase characterBase;
    protected CharacterStateMachine characterStateMachine;

    public CharacterState(CharacterBase characterBase, CharacterStateMachine characterStateMachine) {
        this.characterBase = characterBase;
        this.characterStateMachine = characterStateMachine;
    }

    public virtual void EnterState() {

    }

    
    public virtual void FrameUpdate() {

    }

    public virtual void ExitState() {

    }


}
using UnityEngine;

public class CharacterState {
    protected CharacterBase characterBase;
    protected CharacterStateMachine characterStateMachine;
    protected MonoBehaviour mono;

    public CharacterState(CharacterBase characterBase, CharacterStateMachine characterStateMachine, MonoBehaviour mono) {
        this.characterBase = characterBase;
        this.characterStateMachine = characterStateMachine;
        this.mono = mono;
    }

    public CharacterState(CharacterBase characterBase, CharacterStateMachine characterStateMachine)
    {
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
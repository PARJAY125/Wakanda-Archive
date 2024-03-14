using UnityEngine;

public class CharacterAttackState : CharacterState
{
    public CharacterAttackState
        (CharacterBase characterBase, CharacterStateMachine characterStateMachine, MonoBehaviour mono) 
        : base(characterBase, characterStateMachine, mono)
    {
        // act like awake function
    }

    public override void EnterState() {
        // act like start function
    }

    
    public override void FrameUpdate() {
        // act like update function

        // minimalize the update function usage
        // if possible, dont use it at all
    }

    public override void ExitState() {
        // dont forgget to handle the stop of all the coroutine 
        //  (example : what if the coroutine not finished and have to change state)
        //  (example : what if I want to pass some coroutine to other state)
    }
}
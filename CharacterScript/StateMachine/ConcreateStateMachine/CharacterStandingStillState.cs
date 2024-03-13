using System.Collections;
using UnityEngine;

public class CharacterStandingStillState : CharacterState
{
    
    public CharacterStandingStillState(CharacterBase characterBase, CharacterStateMachine characterStateMachine) : base(characterBase, characterStateMachine)
    {
        // can act like Awake function
    }

    public override void EnterState() {
        // state logic here
        Debug.Log("Entering 'CharacterStandingStillState' - State ");
    }
    
    public override void FrameUpdate() {
        // act like update
        Debug.Log("Frame Update in the 'CharacterStandingStillState' - State ");
    }

    public override void ExitState() {
        
    }
}
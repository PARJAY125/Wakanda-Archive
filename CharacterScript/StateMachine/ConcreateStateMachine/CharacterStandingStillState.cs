using System.Collections;
using UnityEngine;

public class CharacterStandingStillState : CharacterState
{
    public CharacterStandingStillState
        (CharacterBase characterBase, CharacterStateMachine characterStateMachine, MonoBehaviour mono) 
        : base(characterBase, characterStateMachine, mono)
    {
        // Constructor of State can act like awake
        Debug.Log("Constructor of State can act like awake");
    }


    public override void EnterState() {
        // state logic here
        Debug.Log("Entering 'CharacterStandingStillState' - State ");
        mono.StartCoroutine(StateUpdate());
    }
    
    public IEnumerator StateUpdate()
    {
        // State update logic here
        // Debug.Log("ITS WORK!!!! ITS WORK AND ITS USING IENUMERATOR COROUTINE");
        // yield return new WaitForSeconds(2f);
        Debug.Log("Changing State to CharacterMoveState in 2 second");
        yield return new WaitForSeconds(2f);
        characterStateMachine.ChangeState(characterBase.CharacterMoveState);
    }
    
    public override void FrameUpdate() {
        // act like update
        Debug.Log("Frame Update in the 'CharacterStandingStillState' - State ");
    }

    public override void ExitState() {
        // dont forgget to handle the stop of all the coroutine 
        //  (example : what if the coroutine not finished and have to change state)
        //  (example : what if I want to pass some coroutine to other state)
        mono.StopCoroutine(StateUpdate());

        // this can be sometimes when I want to pass some coroutine to other state
        // mono.StopAllCoroutines();
    }
}
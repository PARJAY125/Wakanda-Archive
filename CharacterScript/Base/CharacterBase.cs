using System.Collections;
using UnityEngine;


// Description [Human Language] :
//  - The script of Main Actor GameObject
//  - Contain all possible blue archive character action in gameplay
//  - action : scan area, take cover, setTargetedChar, shoot, path finding, take damage, march forward


// TODO : it would be nice if we have null safety
// idea 1 : have a function to call targetedChar with null checker


// this CharacterScript need State (in progress)

public class CharacterBase : MonoBehaviour, IAimable, IAttackable, IDamagable, 
    IMoveable, IReloadable, IScanForCover, IScanForOpponent, IStandingStill, ITakingCover
{
    [field : SerializeField] public float MaxHealth { get; set; }
    [field : SerializeField] public float CurrentHealth { get; set; }
    
    [field : SerializeField] public Weapon Weapon { get; set; }

    [field : SerializeField] public float Speed { get; set; }
    
    [field : SerializeField] public bool IsCanTakeCover { get; set; }
    
    #region State Machine Variable 

    public CharacterStateMachine StateMachine;
    public CharacterAimState CharacterAimState {get; set;}
    public CharacterAttackState CharacterAttackState {get; set;}
    public CharacterMoveState CharacterMoveState {get; set;}
    public CharacterReloadState CharacterReloadState {get; set;}
    public CharacterScanCoverState CharacterScanCoverState {get; set;}
    public CharacterScanOpponentState CharacterScanOpponentState {get; set;}
    public CharacterStandingStillState CharacterStandingStillState {get; set;}
    public CharacterTakeCoverState CharacterTakeCoverState {get; set;}

    #endregion

    void Awake()
    {
        CurrentHealth = MaxHealth;

        StateMachine = new CharacterStateMachine();

        CharacterAimState = new CharacterAimState(this, StateMachine, this);
        CharacterAttackState = new CharacterAttackState(this, StateMachine, this);
        CharacterMoveState = new CharacterMoveState(this, StateMachine, this);
        CharacterReloadState = new CharacterReloadState(this, StateMachine, this);
        CharacterScanCoverState = new CharacterScanCoverState(this, StateMachine, this);
        CharacterScanOpponentState = new CharacterScanOpponentState(this, StateMachine, this);
        CharacterStandingStillState = new CharacterStandingStillState(this, StateMachine, this);
        CharacterTakeCoverState = new CharacterTakeCoverState(this, StateMachine, this);

        StateMachine.Initialize(CharacterStandingStillState);
    }

    public IEnumerator StartStateCoroutine()
    {
        Debug.Log("you call me from the base");
        yield return new WaitForSeconds(1f);
    }

    // void Update()
    // {
    //     StateMachine.CurrentCharacterState.FrameUpdate();
    // }

    public void TakeDamage(float DamageAmount)
    {
        CurrentHealth -= DamageAmount;
        if (CurrentHealth < 0 ) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    
    public void MoveForward()
    {
        throw new System.NotImplementedException();
    }

    public void MoveToTarget(Vector3 target)
    {
        throw new System.NotImplementedException();
    }

    public void AimAtTarget(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public void AttackTarget(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public void Reload(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public GameObject FindClosestCover()
    {
        throw new System.NotImplementedException();
    }

    public GameObject FindClosestOpponent()
    {
        throw new System.NotImplementedException();
    }

    public void StandingStill()
    {
        throw new System.NotImplementedException();
    }

    public float InCoverTakeDamage(float damage, float coverModifier, GameObject CoverSpot)
    {
        throw new System.NotImplementedException();
    }
}
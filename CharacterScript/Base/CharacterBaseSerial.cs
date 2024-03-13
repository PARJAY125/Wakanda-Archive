using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


// Description [Human Language] :
//  - The script of Main Actor GameObject
//  - Contain all possible blue archive character action in gameplay
//  - action : scan area, take cover, setTargetedChar, shoot, path finding, take damage, march forward


// TODO : it would be nice if we have null safety
// idea 1 : have a function to call targetedChar with null checker


// this CharacterScript need State (in progress)

[SerializeField]
public class CharacterBaseSerial : MonoBehaviour, IAimable, IAttackable, IDamagable, 
    IMoveable, IReloadable, IScanForCover, IScanForOpponent, IStandingStill, ITakingCover
{
    [field : SerializeField] public float MaxHealth { get; set; }
    [field : SerializeField] public float CurrentHealth { get; set; }

    [field : SerializeField] public Weapon Weapon { get; set; }
    
    [field : SerializeField] public float Speed { get; set; }
    
    [field : SerializeField] public bool IsCanTakeCover { get; set; }

    // [field : SerializeField] 
    // public CharacterAttribute CharacterAttribute { get; set; }

    void Awake()
    {
        CurrentHealth = MaxHealth;

        // pair CharacterAttribute with inner variable
    }

    public bool isAreaClear;

    public void StandingStill() {
        if (isAreaClear) {
            // findCover
            // findOpponent
        }
        else MoveForward();
    }

    public void MoveForward()
    {
        // set rotation Y to face the road
        throw new System.NotImplementedException();
    }

    public void MoveToTarget(Vector3 target)
    {
        // move to the closest target until the target is inside the character range collider
        // after that, change state to aim
        throw new System.NotImplementedException();
    }

    // if character health is low, scannable -> search for cover
    public GameObject FindClosestCover()
    {
        // smart cover finding
        // if cant take cover skip
        // if character attack range is short, find the farthest cover
        // if character attack range is long, find the nearest cover
        // if found, check if that cover is Occupied
        // if all condition above filled, change state to moveToTarget (coverSpot)

        throw new System.NotImplementedException();
    }

    public bool IsInCover()
    {
        throw new System.NotImplementedException();
    }

    public float InCoverTakeDamage(float damage, float coverModifier, GameObject CoverSpot)
    {
        // Reduce chance of being hitted by 50%
        // Reduce damage of Ex Skill (AoE, Fan Area, Circle Area, etc) by 30% -> changeable concept
        throw new System.NotImplementedException();
    }

    public GameObject FindClosestOpponent()
    {
        // just search the nearest opponent from character
        // if found, change state to moveToTarget (targetedOpponent)
        throw new System.NotImplementedException();
    }

    public void AimAtTarget(GameObject target)
    {
        // Steady IEnumerator the current target enemy becomes invalid (out of sight, dead), transition back to Scannable.
        // If targeted char still valid. transition to the attack logic within AimAtEnemy (potentially a sub-state or method call).
        // else. transition to the StandingStill state
        
        throw new System.NotImplementedException();
    }

    public void AttackTarget(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public void Reload(GameObject target)
    {
        // time sensitive
        // decrement ReloadTimeCounter to 0
        // after 0, set ReloadTimeCounter = ReloadSpeed
        // change state to Scan
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float DamageAmount)
    {
        CurrentHealth -= DamageAmount;
        if (CurrentHealth < 0 ) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
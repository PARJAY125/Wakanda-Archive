using UnityEngine;

public interface IAttackable
{
    Weapon Weapon { get; set; }

    void AttackTarget(GameObject target);
}
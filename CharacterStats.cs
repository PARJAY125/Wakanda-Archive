using System;

[Serializable]
public class CharacterStats
{
    public string charName;
    public float Maxhp;
    public float currentHp;
    public float damage;
    public float attackRange;
    public bool isCanTakeCover;
    public float attackSpeed = 1f;
}
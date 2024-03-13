using System;

[Serializable]
public class CharacterAttribute
{
    public string charName;
    
    public float MaxHealth;
    public float CurrentHealth;
    
    public Weapon weapon;
    
    public float Speed;
    
    public bool isCanTakeCover;
}
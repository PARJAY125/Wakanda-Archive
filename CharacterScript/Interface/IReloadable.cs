using UnityEngine;

public interface IReloadable
{
    Weapon Weapon {get; set;}

    void Reload(GameObject target);
}
using UnityEngine;

public interface IMoveable
{
    float Speed { get; set; }

    void MoveForward();

    void MoveToTarget(Vector3 target);    
}
using UnityEngine;

public interface IMovementStrategy 
{
    void Move(GameObject go, float deltaTime);
}
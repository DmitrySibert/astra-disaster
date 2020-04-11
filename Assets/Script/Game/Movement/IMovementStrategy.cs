using UnityEngine;

public interface IMovementStrategy 
{
    void Move(MovementCharacteristics characteristics, GameObject go, Data movementData);
    void Update(GameObject go, float deltaTime);
}

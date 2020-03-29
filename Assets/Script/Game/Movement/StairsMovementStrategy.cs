using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsMovementStrategy : IMovementStrategy
{
    public void Move(MovementCharacteristics characteristics, GameObject go, string moveCommand)
    {
        // Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        // Vector2 force = Vector3.up * characteristics.acceleration;
        // rb.AddForce(force, ForceMode2D.Impulse);
    }
}

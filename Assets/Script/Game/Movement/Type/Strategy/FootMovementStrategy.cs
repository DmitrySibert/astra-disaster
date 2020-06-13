using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootMovementStrategy : IMovementStrategy
{
    public void Move(GameObject go, float deltaTime)
    {
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        MovementCharacteristics characteristics = go.GetComponent<MovementCharacteristics>();

        characteristics.currentAccel = characteristics.direction * characteristics.accel;
        Vector2 velocity = Vector2.ClampMagnitude(characteristics.currentAccel, characteristics.maxVelocity);

        velocity = ApplyStairsEffect(characteristics, velocity);

        rb.velocity = velocity;
    }

    private Vector2 ApplyStairsEffect(MovementCharacteristics characteristics, Vector2 currentVelocity)
    {
        MovementEffect stairsEffect;
        if (characteristics.effects.TryGetValue(GameEffects.STAIRS, out stairsEffect)) {
            return Vector2.ClampMagnitude(currentVelocity, characteristics.maxVelocity * stairsEffect.GetDeceleration());
        }
        return currentVelocity;
    }
}

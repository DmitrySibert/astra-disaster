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
        rb.velocity = GetAffectedAccel(characteristics.effects.Values, characteristics.currentAccel);
    }

    private Vector2 GetAffectedAccel(ICollection<MovementEffect> effects, Vector2 accel)
    {
        float wholeEffect = 1;
        foreach(MovementEffect effect in effects) {
            wholeEffect -= effect.GetDeceleration();
        }
        if (wholeEffect < 0) {
            wholeEffect = 0;
        }
        return accel * wholeEffect;
    }
}

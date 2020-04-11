using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootMovementStrategy : IMovementStrategy
{
    private const string DIRECTION_KEY = "direction";
    private const string IS_MOVE_KEY = "isMove";

    private Dictionary<string, Vector2> m_directionVectors;

    public FootMovementStrategy()
    {
        m_directionVectors = new Dictionary<string, Vector2>();
        m_directionVectors["up"] = Vector2.up;
        m_directionVectors["down"] = -Vector2.up;
        m_directionVectors["left"] = -Vector2.right;
        m_directionVectors["right"] = Vector2.right;
    }

    public void Move(MovementCharacteristics characteristics, GameObject go, Data movementData)
    {
        string direction = movementData.Get<string>(DIRECTION_KEY);
        int accelSign = movementData.Get<bool>(IS_MOVE_KEY) ? 1 : -1;
        characteristics.currentAccel += accelSign * m_directionVectors[direction] * characteristics.accel;
    }

    public void Update(GameObject go, float deltaTime)
    {
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        MovementCharacteristics characteristics = go.GetComponent<MovementCharacteristics>();
        rb.velocity = GetAffectedVelocity(characteristics.effects.Values, characteristics);
    }

    private Vector2 GetAffectedVelocity(ICollection<MovementEffect> effects, MovementCharacteristics characteristics)
    {
        float wholeEffect = 1;
        foreach(MovementEffect effect in effects) {
            wholeEffect -= effect.GetDeceleration();
        }
        if (wholeEffect < 0) {
            wholeEffect = 0;
        }
        return characteristics.currentAccel * wholeEffect;
    }
}

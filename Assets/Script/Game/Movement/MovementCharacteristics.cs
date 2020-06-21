using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovementCharacteristics : MonoBehaviour
{
    public MovementType type;
    public float maxVelocity;
    public float accel;
    public Vector2 direction;
    public Vector2 currentAccel;
    public Dictionary<GameEffects, MovementEffect> effects = new Dictionary<GameEffects, MovementEffect>();

    private MovementSystem movementSystem;

    private void Start()
    {
        movementSystem = FindObjectOfType<MovementSystem>();
        movementSystem.RegisterGameObject(gameObject.GetInstanceID(), gameObject);
    }

    private void OnDestroy()
    {
        movementSystem.UnregisterGameObject(gameObject.GetInstanceID());
    }
}

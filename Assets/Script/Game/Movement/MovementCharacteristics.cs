using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovementCharacteristics : MonoBehaviour
{
    public MovementType type;
    public float maxVelocity;
    public float accel;
    public Vector2 currentVelocity;
    public Vector2 currentAccel;
    public Dictionary<string, MovementEffect> effects = new Dictionary<string, MovementEffect>();
}

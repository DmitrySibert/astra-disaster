using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityResistance : MovementEffect
{
    [SerializeField]
    private float m_gravityStrength;

    public void Init(float gravityStrength)
    {
        m_gravityStrength = gravityStrength;
    }

    public override float GetResistance() {
        return m_gravityStrength;
    }
}

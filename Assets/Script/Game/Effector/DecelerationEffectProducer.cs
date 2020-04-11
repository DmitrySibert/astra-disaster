using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecelerationEffectProducer : MonoBehaviour
{
    [SerializeField]
    private float m_gravityStrength;
    private string m_effectName;
    private StairsDeceleration m_stairsDeceleration;

    void Start()
    {
        m_stairsDeceleration = new StairsDeceleration(0.5f);
        m_effectName = "StairsMovement";
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        MovementCharacteristics moveChars = col.gameObject.GetComponent<MovementCharacteristics>();
        if (moveChars != null) {
            moveChars.effects[m_effectName] = m_stairsDeceleration;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        MovementCharacteristics moveChars = col.gameObject.GetComponent<MovementCharacteristics>();
        if (moveChars != null) {
            moveChars.effects.Remove(m_effectName);
        }
    }
}

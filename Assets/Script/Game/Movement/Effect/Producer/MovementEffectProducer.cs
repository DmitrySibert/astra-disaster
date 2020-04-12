using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectProducer : MonoBehaviour
{
    [SerializeField]
    private MovementType m_producedType;
    private Dictionary<int, MovementType> m_previousMovementType;

    void Start()
    {
        m_previousMovementType = new Dictionary<int, MovementType>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        MovementCharacteristics moveChars = col.gameObject.GetComponent<MovementCharacteristics>();
        if (moveChars != null) {
            m_previousMovementType.Add(col.gameObject.GetInstanceID(), moveChars.type);
            moveChars.type = m_producedType;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        MovementCharacteristics moveChars = col.gameObject.GetComponent<MovementCharacteristics>();
        if (moveChars != null) {
            moveChars.type = m_previousMovementType[col.gameObject.GetInstanceID()];
            m_previousMovementType.Remove(col.gameObject.GetInstanceID());
        }
    }
}

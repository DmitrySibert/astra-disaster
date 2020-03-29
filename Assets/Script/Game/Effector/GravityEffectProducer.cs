using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityEffectProducer : MonoBehaviour
{

    [SerializeField]
    private float m_gravityStrength;

    private void OnTriggerEnter2D(Collider2D col)
    {
        GravityResistance gravityResistence = col.gameObject.AddComponent<GravityResistance>() as GravityResistance;
        gravityResistence.Init(m_gravityStrength);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        Destroy(col.gameObject.GetComponent<GravityResistance>());
    }
}

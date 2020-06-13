using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsEffectProducer : MonoBehaviour
{
    [SerializeField]
    private float effectPower;
    private StairsDeceleration stairsDeceleration;

    void Start()
    {
        stairsDeceleration = new StairsDeceleration(effectPower);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        MovementCharacteristics moveChars = col.gameObject.GetComponent<MovementCharacteristics>();
        if (moveChars != null) {
            moveChars.effects[GameEffects.STAIRS] = stairsDeceleration;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        MovementCharacteristics moveChars = col.gameObject.GetComponent<MovementCharacteristics>();
        if (moveChars != null) {
            moveChars.effects.Remove(GameEffects.STAIRS);
        }
    }
}

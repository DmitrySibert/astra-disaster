using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSystem : MonoBehaviour
{
    private MovementCharacteristics playerMovementCharacteristics;
    private Dispatcher dispatcher;
    private Dictionary<string, Vector2> primitiveDirection;

    private void Awake()
    {
        dispatcher = GetComponent<Dispatcher>();
        primitiveDirection = new Dictionary<string, Vector2>
        {
            [KeyboardController.ARROW_UP] = Vector2.up,
            [KeyboardController.ARROW_DOWN] = Vector2.down,
            [KeyboardController.ARROW_LEFT] = Vector2.left,
            [KeyboardController.ARROW_RIGHT] = Vector2.right
        };
        playerMovementCharacteristics = FindObjectOfType<Player>().GetComponent<MovementCharacteristics>();
        
        
    }

    void Start()
    {
        Debug.Assert(playerMovementCharacteristics != null);
        Debug.Log("Player controller System: initialized");
    }

    void Update()
    {
        if (dispatcher.IsEmpty()) {
            return;
        }
        Event evt = dispatcher.ReceiveEvent();
        HandleKeyboardEvent(evt.Data);
    }

    private void HandleKeyboardEvent(Data data)
    {
        playerMovementCharacteristics.direction += GetDirectionSign(data) * GetNewDirection(data);
    }

    private int GetDirectionSign(Data data)
    {
        if (data.Get<string>(KeyboardController.TYPE_KEY) == KeyboardController.PRESS) {
            return 1;
        }
        return -1;
    }

    private Vector2 GetNewDirection(Data data)
    {
        return primitiveDirection[data.Get<string>(KeyboardController.NAME_KEY)]; 
    }
}

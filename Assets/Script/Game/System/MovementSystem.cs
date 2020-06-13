using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    private const string FOOT_MOVEMENT_NAME = "Foot";
    private const string ZERO_GRAVITY_MOVEMENT_NAME = "ZeroGravity";

    private Dictionary<int, GameObject> m_movingObjects;
    private Dictionary<string, IMovementStrategy> m_movementStrategies;
    private Dispatcher dispatcher;

    void Start()
    {
        dispatcher = GetComponent<Dispatcher>();
        m_movingObjects = new Dictionary<int, GameObject>();
        m_movementStrategies = new Dictionary<string, IMovementStrategy>
        {
            [FOOT_MOVEMENT_NAME] = new FootMovementStrategy(),
            [ZERO_GRAVITY_MOVEMENT_NAME] = new ZeroGravityMovementStrategy()
        };
        Debug.Log("Movement System: initialized");
    }

    void Update()
    {
        HandleEvent();
        UpdateGameObjects();
    }

    private void UpdateGameObjects()
    {
        foreach(var go in m_movingObjects.Values)
        {
            MovementCharacteristics characteristics = go.GetComponent<MovementCharacteristics>();
            m_movementStrategies[characteristics.type.typeName].Move(go, Time.deltaTime);
        }
    }

    private void HandleEvent()
    {
        if (dispatcher.IsEmpty()) {
            return;
        }
        Event evt = dispatcher.ReceiveEvent();     
    }

    public void RegisterGameObject(int id, GameObject go)
    {
        m_movingObjects.Add(id, go);
    }
}

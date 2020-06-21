using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    private Dictionary<int, GameObject> m_movingObjects;
    private Dictionary<MovementTypeName, IMovementStrategy> m_movementStrategies;
    private Dispatcher dispatcher;

    private void Awake()
    {
        dispatcher = GetComponent<Dispatcher>();
        m_movingObjects = new Dictionary<int, GameObject>();
        m_movementStrategies = new Dictionary<MovementTypeName, IMovementStrategy>
        {
            [MovementTypeName.FOOT] = new Foot(),
            [MovementTypeName.ZERO_GRAVITY] = new ZeroGravity(),
            [MovementTypeName.MAGNETIC_WHEELS] = new MagneticWheels(),
        };
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

    public void UnregisterGameObject(int id)
    {
        m_movingObjects.Remove(id);
    }
}

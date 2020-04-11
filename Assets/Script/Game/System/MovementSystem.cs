using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    private const string MOVE_EVENT_NAME = "move";
    private const string ID_KEY = "id";
    private const string DIRECTION_KEY = "direction";
    private const string FOOT_MOVEMENT_NAME = "Foot";
    private const string STAIRS_MOVEMENT_NAME = "Stairs";

    private Dictionary<int, GameObject> m_movingObjects;
    private Dictionary<string, IMovementStrategy> m_movementStrategies;
    private Dispatcher dispatcher;

    void Start()
    {
        dispatcher = GetComponent<Dispatcher>();
        m_movingObjects = new Dictionary<int, GameObject>();
        m_movementStrategies = new Dictionary<string, IMovementStrategy>();
        m_movementStrategies[FOOT_MOVEMENT_NAME] = new FootMovementStrategy();
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
            m_movementStrategies[characteristics.type.typeName].Update(go, Time.deltaTime);
        }
    }

    private void ClampToMaxSpeed(GameObject go) 
    {
        // Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        // MovementCharacteristics characteristics = go.GetComponent<MovementCharacteristics>();
        // if(rb.velocity.magnitude > characteristics.maxVelocity)
        // {
        //     rb.velocity = Vector2.ClampMagnitude(rb.velocity, characteristics.maxVelocity);
        // }
    }

    private void ApplyEffects(GameObject go)
    {
        // MovementEffect[] movementEffects = go.GetComponents<MovementEffect>();
        // Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        // foreach(var movementEffect in movementEffects)
        // {
        //     float affectedVelocity = rb.velocity.magnitude - movementEffect.GetResistance() * Time.deltaTime;
        //     affectedVelocity = affectedVelocity > 0 ? affectedVelocity : 0;
        //     rb.velocity = Vector2.ClampMagnitude(rb.velocity, affectedVelocity);
        // }
    }

    private void HandleEvent()
    {
        if (dispatcher.IsEmpty()) {
            return;
        }
        Event evt = dispatcher.ReceiveEvent();
        GameObject go;
        if (evt.Name.Equals(MOVE_EVENT_NAME)) {
            int goId = evt.Data.Get<int>(ID_KEY);
            bool isRegistred = m_movingObjects.TryGetValue(goId, out go);
            if (!isRegistred) {
                return;
            }
            MovementCharacteristics characteristics = go.GetComponent<MovementCharacteristics>();
            m_movementStrategies[characteristics.type.typeName].Move(characteristics, go, evt.Data);
        }      
    }

    public void RegisterGameObject(int id, GameObject go)
    {
        m_movingObjects.Add(id, go);
    }
}

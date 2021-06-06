using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WaypointAI : MonoBehaviour
{
    [FormerlySerializedAs("WayPrototype")]
    [SerializeField]
    public WayPrototype wayPrototype;
    [SerializeField]
    public WaypointAIMovementType type;
    [SerializeField]
    public int target;

    public List<Transform> way;

    private WaypointAISystem waypointAISystem;

    private void Start()
    {
        waypointAISystem = FindObjectOfType<WaypointAISystem>();
        waypointAISystem.RegisterGameObject(gameObject.GetInstanceID(), gameObject);
        way = new List<Transform>(wayPrototype.points);
    }

    private void OnDestroy()
    {
        waypointAISystem.UnregisterGameObject(gameObject.GetInstanceID());
    }
}

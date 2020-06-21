using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAI : MonoBehaviour
{
    [SerializeField]
    public List<Vector2> waypoints;

    private void Start()
    {
        WaypointAISystem waypointAISystem = FindObjectOfType<WaypointAISystem>();
        waypointAISystem.RegisterGameObject(gameObject.GetInstanceID(), gameObject);
    }
}

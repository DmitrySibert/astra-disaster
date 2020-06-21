using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAISystem : MonoBehaviour
{
    private Dictionary<int, GameObject> ais;

    private void Awake()
    {
        ais = new Dictionary<int, GameObject>();
    }

    private void Start()
    {
        Debug.Log("Waypoint AI System: initialized");
    }

    void Update()
    {
        foreach(GameObject go in ais.Values) {
            WaypointAI ai = go.GetComponent<WaypointAI>();
            MovementCharacteristics movementCharacteristics = go.GetComponent<MovementCharacteristics>();
            if (ai.waypoints.Count == 0) {
                movementCharacteristics.direction = Vector2.zero;
                return;
            }
            Vector2 goalPoint = ai.waypoints[0];
            Transform transform = go.GetComponent<Transform>();
            if (IsGetCurrentPoint(transform, goalPoint)) {
                ai.waypoints.RemoveAt(0);
            }
            movementCharacteristics.direction = (goalPoint - (Vector2)transform.position).normalized;
        }
    }

    private bool IsGetCurrentPoint(Transform transform, Vector2 point)
    {
        float distance = Vector2.Distance(point, transform.position);
        return distance < 1f;
    }

    public void RegisterGameObject(int id, GameObject go)
    {
        ais.Add(id, go);
    }

    public void UnregisterGameObject(int id)
    {
        ais.Remove(id);
    }
}

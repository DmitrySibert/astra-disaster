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
            Transform targetPoint = ai.way[ai.target];
            Transform transform = go.GetComponent<Transform>();
            if (IsArriveTargetPoint(transform, targetPoint)) {
                HandleTargetPointArrival(ai, movementCharacteristics);
            }
            movementCharacteristics.direction = (targetPoint.position - transform.position).normalized;
        }
    }

    private void HandleTargetPointArrival(WaypointAI ai, MovementCharacteristics movementCharacteristics) {
        if (ai.way.Count - 1 == ai.target) {
            if (WaypointAIMovementType.REVERSE == ai.type) {
                ai.way.Reverse();
                ai.target = 0;
            }
            if (WaypointAIMovementType.CYCLE == ai.type) {
                ai.target = 0;
            }
            if (WaypointAIMovementType.SINGLE == ai.type) {
                movementCharacteristics.direction = Vector2.zero;
                return;
            }
        } else {
            ++ai.target;
        }
    }

    private bool IsArriveTargetPoint(Transform transform, Transform point)
    {
        float distance = Vector2.Distance(point.position, transform.position);
        return distance < 0.3f;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDispatcherSystem : MonoBehaviour
{
    private Dictionary<int, GameObject> m_dispatchers;

    // Start is called before the first frame update
    void Awake()
    {
        m_dispatchers = new Dictionary<int, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> allRobotsToDestroy = new List<GameObject>();
        foreach(GameObject dispatcherGo in m_dispatchers.Values) {
            RobotDispatcher dispatcher = dispatcherGo.GetComponent<RobotDispatcher>();
            getRobotsToDestroy(dispatcher);
            if (dispatcher.IsRobotMoveOut()) {
                dispatcher.MoveRobotOut();
            }
        }
    }

    public void getRobotsToDestroy(RobotDispatcher dispatcher) {
        List<GameObject> robotsToDestroy = new List<GameObject>();
        foreach(GameObject robot in dispatcher.ActiveRobots) {
            Bounds gateBounds = dispatcher.RobotRoute.GateIn.GetComponent<Collider2D>().bounds;
            Bounds robotBounds = robot.GetComponent<Collider2D>().bounds;
            if (gateBounds.Contains(robotBounds.min) && gateBounds.Contains(robotBounds.max)) {
                robotsToDestroy.Add(robot);
            }
        }
        foreach(GameObject robot in robotsToDestroy) {
            dispatcher.ActiveRobots.Remove(robot);
            Destroy(robot);
        }
    }
    
    public void RegisterGameObject(int id, GameObject go)
    {
        m_dispatchers.Add(id, go);
    }

    public void UnregisterGameObject(int id)
    {
        m_dispatchers.Remove(id);
    }
}

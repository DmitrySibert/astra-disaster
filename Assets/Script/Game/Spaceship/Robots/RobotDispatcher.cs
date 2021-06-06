using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RobotDispatcher : MonoBehaviour
{
    [FormerlySerializedAs("RobotIntervalSec")]
    [SerializeField]
    private int robotIntervalSec;

    [FormerlySerializedAs("RobotRoute")]
    [SerializeField]
    private RobotRoute robotRoute;

    [FormerlySerializedAs("RobotPrototype")]
    [SerializeField]
    private GameObject robot;

    public RobotRoute RobotRoute {
        get { return robotRoute; }
    }

    public GameObject RobotPrototype {
        get { return robot; }
    }

    public List<GameObject> ActiveRobots {
        get { return activeRobots; }
    }

    private List<GameObject> activeRobots;
    private List<GameObject> robotsToDestroy;
    private float lastOut;

    void Start()
    {
        activeRobots = new List<GameObject>();
        robotsToDestroy = new List<GameObject>();
        lastOut = Time.time;
        FindObjectOfType<RobotDispatcherSystem>().RegisterGameObject(gameObject.GetInstanceID(), gameObject);
    }

    void Destroy()
    {
        FindObjectOfType<RobotDispatcherSystem>().UnregisterGameObject(gameObject.GetInstanceID());
    }

    public bool IsRobotMoveOut() 
    {
        return Time.time - lastOut > robotIntervalSec;
    }

    public void MoveRobotOut()
    {
        GameObject newRobot = Instantiate<GameObject>(robot, robotRoute.GateOut.transform.position, Quaternion.identity);
        activeRobots.Add(newRobot);
        WaypointAI waypointAi = newRobot.GetComponent<WaypointAI>();
        waypointAi.wayPrototype = robotRoute.WayPrototype;
        lastOut = Time.time;
    }
}

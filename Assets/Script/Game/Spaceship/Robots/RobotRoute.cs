using UnityEngine;
using UnityEngine.Serialization;

public class RobotRoute : MonoBehaviour
{
    [FormerlySerializedAs("GateOut")]
    [SerializeField]
    private GameObject gateOut;

    [FormerlySerializedAs("GateIn")]
    [SerializeField]
    private GameObject gateIn;

    [FormerlySerializedAs("Way")]
    [SerializeField]
    private WayPrototype wayPrototype;

    public GameObject GateOut 
    {
        get { return gateOut; }
    }

    public GameObject GateIn 
    {
        get { return gateIn; }
    }

    public WayPrototype WayPrototype 
    {
        get { return wayPrototype; }
    }
}

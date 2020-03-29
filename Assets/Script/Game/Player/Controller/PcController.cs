using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcController : MonoBehaviour {

    private EventBus m_eventBus;
    [SerializeField]
    private int playerId;
    private const string MOVE_EVENT_NAME = "Move";
    private const string ID_KEY = "id";
    private const string DIRECTION_KEY = "direction";
    private const string DIRECTION_UP = "up";
    private const string DIRECTION_DOWN = "down";
    private const string DIRECTION_RIGHT = "right";
    private const string DIRECTION_LEFT = "left";

	void Start ()
    {
        Debug.Log("PcController initialized");
        m_eventBus = FindObjectOfType<EventBus>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp("up"))
        {
            Event evt = new Event(MOVE_EVENT_NAME);
            evt.Data[ID_KEY] = playerId;
            evt.Data[DIRECTION_KEY] = DIRECTION_UP;
            m_eventBus.TriggerEvent(evt);
        }
        if (Input.GetKeyUp("down"))
        {
            Event evt = new Event(MOVE_EVENT_NAME);
            evt.Data[ID_KEY] = playerId;
            evt.Data[DIRECTION_KEY] = DIRECTION_DOWN;
            m_eventBus.TriggerEvent(evt);
        }
        if (Input.GetKeyUp("left"))
        {
            Event evt = new Event(MOVE_EVENT_NAME);
            evt.Data[ID_KEY] = playerId;
            evt.Data[DIRECTION_KEY] = DIRECTION_LEFT;
            m_eventBus.TriggerEvent(evt);
        }
        if (Input.GetKeyUp("right"))
        {
            Event evt = new Event(MOVE_EVENT_NAME);
            evt.Data[ID_KEY] = playerId;
            evt.Data[DIRECTION_KEY] = DIRECTION_RIGHT;
            m_eventBus.TriggerEvent(evt);
        }
    }
}

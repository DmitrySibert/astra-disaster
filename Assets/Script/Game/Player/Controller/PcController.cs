using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcController : MonoBehaviour {

    private EventBus m_eventBus;
    [SerializeField]
    private int playerId;
    private const string MOVE_EVENT_NAME = "move";
    private const string ID_KEY = "id";
    private const string DIRECTION_KEY = "direction";
    private const string IS_MOVE_KEY = "isMove";
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
        HandleKeysUp();
        HandleKeysDown();
    }

    private void HandleKeysUp()
    {
        if (Input.GetKeyUp("up"))
        {
            Event evt = new Event(MOVE_EVENT_NAME);
            evt.Data[ID_KEY] = playerId;
            evt.Data[DIRECTION_KEY] = DIRECTION_UP;
            evt.Data[IS_MOVE_KEY] = false;
            m_eventBus.TriggerEvent(evt);
        }
        if (Input.GetKeyUp("down"))
        {
            Event evt = new Event(MOVE_EVENT_NAME);
            evt.Data[ID_KEY] = playerId;
            evt.Data[DIRECTION_KEY] = DIRECTION_DOWN;
            evt.Data[IS_MOVE_KEY] = false;
            m_eventBus.TriggerEvent(evt);
        }
        if (Input.GetKeyUp("left"))
        {
            Event evt = new Event(MOVE_EVENT_NAME);
            evt.Data[ID_KEY] = playerId;
            evt.Data[DIRECTION_KEY] = DIRECTION_LEFT;
            evt.Data[IS_MOVE_KEY] = false;
            m_eventBus.TriggerEvent(evt);
        }
        if (Input.GetKeyUp("right"))
        {
            Event evt = new Event(MOVE_EVENT_NAME);
            evt.Data[ID_KEY] = playerId;
            evt.Data[DIRECTION_KEY] = DIRECTION_RIGHT;
            evt.Data[IS_MOVE_KEY] = false;
            m_eventBus.TriggerEvent(evt);
        }
    }

    private void HandleKeysDown()
    {
        if (Input.GetKeyDown("up"))
        {
            Event evt = new Event(MOVE_EVENT_NAME);
            evt.Data[ID_KEY] = playerId;
            evt.Data[DIRECTION_KEY] = DIRECTION_UP;
            evt.Data[IS_MOVE_KEY] = true;
            m_eventBus.TriggerEvent(evt);
        }
        if (Input.GetKeyDown("down"))
        {
            Event evt = new Event(MOVE_EVENT_NAME);
            evt.Data[ID_KEY] = playerId;
            evt.Data[DIRECTION_KEY] = DIRECTION_DOWN;
            evt.Data[IS_MOVE_KEY] = true;
            m_eventBus.TriggerEvent(evt);
        }
        if (Input.GetKeyDown("left"))
        {
            Event evt = new Event(MOVE_EVENT_NAME);
            evt.Data[ID_KEY] = playerId;
            evt.Data[DIRECTION_KEY] = DIRECTION_LEFT;
            evt.Data[IS_MOVE_KEY] = true;
            m_eventBus.TriggerEvent(evt);
        }
        if (Input.GetKeyDown("right"))
        {
            Event evt = new Event(MOVE_EVENT_NAME);
            evt.Data[ID_KEY] = playerId;
            evt.Data[DIRECTION_KEY] = DIRECTION_RIGHT;
            evt.Data[IS_MOVE_KEY] = true;
            m_eventBus.TriggerEvent(evt);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour {

    private EventBus m_eventBus;

    public const string TYPE_KEY = "type";
    public const string NAME_KEY = "name";

    public const string PRESS = "press";
    public const string RELEASE = "release";

    public const string ARROW_UP = "up";
    public const string ARROW_DOWN = "down";
    public const string ARROW_LEFT = "left";
    public const string ARROW_RIGHT = "right";

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
        if (Input.GetKeyUp(ARROW_UP))
        {
            Event evt = new Event(Events.KEYBOARD_EVENT);
            evt.Data[TYPE_KEY] = RELEASE;
            evt.Data[NAME_KEY] = ARROW_UP;
            m_eventBus.TriggerEvent(evt);
        }
        if (Input.GetKeyUp(ARROW_DOWN))
        {
            Event evt = new Event(Events.KEYBOARD_EVENT);
            evt.Data[TYPE_KEY] = RELEASE;
            evt.Data[NAME_KEY] = ARROW_DOWN;
            m_eventBus.TriggerEvent(evt);
        }
        if (Input.GetKeyUp(ARROW_LEFT))
        {
            Event evt = new Event(Events.KEYBOARD_EVENT);
            evt.Data[TYPE_KEY] = RELEASE;
            evt.Data[NAME_KEY] = ARROW_LEFT;
            m_eventBus.TriggerEvent(evt);
        }
        if (Input.GetKeyUp(ARROW_RIGHT))
        {
            Event evt = new Event(Events.KEYBOARD_EVENT);
            evt.Data[TYPE_KEY] = RELEASE;
            evt.Data[NAME_KEY] = ARROW_RIGHT;
            m_eventBus.TriggerEvent(evt);
        }
    }

    private void HandleKeysDown()
    {
        if (Input.GetKeyDown(ARROW_UP))
        {
            Event evt = new Event(Events.KEYBOARD_EVENT);
            evt.Data[TYPE_KEY] = PRESS;
            evt.Data[NAME_KEY] = ARROW_UP;
            m_eventBus.TriggerEvent(evt);
        }
        if (Input.GetKeyDown(ARROW_DOWN))
        {
            Event evt = new Event(Events.KEYBOARD_EVENT);
            evt.Data[TYPE_KEY] = PRESS;
            evt.Data[NAME_KEY] = ARROW_DOWN;
            m_eventBus.TriggerEvent(evt);
        }
        if (Input.GetKeyDown(ARROW_LEFT))
        {
            Event evt = new Event(Events.KEYBOARD_EVENT);
            evt.Data[TYPE_KEY] = PRESS;
            evt.Data[NAME_KEY] = ARROW_LEFT;
            m_eventBus.TriggerEvent(evt);
        }
        if (Input.GetKeyDown(ARROW_RIGHT))
        {
            Event evt = new Event(Events.KEYBOARD_EVENT);
            evt.Data[TYPE_KEY] = PRESS;
            evt.Data[NAME_KEY] = ARROW_RIGHT;
            m_eventBus.TriggerEvent(evt);
        }
    }
}

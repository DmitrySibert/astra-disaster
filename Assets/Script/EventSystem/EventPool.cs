using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A pool for event instances
/// </summary>
public class EventPool {

    private Dictionary<string, Func<Event>> m_evtCreators;

    public EventPool(String[] eventTypes)
    {
        m_evtCreators = new Dictionary<string, Func<Event>>();
        foreach(String evtType in eventTypes)
        {
            m_evtCreators[evtType] = () =>
            {
                Event evt = new Event(evtType);
                return evt;
            };
        }
    }

    public Event GetEvent(string evtType)
    {
        return m_evtCreators[evtType].Invoke();
    }
}

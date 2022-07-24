using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventDispatcher : MonoBehaviour
{
    #region Singleton
    static EventDispatcher s_instance;
    public static EventDispatcher instance
    {
        get
        {
            if (s_instance == null)
            {
                GameObject singletonObject = new GameObject();
                s_instance = singletonObject.AddComponent<EventDispatcher>();
                singletonObject.name = "Singleton - EventDispatcher";
            }
            return s_instance;
        }
        private set
        {

        }
    }
    private void Awake()
    {
        if (s_instance !=null && s_instance.GetInstanceID() != this.GetInstanceID())
        {
            Destroy(gameObject);
        }
        else
        {
            s_instance = this as EventDispatcher;
        }
    }
    private void OnDestroy()
    {
        if (s_instance == this)
        {
            ClearAllListener();
            s_instance = null;
        }
    }
    #endregion
    #region Fields
    Dictionary<EventID, Action<object>> listeners = new Dictionary<EventID, Action<object>>();
    #endregion
    #region Add Listeners, Post Events, Remove listeners

    public void RegisterListener(EventID eventID, Action<object> callback)
    {
        if (listeners.ContainsKey(eventID))
        {
            listeners[eventID] += callback;
        }
        else
        {
            listeners.Add(eventID,null);
            listeners[eventID] += callback;
        }
    }
    public void PostEvent(EventID eventID, object param = null)
    {
        if (!listeners.ContainsKey(eventID))
        {
            return;
        }
        var callback = listeners[eventID];
        if (callback != null)
        {
            callback(param);
        }
        else
        {
            listeners.Remove(eventID);
        }
    }
    public void RemoveListener(EventID eventID, Action<object> callback)
    {
        if (listeners.ContainsKey(eventID))
        {
            listeners[eventID] -= callback;
        }
        else
        {
            return;
        }
    }
    public void ClearAllListener()
    {
        listeners.Clear();
    }
    #endregion
}
#region Extension class
public static class EventDispatcherExtension
{
    public static void RegisticListener(this MonoBehaviour listener, EventID eventID, Action<object> callback)
    {
        EventDispatcher.instance.RegisterListener(eventID, callback);
    }

    public static void PostEvent(this MonoBehaviour listener, EventID eventID, object param)
    {
        EventDispatcher.instance.PostEvent(eventID, param);
    }
    public static void PostEvent(this MonoBehaviour listener, EventID eventID)
    {
        EventDispatcher.instance.PostEvent(eventID, null);
    }
}

#endregion

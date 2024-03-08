using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class GameEvent : MonoBehaviour
{
    public static List<GameEvent> gameEvents = new List<GameEvent>();

    [TabGroup("Data")] public string lookupTag = "N/A";
    [TabGroup("Data")] public UnityEvent onInvokeEvent = new UnityEvent();

    private void Start()
    {
        gameEvents.Add(this);
    }

    [TabGroup("Tools")]
    [Button]
    public void DoInvoke()
    {
        onInvokeEvent.Invoke();
    }
}

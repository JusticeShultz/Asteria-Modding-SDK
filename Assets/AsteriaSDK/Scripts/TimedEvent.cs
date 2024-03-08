using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedEvent : MonoBehaviour
{
    public float timeUntilEvent = 5f;
    public UnityEvent onTimerEnd = new UnityEvent();
    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timeUntilEvent)
        {
            try
            {
                onTimerEnd?.Invoke();
            }
            catch
            {

            }

            timer = 0f;
            enabled = false;
        }
    }
}

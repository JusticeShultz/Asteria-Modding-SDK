using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimedTooltip : MonoBehaviour
{
    public bool alive = true;
    public float lifetimeMax = 5f;
    public float lifetime = 5f;
    public GameObject toDestroy;
    public float destroyDelay = 1f;
    public Image lifetimeBar;
    public UnityEvent onDestroy = new UnityEvent();

    void Update()
    {
        if (lifetime > 0f)
        {
            lifetime -= Time.deltaTime;

            if(lifetime <= 0f)
            {
                alive = false;
                onDestroy.Invoke();
                Destroy(toDestroy, destroyDelay);
            }
        }

        lifetimeBar.color = new Color(lifetimeBar.color.r, lifetimeBar.color.g, lifetimeBar.color.b, 1 - (lifetime / lifetimeMax));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DestroyObject : MonoBehaviour
{
    [TabGroup("Data")] public GameObject toDestroy;
    [TabGroup("Data")] public float timedDestroy = 0.01f;

    [TabGroup("Tools")]
    [Button]
    public void DestroyToBeDestroyed()
    {
        if(toDestroy != null)
            Destroy(toDestroy, timedDestroy);
    }

    [TabGroup("Tools")]
    [Button]
    public void DestroyTarget(GameObject target)
    {
        if(target != null)
            Destroy(target, timedDestroy);
    }

    [TabGroup("Tools")]
    [Button]
    public void DestroyTargetTimed(GameObject target, float time)
    {
        if(target != null)
            Destroy(target, time); 
    }
}

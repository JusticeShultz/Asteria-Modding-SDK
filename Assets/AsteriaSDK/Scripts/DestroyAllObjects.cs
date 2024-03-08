using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllObjects : MonoBehaviour
{
    public List<GameObject> toDestroy = new List<GameObject>();

    public void DestroyAll()
    {
        foreach(GameObject obj in toDestroy)
        {
            if(obj != null)
                Destroy(obj);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//One way data container to hold a collection of references that would otherwise require get component lookups.
//Created with the purpose of modification over time and reusability.
public class ReferenceHook : MonoBehaviour
{
    public GameObject obj;
    public UnityEngine.UI.Image img;
    public UnityEngine.UI.Image fill;

    public List<ReferenceHook> otherHooks = new List<ReferenceHook>();
}

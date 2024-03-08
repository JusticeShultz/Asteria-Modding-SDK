using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SetAnimatorBool : MonoBehaviour
{
    [TabGroup("Data")] public string animatorBool = "None";
    [TabGroup("Data")] public Animator target = null;

    [TabGroup("Tools")]
    [Button]
    public void SetAnimBool(bool state)
    {
        if (target != null)
            target.SetBool(animatorBool, state);
    }
}

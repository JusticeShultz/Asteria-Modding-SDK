using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SetDialogueTransitionPause : MonoBehaviour
{
    [Button]
    public void TransitionalPause(float length)
    {
        DialogueManager.Instance.transitionDelay = length;
    }
}
 
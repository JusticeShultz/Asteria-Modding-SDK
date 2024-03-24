using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Sirenix.OdinInspector.HideMonoScript]
[CreateAssetMenu(fileName = "DefaultLanguage", menuName = "Asteria/Language", order = 1)]
public class Language : ScriptableObject
{
    public string nameOfLanguage = "Default Language";
    [TextArea] public string flavorText = "This Language was probably made by goblins...";
    [Tooltip("Might never be used, leave null by default.")] public Sprite flavorImage = null;
}
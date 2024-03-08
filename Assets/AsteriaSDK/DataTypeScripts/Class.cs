using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "DefaultClass", menuName = "Asteria/Class", order = 2)]
public class Class : ScriptableObject
{
    [TabGroup("Class Data")] public string className = "Default Class";
    [TabGroup("Class Data")][TextArea] public string flavorText = "This class does absolutely nothing...";
    [TabGroup("Class Data")][Tooltip("Might never be used, leave null by default.")] public Sprite itemImage = null;

    [TabGroup("Class Data")][Tooltip("The languages this class starts with.")] public List<Language> startingReadableLanguages = new List<Language>();
    [TabGroup("Class Data")][Tooltip("The languages this class starts with.")] public List<Language> startingSpeakableLanguages = new List<Language>();
    [TabGroup("Class Data")][Tooltip("The skills this class starts with.")] public List<Skill> innateSkills = new List<Skill>();
    [TabGroup("Class Data")][SerializeField] public List<SerializedItem> startingInventory = new List<SerializedItem>();

    [TabGroup("Modifier Data")] public List<GeneratedModifiedStat> modifiedStats = new List<GeneratedModifiedStat>();

    public List<GeneratedModifiedStat> GetModifier()
    {
        return null;
    }
}
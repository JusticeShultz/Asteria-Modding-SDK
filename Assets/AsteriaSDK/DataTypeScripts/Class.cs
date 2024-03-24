using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[HideMonoScript]
[CreateAssetMenu(fileName = "DefaultClass", menuName = "Asteria/Class", order = 2)]
public class Class : ScriptableObject
{
    [TabGroup("Class Data")] public string className = "Default Class";
    [TabGroup("Class Data")] [TextArea] public string flavorText = "This class does absolutely nothing...";
    [TabGroup("Class Data")] [Tooltip("Might never be used, leave null by default.")] public Sprite itemImage = null;

    //[TabGroup("Modifier Data")] [Tooltip("A modifier that can change just about anything in the game, however it is mostly used to make simple stat changes")] [SerializeField] private ScriptableObject innateModifier;

    //Subject to change and additions
    //should probably remove this section
    //[Header("Innate Skill Points (BROKEN USE INATE PASSIVE INSTEAD)")]
    //[Tooltip("physical damage, max stamina, health, carry weight")] public int strength = 0;
    //[Tooltip("health, natural resistance, natural armor")] public int constitution = 0;
    //[Tooltip("physical damage, max stamina, dodge chance, crit chance")] public int dexterity = 0;
    //[Tooltip("magic damage, problem solving, ability to read other languages")] public int intelligence = 0;
    //[Tooltip("ability to detect ambushes better, ability to avoid traps, ability to find hidden items")] public int awareness = 0;
    //[Tooltip("ability to lead ambushes on enemies or bypass them, chance to steal unnoticed increased, increases crit chance past 8 points")] public int stealth = 0;
    //[Tooltip("increases summon limits, increases max mana, increases magical damage")] public int arcana = 0;
    //[Tooltip("increased item find, increased rarity chances, increased critical strike")] public int luck = 0;
    //[Tooltip("decides when you get a turn to fight, does not level like other skill points")] public int initiative = 0;
    //[Tooltip("adds max carry weight, does not level like other skill points")] public int muscle = 0;
    //[Tooltip("adds physical and magical defence, innate skill, doesn't level")] public int brawn = 0;
    //[Header("This should add up to 12 to balance all classes.")] ignore this

    [TabGroup("Class Data")] [Tooltip("The languages this class starts with.")] public List<Language> startingReadableLanguages = new List<Language>();
    [TabGroup("Class Data")] [Tooltip("The languages this class starts with.")] public List<Language> startingSpeakableLanguages = new List<Language>();
    [TabGroup("Class Data")] [Tooltip("The skills this class starts with.")] public List<Skill> innateSkills = new List<Skill>();
    [TabGroup("Class Data")] [SerializeField] public List<SerializedItem> startingInventory = new List<SerializedItem>(); //Does not include starter quest items, just basics like weapon, spells, potions, etc.

    [TabGroup("Modifier Data")] public List<GeneratedModifiedStat> modifiedStats = new List<GeneratedModifiedStat>();

    public List<GeneratedModifiedStat> GetModifier()
    {
        return modifiedStats;
    }

    //public void OnValidate()
    //{
    //    if(!(innateModifier is Modifier) && innateModifier != null)
    //    {
    //        innateModifier = null;
    //        throw new System.Exception("innateModifier MUST impliment the IModifier interface or be null. For reference, BasicModifierTemplate will work here");
    //    }
    //}
}
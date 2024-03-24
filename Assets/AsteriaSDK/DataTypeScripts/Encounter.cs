using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

//Condensed because dialogue, combat and events have been changed to be much more modular and handle most of the heavy lifting.
public enum EncounterType
{
    Combat,
    Dialogue,
    Event
    //GiveQuest,
    //FindItem,
    //FindLocation
}

//This is used to reference any valid stat. Not every stat works for every scenario (e.g. missing stats in the modifier system), but for the most part it should work modularly between systems which need to reference stats.
public enum InteractionStat
{
    Strength, Constitution, Dexterity, Intelligence, Awareness, Stealth, Arcana, Luck, Initiative, Muscle, Brawn, Armor, MagicResist, CritDamageMultiplier, CurrentSkillPointsAvailable, Level,
    MaxHealth, MissingHealth, MaxMana, MissingMana, MaxStamina, MissingStamina, MaxEnergy, MissingEnergy, AttackSpeed, CooldownReduction, MaxCarryWeight, CurrentXP, PostCombatXPSaved, CurrentExhaustion,
    MaxExhaustion, CurrentHunger, MaxHunger, CurrentThirst, MaxThirst, ConsumableStrength, PhysicalDamageMultiplier, MagicDamageMultiplier, OverallDamageMultiplier, MaxCompanions, PhysicalDamage, MagicDamage, CurrentCompanions,
    MaxHealthRegeneration, FlatHealthRegeneration, MaxStaminaRegeneration, FlatStaminaRegeneration, MaxManaRegeneration, FlatManaRegeneration
}

//This is used to determine how to compare a stat value.
public enum Comparator
{
    IsGreaterThanOrEqualTo, IsGreaterThan, IsLessThanOrEqualTo, IsLessThan, IsEqualTo
}

public enum TabType
{
    None, Combat, Exploration, Camp, Inventory, Merchant, Dialogue
}

//This is used to store the 3 data objects required to check a stat.
[System.Serializable]
public class StatRequirement
{
    public InteractionStat statToCompare;
    public Comparator howToCompare;
    public float compareTo;
}

[System.Serializable]
public class InteractionRequirement
{
    public List<string> requiredStoryFlags = new List<string>();
    public List<string> cannotHaveStoryFlags = new List<string>();
    public List<Language> requiredLanguages = new List<Language>();
    public List<string> requiredLanguageIds = new List<string>();
    public List<Skill> requiredSkills = new List<Skill>();
    public List<string> requiredSkillIds = new List<string>();
    public List<ItemStack> requiredItems = new List<ItemStack>();
    public List<ItemIDStack> requiredItemIds = new List<ItemIDStack>();
    public List<string> completedQuests = new List<string>();
    public string weatherRequired = "None";
    public Vector2 timeRange = new Vector2(0, 24);
    public Vector2 temperatureRange = new Vector2(-9999, 9999);
    public Vector2 dayRange = new Vector2(-9999, 9999);
    public Vector2 monthRange = new Vector2(-9999, 9999);
    public Vector2 yearRange = new Vector2(-999999, 999999);
    public List<StatRequirement> statRequirements;
    public List<Sprite> requiredBackgroundImage = new List<Sprite>();
    public List<string> requiredBackgroundImageIds = new List<string>();
    public Location requiredLocation = null;
    public string requiredLocationID = "";
    public TabType requiredTab = TabType.None;
    public int requiredLevel = 0;
}

[HideMonoScript]
[CreateAssetMenu(fileName = "New Encounter", menuName = "Asteria/Encounter", order = 11)]
public class Encounter : ScriptableObject
{
    //Something like mistyvalewoods_skeletons_4 would be optimal so we know that in Mistyvale woods we are fighting 4 skeletons.
    [TabGroup("Data")] public string encounterName; //Used as an ID for lookups as well as a story flag. Spaces are allowed but not recommended.

    [TabGroup("Time")] public bool encounterPassesTime = true;
    [TabGroup("Time")] public int minutesPassed = 0;
    [TabGroup("Time")] public int hoursPassed = 1;

    //Although this is a list so you can add multiple different types, I highly recommend sticking to 1. The dialogue system can do just about anything.
    [TabGroup("Data")] public List<EncounterType> encounterTypes; //Determines how the encounters function and what systems it runs.
    
    [TabGroup("Data")] public float encounterWeight = 10f;

    [TabGroup("Requirements")] public InteractionRequirement interactionRequirements;

    //Encounter data
    [TabGroup("Backgrounds")] public bool rerollCurrentBackground = true;
    [TabGroup("Backgrounds")] public List<Sprite> overrideBackground = new List<Sprite>();

    [TabGroup("Data")] public bool oneTimeEncounterStoryFlag = false; //If this is a one time encounter then flag this true and a story flag with the encounter name will be set.
    [TabGroup("Data")] public string triggeredEvent = "None";
    [TabGroup("Data")] public Dialogue dialogueStarter;
    [TabGroup("Data")] public string dialogueStartedID;
    [TabGroup("Data")] public List<UsageTag> usageTags = new List<UsageTag>(); //Makes use of the usage tag system to allow more control to designers for encounters.
    [TabGroup("Data")] public List<Monster> encounteredMonsters = new List<Monster>();
    [TabGroup("Data")] public List<string> encounteredMonstersID = new List<string>();
    [TabGroup("Data")] public List<string> storyFlagsAdded = new List<string>();
}

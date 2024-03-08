using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

public enum EncounterType
{
    Combat,
    Dialogue,
    Event
}

public enum InteractionStat
{
    Strength, Constitution, Dexterity, Intelligence, Awareness, Stealth, Arcana, Luck, Initiative, Muscle, Brawn, Armor, MagicResist, CritDamageMultiplier, CurrentSkillPointsAvailable, Level,
    MaxHealth, MissingHealth, MaxMana, MissingMana, MaxStamina, MissingStamina, MaxEnergy, MissingEnergy, AttackSpeed, CooldownReduction, MaxCarryWeight, CurrentXP, PostCombatXPSaved, CurrentExhaustion,
    MaxExhaustion, CurrentHunger, MaxHunger, CurrentThirst, MaxThirst, ConsumableStrength, PhysicalDamageMultiplier, MagicDamageMultiplier, OverallDamageMultiplier, MaxCompanions, PhysicalDamage, MagicDamage, CurrentCompanions,
    MaxHealthRegeneration, FlatHealthRegeneration, MaxStaminaRegeneration, FlatStaminaRegeneration, MaxManaRegeneration, FlatManaRegeneration
}

public enum Comparator
{
    IsGreaterThanOrEqualTo, IsGreaterThan, IsLessThanOrEqualTo, IsLessThan, IsEqualTo
}

public enum TabType
{
    None, Combat, Exploration, Camp, Inventory, Merchant, Dialogue
}

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

    public bool AllRequirementsMet()
    {
        return false;
    }

    public bool StatRequirementsMet(UnitStats stats)
    {
        return false;
    }

    public bool StatRequirementMet(StatRequirement statRequirement, UnitStats stats)
    {
        return false;
    }

    public int AllRequirementsNotMet()
    {
        return 0;
    }

    public int TotalRequirements()
    {
        return 0;
    }
}

[CreateAssetMenu(fileName = "New Encounter", menuName = "Asteria/Encounter", order = 11)]
public class Encounter : ScriptableObject
{
    [TabGroup("Data")] public string encounterName;

    [TabGroup("Time")] public bool encounterPassesTime = true;
    [TabGroup("Time")] public int minutesPassed = 0;
    [TabGroup("Time")] public int hoursPassed = 1;

    [TabGroup("Data")] public List<EncounterType> encounterTypes;

    [TabGroup("Data")] public float encounterWeight = 10f;

    [TabGroup("Requirements")] public InteractionRequirement interactionRequirements;

    //Encounter data
    [TabGroup("Backgrounds")] public bool rerollCurrentBackground = true;
    [TabGroup("Backgrounds")] public List<Sprite> overrideBackground = new List<Sprite>();

    [TabGroup("Data")] public bool oneTimeEncounterStoryFlag = false;
    [TabGroup("Data")] public string triggeredEvent = "None";
    [TabGroup("Data")] public Dialogue dialogueStarter;
    [TabGroup("Data")] public string dialogueStartedID;
    [TabGroup("Data")] public List<UsageTag> usageTags = new List<UsageTag>();
    [TabGroup("Data")] public List<Monster> encounteredMonsters = new List<Monster>();
    [TabGroup("Data")] public List<string> encounteredMonstersID = new List<string>();
    [TabGroup("Data")] public List<string> storyFlagsAdded = new List<string>();
}

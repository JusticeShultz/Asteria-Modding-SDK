using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum MonsterRarity
{
    Common, Elite, Legendary, Boss, Mythic, Unique, Quest
}

[CreateAssetMenu(fileName = "FeebleGoblin", menuName = "Asteria/Monster", order = 4)]
public class Monster : ScriptableObject
{
    [Tooltip("The name of this monster. Do not use markup in this name.")]
    [TabGroup("Basic Data")]
    public string nameOfMonster = "Feeble Goblin";
    [TabGroup("Basic Data")]
    [Tooltip("The text to be used on the display, this can include <> text animators and html markup.")]
    public string displayName = "Feeble Goblin";

    [TabGroup("Basic Data")]
    [TextArea] public string flavorText = "This goblin has very little strength left, it's on the brink of death and starvation.";
    [TabGroup("Basic Data")]
    [Tooltip("Icons that represent the monster. Using more than 1 will result in a random selection.")] public List<Sprite> icons = new List<Sprite>();

    [TabGroup("Balance Data")][Tooltip("The system determines monster level. Only tune this if you are sure you want to add difficulty.")] public float addedLevelDifficulty = 1;
    [TabGroup("Balance Data")] public int innateIncreasedLevel = 0;
    [TabGroup("Balance Data")] public float maxHealth = 2f;
    [TabGroup("Balance Data")] public float minHealth = 0.65f;
    [TabGroup("Balance Data")] public float baseMana = 5;
    [TabGroup("Balance Data")] public float baseStamina = 15;

    [TabGroup("Balance Data")] public float maxHealthPerLevel = 2;
    [TabGroup("Balance Data")] public float maxHealthPerStrength = 2;
    [TabGroup("Balance Data")] public float maxHealthPerConstitution = 3;
    [TabGroup("Balance Data")] public float maxManaPerLevel = 0.5f;
    [TabGroup("Balance Data")] public float maxManaPerArcana = 1.25f;
    [TabGroup("Balance Data")] public float maxManaPerIntelligence = 0.25f;
    [TabGroup("Balance Data")] public float maxStaminaPerLevel = 0.5f;
    [TabGroup("Balance Data")] public float maxStaminaPerStrength = 0.25f;
    [TabGroup("Balance Data")] public float maxStaminaPerDexterity = 1.25f;
    [TabGroup("Balance Data")] public float physicalDamageFromStrength = 0.5f;
    [TabGroup("Balance Data")] public float physicalDamageFromDexterity = 0.15f;
    [TabGroup("Balance Data")] public float magicDamageFromIntelligence = 0.5f;
    [TabGroup("Balance Data")] public float magicDamageFromArcana = 0.15f;
    [TabGroup("Balance Data")] public float baseHealthRegeneration_Flat = 0f;
    [TabGroup("Balance Data")] public float baseHealthRegeneration_Max = 0f;
    [TabGroup("Balance Data")] public float baseStaminaRegeneration_Flat = 0f;
    [TabGroup("Balance Data")] public float baseStaminaRegeneration_Max = 0f;
    [TabGroup("Balance Data")] public float baseManaRegeneration_Flat = 0f;
    [TabGroup("Balance Data")] public float baseManaRegeneration_Max = 0f;

    [TabGroup("Balance Data")] public MagicElement element;
    [TabGroup("Balance Data")] public string elementId;

    [TabGroup("Loot Data")] public bool canDropLoot = true;
    [TabGroup("Loot Data")] public bool canDropRareLoot = true;
    [TabGroup("Loot Data")] public bool canDropCurrency = true;
    [TabGroup("Loot Data")] public bool canDropXP = true;
    [TabGroup("Loot Data")] public bool isBossMonster = false;
    [TabGroup("Loot Data")] public bool isWorldBoss = false;
    [TabGroup("Loot Data")] public bool isFloorGuardian = false;
    [TabGroup("Loot Data")] public bool isNamedMonster = false;
    [TabGroup("Loot Data")] public bool dieOutOfCombat = false;
    [TabGroup("Loot Data")] public LootPool lootPool;
    [TabGroup("Loot Data")] public string lootPoolID;

    [TabGroup("Display Data")] public MonsterRarity monsterRarity = MonsterRarity.Common;
    [TabGroup("Display Data")] public bool displayHealth = true;
    [TabGroup("Display Data")] public bool displayStamina = true;
    [TabGroup("Display Data")] public bool displayMana = false;
    [TabGroup("Display Data")] public MonsterClassification monsterClassification = MonsterClassification.Unit;

    [TabGroup("Balance Data")][Tooltip("physical damage, health")] public int strength = 0;
    [TabGroup("Balance Data")][Tooltip("health, natural resistance, natural armor")] public int constitution = 0;
    [TabGroup("Balance Data")][Tooltip("physical damage, dodge chance, crit chance, max stamina")] public int dexterity = 0;
    [TabGroup("Balance Data")][Tooltip("magic damage, problem solving, ability to read other languages")] public int intelligence = 0;
    [TabGroup("Balance Data")][Tooltip("ability to detect ambushes better, ability to avoid traps, ability to find hidden items")] public int awareness = 0;
    [TabGroup("Balance Data")][Tooltip("ability to lead ambushes on enemies or bypass them, chance to steal unnoticed increased")] public int stealth = 0;
    [TabGroup("Balance Data")][Tooltip("increases summon limits, increases max mana, increases magical damage")] public int arcana = 0;
    [TabGroup("Balance Data")][Tooltip("increased item find, increased rarity chances, increased critical strike")] public int luck = 0;
    [TabGroup("Balance Data")][Tooltip("decides when the monster gets a turn to fight")] public int initiative = 3; //This will instead be used as charisma.
    [TabGroup("Balance Data")][Tooltip("adds max carry weight, does not level like other skill points")] public int muscle = 0;
    [TabGroup("Balance Data")][Tooltip("adds physical and magical defence, innate skill, doesn't level")] public int brawn = 0;
    [TabGroup("Balance Data")] public float minDelayBetweenActions = 0.5f;
    [TabGroup("Balance Data")] public float maxDelayBetweenActions = 2.0f;

    [TabGroup("Balance Data")] public int innatePhysicalArmor = 0;
    [TabGroup("Balance Data")] public int innateMagicalArmor = 0;
    [TabGroup("Balance Data")] public float critDamageMultiplier = 1.25f;
    [TabGroup("Balance Data")] public int innateCritChance = 3;
    [TabGroup("Balance Data")] public List<AppliableStatusEffect> startingStatusEffects = new List<AppliableStatusEffect>();

    [Tooltip("Dictates any additional effects that happen upon death.")]
    [TabGroup("Balance Data")] public List<UsageTag> killTags = new List<UsageTag>();

    [TabGroup("Balance Data")] public List<Skill> innateSkills = new List<Skill>();
    [TabGroup("Balance Data")] public List<string> innateSkillIds = new List<string>();

    [TabGroup("Balance Data")] public List<Language> innateLanguages = new List<Language>();
    [TabGroup("Balance Data")] public List<string> innateLanguageIds = new List<string>();

    [TabGroup("AI Data")] public bool overrideAISkillUsageWeights = false;
    [TabGroup("AI Data")] public List<AIHelper> MaxHealthWeights = new List<AIHelper>();
    [TabGroup("AI Data")] public List<AIHelper> QuarterHealthWeights = new List<AIHelper>();
    [TabGroup("AI Data")] public List<AIHelper> HalfHealthWeights = new List<AIHelper>();
    [TabGroup("AI Data")] public List<AIHelper> AboveHalfHealthWeights = new List<AIHelper>();

    [TabGroup("Companion Data")] public bool canObtainXP = false;
    [TabGroup("Companion Data")] public bool evolves = false;
    [TabGroup("Companion Data")][ShowIf("evolves", true)] public int evolutionLevel = 10;
    [TabGroup("Companion Data")][ShowIf("evolves", true)] public Monster evolution;
    [TabGroup("Companion Data")][ShowIf("evolves", true)] public string evolutionId;

    [TabGroup("Companion Data")][ShowIf("evolves", true)] public bool evolvesToSameLevel = false;
    [TabGroup("Companion Data")][ShowIf("evolves", true)] public int afterEvolutionLevel = 5;
}
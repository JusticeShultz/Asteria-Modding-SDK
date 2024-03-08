using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public enum Rarity
{
    Override,
    Trash,
    Mundane,
    Common,
    Uncommon,
    Rare,
    Mythic,
    Legendary,
    Unique, Ascendant,
    Demonic, Angelic,
    Immortal,
    Celestial,
    Titan
}

public enum RarityTier
{
    I,
    II,
    III,
    IV,
    V,
    VI,
    VII,
    VIII,
    IX,
    X
}

[Serializable] public class SerializedSkill
{
    public Skill baseSkill;
    
    public float maxCooldownAfterModifiers
    {
        get
        {
            return 0;
        }
    }

    public float currentCooldown = 0f;
    
    public SerializedSkill(Skill inputSkill)
    {
    }
}

[Serializable]
public class SerializedItem
{
    public Item itemTemplate;
    public int level = 1;
    public float rarityModValue = 1f;
    public float currentDurability = 1f;
    public Rarity itemRarity = Rarity.Common;
    public int stackCount;
    public string stackID;
    public List<GeneratedModifiedStat> generatedModifiedStats = new List<GeneratedModifiedStat>();
    public bool isBeingSold = false;

    public SerializedItem(string ID)
    {
    }

    public SerializedItem(Item itemTemp, string ID)
    {
    }

    public SerializedItem(Item itemTemp, int itemLevel, Rarity rarity, string ID, float rarityModVal = 1f)
    {
    }

    public SerializedItem(Item _itemTemplate, int _level, float _rarityModValue, Rarity _rarity, int _count, string ID)
    {
    }

    public void ModifyStat(InteractionStat stat, ref int value)
    {
    }

    public void ModifyStat(InteractionStat stat, ref float value)
    {
    }

    public void RegenerateStats()
    {
    }
}

[Serializable]
public class SerializedQuest
{
    public Quest baseQuest = null;
    public float currentGoal = 100;
    public float currentProgress = 100;

    public SerializedQuest()
    {
    }

    public SerializedQuest(Quest _baseQuest)
    {
    }

    public string GetProgressStatus()
    {
        return "";
    }

    public void CheckQuestCompleted()
    {
    }
}

[Serializable] public class AppliableStatusEffect
{
    public StatusEffect statusEffect;
    public float strengthOfEffect;
    public float lifetime = -1;
    public float startingLifetime = -1;
    public bool active = true;
    public bool usesLifetime = true;
    public List<GameObject> linkedIcons = new List<GameObject>();
    public UnitStats self;
    public UnitStats target;
    public ReferenceHook referenceHook;
    public float tickUsageTagsDelay = 0f;
    public List<GeneratedModifiedStat> generatedModifierStats = new List<GeneratedModifiedStat>();

    public AppliableStatusEffect(StatusEffect effect = null, float lastingTime = -1, float effectStrength = 1.0f, UnitStats _self = null, UnitStats _target = null)
    {
    }

    public void TickLifetime()
    {
    }

    public void AddLifetime(float amount)
    {
    }
}

[System.Serializable] public class SavedCompanion
{
    [TabGroup("Unit Data", "Data")] public UnitClassification unitType = UnitClassification.Enemy;
    [TabGroup("Unit Data", "Data")] public string unitName = "Unknown";
    [TabGroup("Unit Data", "Data")] [SerializeField] public List<AppliableStatusEffect> statusEffects = new List<AppliableStatusEffect>();
    [TabGroup("Unit Data", "Data")] public SerializedItem[] equippedItems = new SerializedItem[14];
    [TabGroup("Unit Data", "Data")] public List<SerializedSkill> serializedSkillSlots = new List<SerializedSkill>();
    [TabGroup("Unit Data", "Data")] public List<Skill> skillSlots = new List<Skill>();
    [TabGroup("Unit Data", "Data")] public List<GeneratedModifiedStat> modifiers = new List<GeneratedModifiedStat>();
    [TabGroup("Unit Data", "Data")] public Class currentClass;
    [TabGroup("Unit Data", "Data")] public Skill restSkill;
    [TabGroup("Unit Data", "Data")] public Skill fleeSkill;
    [TabGroup("Unit Data", "Data")] public SerializedSkill serializedRestSkill;
    [TabGroup("Unit Data", "Data")] public SerializedSkill serializedFleeSkill;
    [TabGroup("Unit Data", "Data")] public MagicElement attunedMagicElement;
    [TabGroup("Unit Data", "Stats")] public int baseStrength = 0;
    [TabGroup("Unit Data", "Stats")] public int baseConstitution = 0;
    [TabGroup("Unit Data", "Stats")] public int baseDexterity = 0;
    [TabGroup("Unit Data", "Stats")] public int baseIntelligence = 0;
    [TabGroup("Unit Data", "Stats")] public int baseAwareness = 0;
    [TabGroup("Unit Data", "Stats")] public int baseStealth = 0;
    [TabGroup("Unit Data", "Stats")] public int baseArcana = 0;
    [TabGroup("Unit Data", "Stats")] public int baseLuck = 0;
    [TabGroup("Unit Data", "Stats")] public int baseInitiative = 0;
    [TabGroup("Unit Data", "Stats")] public int baseMuscle = 0;
    [TabGroup("Unit Data", "Stats")] public int baseBrawn = 0;
    [TabGroup("Unit Data", "Stats")] public int baseArmor = 0;
    [TabGroup("Unit Data", "Stats")] public int baseMagicResist = 0;
    [TabGroup("Unit Data", "Stats")] public int baseCritDamageMultiplier = 0;
    [TabGroup("Unit Data", "Stats")] public int currentSkillPointsAvailable = 0;
    [TabGroup("Unit Data", "Stats")] public int level = 1;
    [TabGroup("Unit Data", "Stats")] public float baseMaxHealth = 1f;
    [TabGroup("Unit Data", "Stats")] public float missingHealth = 0f;
    [TabGroup("Unit Data", "Stats")] public float baseMaxMana = 1f;
    [TabGroup("Unit Data", "Stats")] public float missingMana = 0f;
    [TabGroup("Unit Data", "Stats")] public float baseMaxStamina = 1f;
    [TabGroup("Unit Data", "Stats")] public float missingStamina = 0f;
    [TabGroup("Unit Data", "Stats")] public float baseMaxEnergy = 95f;
    [TabGroup("Unit Data", "Stats")] public float missingEnergy = 0f;
    [TabGroup("Unit Data", "Stats")] public float baseAttackSpeed = 0.0f;
    [TabGroup("Unit Data", "Stats")] public float baseCooldownReduction = 1.0f;
    [TabGroup("Unit Data", "Stats")] public float baseMaxCarryWeight = 100f;
    [TabGroup("Unit Data", "Stats")] public float currentXP = 0f;
    [TabGroup("Unit Data", "Stats")] public float postCombatXPSaved = 0f;
    [TabGroup("Unit Data", "Stats")] public float currentExhaustion = 125f;
    [TabGroup("Unit Data", "Stats")] public float baseMaxExhaustion = 125f;
    [TabGroup("Unit Data", "Stats")] public float currentHunger = 100f;
    [TabGroup("Unit Data", "Stats")] public float baseMaxHunger = 100f;
    [TabGroup("Unit Data", "Stats")] public float currentThirst = 100f;
    [TabGroup("Unit Data", "Stats")] public float baseMaxThirst = 100f;
    [TabGroup("Unit Data", "Stats")] public float baseConsumableStrength = 1f;
    [TabGroup("Unit Data", "Stats")] public float basePhysicalDamageMultiplier = 1f;
    [TabGroup("Unit Data", "Stats")] public float baseMagicDamageMultiplier = 1f;
    [TabGroup("Unit Data", "Stats")] public float baseOverallDamageMultiplier = 1f;
    [TabGroup("Unit Data", "Stats")] public List<Resistance> elementalResistances = new List<Resistance>();
    [TabGroup("Unit Data", "Stats")] public int baseMaxCompanions = 1;
    [TabGroup("Unit Data", "Stats")] public float currentSlow = 0f;
    [TabGroup("Unit Data", "Stats")] public float currentLockdownTime = 0f;
    [TabGroup("Unit Data", "Stats")] public float currentStunTime = 0f;
    [TabGroup("Unit Data", "Stats")] public float currentSilencedTime = 0f;
    [TabGroup("Unit Data", "Balance")] public float maxHealthPerLevel = 3f;
    [TabGroup("Unit Data", "Balance")] public float maxHealthPerStrength = 2f;
    [TabGroup("Unit Data", "Balance")] public float maxHealthPerConstitution = 4f;
    [TabGroup("Unit Data", "Balance")] public float maxManaPerLevel = 0.5f;
    [TabGroup("Unit Data", "Balance")] public float maxManaPerArcana = 1.5f;
    [TabGroup("Unit Data", "Balance")] public float maxManaPerIntelligence = 0.25f;
    [TabGroup("Unit Data", "Balance")] public float maxStaminaPerLevel = 0.5f;
    [TabGroup("Unit Data", "Balance")] public float maxStaminaPerStrength = 0.25f;
    [TabGroup("Unit Data", "Balance")] public float maxStaminaPerDexterity = 1.5f;
    [TabGroup("Unit Data", "Balance")] public float physicalDamageFromStrength = 0.5f;
    [TabGroup("Unit Data", "Balance")] public float physicalDamageFromDexterity = 0.25f;
    [TabGroup("Unit Data", "Balance")] public float magicDamageFromIntelligence = 1.65f;
    [TabGroup("Unit Data", "Balance")] public float magicDamageFromArcana = 1.05f;
    [TabGroup("Unit Data", "System Set")] public Sprite selectedImage = null;
    [TabGroup("Unit Data", "System Set")] public bool isFriendly = false;
    [TabGroup("Unit Data", "System Set")] public bool alive = true;
    [TabGroup("Unit Data", "System Set")] public float currentActionDelay = 3f;
    [TabGroup("Unit Data", "System Set")] public float livingTime = 0f;
    [TabGroup("Unit Data", "System Set")] public Monster baseMonster;
    [TabGroup("Unit Data", "System Set")] public bool eligibleLootDrop = true;

    public SavedCompanion(Companion initializedCompanion)
    {
    }

    public void Initialize()
    {
    }
}

public class PlayerStats : UnitStats
{
     public static PlayerStats Instance = null;

    [TabGroup("Unit Data", "Data")] [SerializeField] public List<SerializedItem> inventory = new List<SerializedItem>();
    [TabGroup("Unit Data", "Data")] [SerializeField] public List<Location> discoveredLocations = new List<Location>();
    [TabGroup("Unit Data", "Data")] public List<Skill> permanentlyLearnedSkills = new List<Skill>();
    [TabGroup("Unit Data", "Data")] public List<Skill> permanentlyLearnedMantras = new List<Skill>();
    [TabGroup("Unit Data", "Data")] public List<string> assignedSkillPoints = new List<string>();
    [TabGroup("Unit Data", "Data")] public List<string> storyFlags = new List<string>();
    [TabGroup("Unit Data", "Data")] public List<Language> learnedLanguages = new List<Language>();
    [TabGroup("Unit Data", "Data")] public List<string> monstersDefeated = new List<string>();
    [TabGroup("Unit Data", "Settings")] public string currentLocalizationLanguage = "English";
    [TabGroup("Unit Data", "Settings")] public Difficulty difficulty = Difficulty.Standard;
    [TabGroup("Unit Data", "Data")]  public List<Companion> companions = new List<Companion>();
    [TabGroup("Unit Data", "Data")]  public List<SavedCompanion> savedCompanions = new List<SavedCompanion>();
    [TabGroup("Unit Data", "Data")] public int coins = 0;
    [TabGroup("Unit Data", "Data")] public List<SerializedQuest> currentQuests = new List<SerializedQuest>();
    [TabGroup("Unit Data", "Data")] public Queue<Dialogue> pendingQuestCompletionDialogues = new Queue<Dialogue>();
    [TabGroup("Unit Data", "Data")] public List<string> completedQuests = new List<string>();
    //[TabGroup("Unit Data", "Editor References")]  public TextMeshProUGUI healthText;
    //[TabGroup("Unit Data", "Editor References")]  public TextMeshProUGUI manaText;
    //[TabGroup("Unit Data", "Editor References")]  public TextMeshProUGUI staminaText;
    [TabGroup("Unit Data", "Editor References")]  public Image energyBar;
    [TabGroup("Unit Data", "Editor References")]  public Image healthBar;
    [TabGroup("Unit Data", "Editor References")]  public Image staminaBar;
    [TabGroup("Unit Data", "Editor References")]  public Image manaBar;
    [TabGroup("Unit Data", "Editor References")]  public Image healthImg;
    [TabGroup("Unit Data", "Editor References")]  public Image manaImg;
    [TabGroup("Unit Data", "Editor References")]  public Image staminaImg;
    [TabGroup("Unit Data", "Editor References")]  public HoverTextHelper templateDebuff;
    [TabGroup("Unit Data", "Editor References")]  public List<SkillPointObject> skillPointObjects;
    [TabGroup("Unit Data", "Editor References")]  public SkillPointObject skillpointCore;
    [TabGroup("Unit Data", "Events")]  public UnityEngine.Events.UnityEvent onLevelUp = new UnityEngine.Events.UnityEvent();
    [TabGroup("Unit Data", "Events")]  public UnityEngine.Events.UnityEvent onDeath = new UnityEngine.Events.UnityEvent();
    [TabGroup("Unit Data", "Events")]  public UnityEngine.Events.UnityEvent onLongRest = new UnityEngine.Events.UnityEvent();
    [TabGroup("Unit Data", "Events")]  public UnityEngine.Events.UnityEvent onSwapLocalizationLanguage = new UnityEngine.Events.UnityEvent();
    [TabGroup("Unit Data", "Data")] 

    public int currentLevel
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }
    
    [TabGroup("Unit Data", "Balance")] public float BaseXPToLevelUp = 500.0f;
    [TabGroup("Unit Data", "Balance")] public float LevelUpScalingFactor = 1.3f;
    [TabGroup("Unit Data", "Balance")] public float BaseXP = 125.0f;
    [TabGroup("Unit Data", "Balance")] public float LevelScalingFactor = 1.2f;
    [TabGroup("Unit Data", "Stats")] public float exhaustionPerMinute = 0.08f;
    [TabGroup("Unit Data", "Stats")] public float hungerConsumedPerMinute = 0.02f;
    [TabGroup("Unit Data", "Stats")] public float thirstConsumedPerMinute = 0.02f;

    void Start()
    {
    }
    
    public override void Update()
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void LongRest(float sleepQuality)
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void GenerateTestId(int size)
    {
    }

    //This is pretty much deprecated since the save and load system was added which just whipes the scene anytime you get back to the menu, we can drop this eventually when we do code cleanup.
    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void NewGame()
    {
    }

    public static string GenerateCharacterID(int size)
    {
        return "";
    }
    
    [TabGroup("Unit Data", "Tools")]
    [Button("Swap Localization Language")]
    public void SwapLanguage(string lang)
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void SetSkillSlot(Skill _skill, int slot)
    {
    }

    [Obsolete]
    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void SetSkillSlot1(Skill _skill)
    {
    }

    [Obsolete]
    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void SetSkillSlot2(Skill _skill)
    {
    }

    [Obsolete]
    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void SetSkillSlot3(Skill _skill)
    {
    }

    [Obsolete]
    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void SetSkillSlot4(Skill _skill)
    {
    }

    [Obsolete]
    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void SetSkillSlot5(Skill _skill)
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void SetInitialDifficulty(MultioptionButton buttonInput)
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void SetInitialDifficulty(int input)
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void SetCharacterName()
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void SetCharacterName(string input)
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public static void LearnSkill(Skill _skill)
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public static void LearnMantra(Skill _skill)
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public static void InflictCustomUsageTagEvent(string eventName)
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public static void ReinitializeSkillPointObjects()
    {
    }

    public static void VerifyPlayersSkillSlots()
    {
    }
}
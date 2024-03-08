using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public enum UnitClassification { Player, Enemy, Friendly};

public enum ItemSlots
{
    equippedHelmet,
    equippedChestplate,
    equippedGloves,
    equippedPants,
    equippedBelt,
    equippedBoots,
    equippedNecklace,
    equippedLeftEarring,
    equippedRightEarring,
    equippedBracelet,
    equippedRingA,
    equippedRingB,
    primaryWeapon,
    secondaryWeapon
}

[System.Serializable]
public class Resistance
{
    public MagicElement element = null;
    public string elementId = "";
    public float currentResistance = 0f;
}

public class UnitStats : MonoBehaviour
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
    [TabGroup("Unit Data", "Stats")] public int strength { get { return ApplyModifier(InteractionStat.Strength, baseStrength); } }
    [TabGroup("Unit Data", "Stats")] public int constitution { get { return ApplyModifier(InteractionStat.Constitution, baseConstitution); } }
    [TabGroup("Unit Data", "Stats")] public int dexterity { get { return ApplyModifier(InteractionStat.Dexterity, baseDexterity); } }
    [TabGroup("Unit Data", "Stats")] public int intelligence { get { return ApplyModifier(InteractionStat.Intelligence, baseIntelligence); } }
    [TabGroup("Unit Data", "Stats")] public int awareness { get { return ApplyModifier(InteractionStat.Awareness, baseAwareness); } }
    [TabGroup("Unit Data", "Stats")] public int stealth { get { return ApplyModifier(InteractionStat.Stealth, baseStealth); } }
    [TabGroup("Unit Data", "Stats")] public int arcana { get { return ApplyModifier(InteractionStat.Arcana, baseArcana); } }
    [TabGroup("Unit Data", "Stats")] public int luck { get { return ApplyModifier(InteractionStat.Luck, baseLuck); } }
    [TabGroup("Unit Data", "Stats")] public int initiative { get { return ApplyModifier(InteractionStat.Initiative, baseInitiative); } }
    [TabGroup("Unit Data", "Stats")] public int muscle { get { return ApplyModifier(InteractionStat.Muscle, baseMuscle); } }
    [TabGroup("Unit Data", "Stats")] public int brawn { get { return ApplyModifier(InteractionStat.Brawn, baseBrawn); } }
    [TabGroup("Unit Data", "Stats")] public int armor { get { return ApplyModifier(InteractionStat.Armor, baseArmor) + Mathf.FloorToInt(constitution * 1.5f) + brawn * 3; } }
    [TabGroup("Unit Data", "Stats")] public int magicResist { get { return ApplyModifier(InteractionStat.MagicResist, baseMagicResist) + Mathf.FloorToInt(constitution * 0.65f) + Mathf.FloorToInt(brawn * 1.65f); } }
    [TabGroup("Unit Data", "Stats")] public int critDamageMultiplier { get { return ApplyModifier(InteractionStat.CritDamageMultiplier, baseStrength); } }
    [TabGroup("Unit Data", "Stats")] public int currentSkillPointsAvailable = 0;
    [TabGroup("Unit Data", "Stats")] public int level = 1;

    [TabGroup("Unit Data", "Stats")] public float baseMaxHealth = 1f;
    [TabGroup("Unit Data", "Stats")] public float maxHealth { get { return ApplyModifierFloat(InteractionStat.MaxHealth, MathF.Max(1, baseMaxHealth)) + (strength * maxHealthPerStrength) + (constitution * maxHealthPerConstitution) + (level * maxHealthPerLevel); } }
    [TabGroup("Unit Data", "Stats")] public float missingHealth = 0f;
    [TabGroup("Unit Data", "Stats")] public float baseMaxMana = 1f;
    [TabGroup("Unit Data", "Stats")] public float maxMana { get { return ApplyModifierFloat(InteractionStat.MaxMana, MathF.Max(1, baseMaxMana)) + (arcana * maxManaPerArcana) + (intelligence * maxManaPerIntelligence) + (level * maxManaPerLevel); } }
    [TabGroup("Unit Data", "Stats")] public float missingMana = 0f;
    [TabGroup("Unit Data", "Stats")] public float baseMaxStamina = 1f;
    [TabGroup("Unit Data", "Stats")] public float maxStamina { get { return ApplyModifierFloat(InteractionStat.MaxStamina, MathF.Max(1, baseMaxStamina)) + (strength * maxStaminaPerStrength) + (dexterity * maxStaminaPerDexterity) + (level * maxStaminaPerLevel); } }
    [TabGroup("Unit Data", "Stats")] public float missingStamina = 0f;
    [TabGroup("Unit Data", "Stats")] public float baseMaxEnergy = 95f;
    [TabGroup("Unit Data", "Stats")] public float maxEnergy { get { return ApplyModifierFloat(InteractionStat.MaxEnergy, MathF.Max(1, baseMaxEnergy)) + dexterity * 5f; } }
    [TabGroup("Unit Data", "Stats")] public float missingEnergy = 0f;
    [TabGroup("Unit Data", "Stats")] public float baseAttackSpeed = 0.0f;
    [TabGroup("Unit Data", "Stats")] public float attackSpeed { get { return ApplyModifierFloat(InteractionStat.AttackSpeed, MathF.Max(0, baseAttackSpeed)); } }
    [TabGroup("Unit Data", "Stats")] public float baseCooldownReduction = 1.0f;
    [TabGroup("Unit Data", "Stats")] public float cooldownReduction { get { return ApplyModifierFloat(InteractionStat.CooldownReduction, MathF.Max(1f, baseCooldownReduction)); } }
    [TabGroup("Unit Data", "Stats")] public float baseMaxCarryWeight = 100f;
    [TabGroup("Unit Data", "Stats")] public float maxCarryWeight { get { return ApplyModifierFloat(InteractionStat.MaxCarryWeight, MathF.Max(1f, baseMaxCarryWeight)); } }
    [TabGroup("Unit Data", "Stats")] public float currentXP = 0f;
    [TabGroup("Unit Data", "Stats")] public float postCombatXPSaved = 0f;
    [TabGroup("Unit Data", "Stats")] public float currentExhaustion = 125f;
    [TabGroup("Unit Data", "Stats")] public float baseMaxExhaustion = 125f;
    [TabGroup("Unit Data", "Stats")] public float maxExhaustion { get { return ApplyModifierFloat(InteractionStat.MaxExhaustion, MathF.Max(1f, baseMaxExhaustion)); } }
    [TabGroup("Unit Data", "Stats")] public float currentHunger = 100f;
    [TabGroup("Unit Data", "Stats")] public float baseMaxHunger = 100f;
    [TabGroup("Unit Data", "Stats")] public float maxHunger { get { return ApplyModifierFloat(InteractionStat.MaxHunger, MathF.Max(1f, baseMaxHunger)); } }
    [TabGroup("Unit Data", "Stats")] public float currentThirst = 100f;
    [TabGroup("Unit Data", "Stats")] public float baseMaxThirst = 100f;
    [TabGroup("Unit Data", "Stats")] public float maxThirst { get { return ApplyModifierFloat(InteractionStat.MaxThirst, MathF.Max(1f, baseMaxThirst)); } }
    [TabGroup("Unit Data", "Stats")] public float baseConsumableStrength = 1f;
    [TabGroup("Unit Data", "Stats")] public float consumableStrength { get { return ApplyModifierFloat(InteractionStat.ConsumableStrength, MathF.Max(1f, baseConsumableStrength)); } }
    [TabGroup("Unit Data", "Stats")] public float basePhysicalDamageMultiplier = 1f;
    [TabGroup("Unit Data", "Stats")] public float physicalDamageMultiplier { get { return ApplyModifierFloat(InteractionStat.PhysicalDamageMultiplier, MathF.Max(1f, basePhysicalDamageMultiplier)); } }
    [TabGroup("Unit Data", "Stats")] public float baseMagicDamageMultiplier = 1f;
    [TabGroup("Unit Data", "Stats")] public float magicDamageMultiplier { get { return ApplyModifierFloat(InteractionStat.MagicDamageMultiplier, MathF.Max(1f, baseMagicDamageMultiplier)); } }
    [TabGroup("Unit Data", "Stats")] public float baseOverallDamageMultiplier = 1f;
    [TabGroup("Unit Data", "Stats")] public float overallDamageMultiplier { get { return ApplyModifierFloat(InteractionStat.OverallDamageMultiplier, MathF.Max(1f, baseOverallDamageMultiplier)); } }
    [TabGroup("Unit Data", "Stats")] public List<Resistance> elementalResistances = new List<Resistance>();
    [TabGroup("Unit Data", "Stats")] public int baseMaxCompanions = 1;
    [TabGroup("Unit Data", "Stats")] public int maxCompanions { get { return ApplyModifier(InteractionStat.MaxCompanions, baseMaxCompanions); } }
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

    [TabGroup("Unit Data", "Editor References")]  public Transform statusEffectContainer;
    [TabGroup("Unit Data", "Editor References")]  public List<Transform> additionalStatusEffectContainers = new List<Transform>();
    [TabGroup("Unit Data", "Editor References")]  public Transform damageIndicatorContainer;
    [TabGroup("Unit Data", "Editor References")]  public Vector3 damageIndicationTextSize = new Vector3(2.75f, 2.75f, 2.75f);
    [TabGroup("Unit Data", "Editor References")]  public Animator stunnedAnimation;
    [TabGroup("Unit Data", "Editor References")]  public Animator silencedAnimation;
    [TabGroup("Unit Data", "Editor References")]  public Animator lockdownAnimation;
    [TabGroup("Unit Data", "Editor References")]  public Animator slowedAnimation;

    public virtual void Update()
    {
    }

    private int ApplyModifier(InteractionStat stat, int baseValue)
    {
        return 0;
    }

    private float ApplyModifierFloat(InteractionStat stat, float baseValue)
    {
        return 0f;
    }

    public bool HasSkill(Skill skill)
    {
        return false;
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

    public float GetCurrentHealth()
    {
        return 0f;
    }

    public float GetCurrentMana()
    {
        return 0f;
    }

    public float GetCurrentStamina()
    {
        return 0f;
    }

    public float GetCurrentEnergy()
    {
        return 0f;
    }
    
    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void GiveHealth(float amount)
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void TakeHealth(float amount)
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void GiveStamina(float amount)
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void TakeStamina(float amount)
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void GiveMana(float amount)
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void TakeMana(float amount)
    {
    }

    public static float CalculatePreMitigatedPhysicalDamage(float damage, UnitStats caster)
    {
        return 0f;
    }

    public static float CalculatePreMitigatedMagicDamage(float damage, UnitStats caster)
    {
        return 0f;
    }

    public float DealPhysicalDamage(float damage, UnitStats caster, int damageType = 1, bool forceCrit = false, bool canDamageScale = true)
    {
        return 0f;
    }

    public float DealMagicDamage(float damage, MagicElement damageElement, UnitStats caster, bool canCrit = false, bool canDamageScale = true)
    {
        return 0f;
    }

    public float DealFlatPhysicalDamage(float damage, UnitStats caster)
    {
        return 0f;
    }

    public float DealUnblockableDamage(float damage, UnitStats caster)
    {
        return 0f;
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void AddStatusEffect(StatusEffect status, float lifetimeOfStatus, float statusEffectStrength = 1.0f, UnitStats _self = null, UnitStats _target = null)
    {
    }

    public float CalculateXPRequiredForLevel(float level)
    {
        return 0f;
    }

    public float CalculateXPForEnemy(float enemyLevel, float playerLevel)
    {
        return 0f;
    }

    public bool ShouldLevelUp(float currentLevel, float currentXP)
    {
        return false;
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void LevelUp()
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void AddXP(float amount)
    {
    }

    public bool HasStatusEffect(StatusEffect checkForStatusEffect)
    {
        return false;
    }

    public bool HasStatusEffect(string effectName)
    {
        return false;
    }
    
    public bool RemoveStatusEffect(string effectName)
    {
        return false;
    }

    public virtual void OnLevelUp()
    {
    }

    public float GetElementalResistance(MagicElement mElement)
    {
        foreach(Resistance resistance in elementalResistances)
        {
            if(resistance.element.ElementName == mElement.ElementName)
            {
                return resistance.currentResistance;
            }
        }

        return 0f;
    }
    
    public virtual void KillUnit()
    {
        missingHealth = maxHealth;
    }
}
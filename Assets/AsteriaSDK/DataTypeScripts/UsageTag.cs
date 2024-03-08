using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Diagnostics;

public enum UsageType
{
    DealPhysicalDamage, //Used for combat damage
    DealMagicDamage, //Used for combat damage
    ConsumeHealth, //Used for costs
    ConsumeStamina, //Used for costs
    ConsumeMana, //Used for costs
    ModifyMaxStamina, //Used for non-cost modification.
    ModifyCurrentStamina, //Used for non-cost modification.
    ModifyMaxMana, //Used for non-cost modification.
    ModifyCurrentMana, //Used for non-cost modification.
    ModifyLevel, //Used for non-cost modification.
    ModifyMaxHealth, //Used for non-cost modification.
    ModifyCurrentHealth, //Used for non-cost modification.
    ModifyStrength, //Used for non-cost modification.
    ModifyConstitution, //Used for non-cost modification.
    ModifyDexterity, //Used for non-cost modification.
    ModifyIntelligence, //Used for non-cost modification.
    ModifyAwareness, //Used for non-cost modification.
    ModifyStealth, //Used for non-cost modification.
    ModifyArcana, //Used for non-cost modification.
    ModifyLuck, //Used for non-cost modification.
    ModifyInitiative, //Used for non-cost modification.
    ModifyMuscle, //Used for non-cost modification.
    ModifyBrawn, //Used for non-cost modification.
    ModifyInnateArmor, //Used for non-cost modification.
    ModifyInnateMagicResist, //Used for non-cost modification.
    ModifyAttackSpeed, //Used for non-cost modification.
    ModifyCooldownReduction, //Used for non-cost modification.
    ModifyName, //Used for non-cost modification.
    ModifyMonsterRarity, //Used for non-cost modification.
    ModifyElement, //Used for non-cost modification.
    ModifyDisplayImage, //Used for non-cost modification.
    ModifyDisplayHealth, //Used for non-cost modification.
    ModifyDisplayStamina, //Used for non-cost modification.
    ModifyDisplayMana, //Used for non-cost modification.
    ModifyCritDamageMultiplier, //Used for non-cost modification.
    ModifyInnateCritChance, //Used for non-cost modification.
    Kill, //Used to instantly kill something.
    AddSkill, //Used for non-cost modification.
    AddLanguage, //Used for non-cost modification.
    RemoveLanguage, //Used for non-cost modification.
    GiveItemWithAmount, //Used for non-cost modification.
    RemoveItemByNameAndAmount, //Used for non-cost modification.
    GiveStatusEffect, //Gives a status effect.
    RemoveStatusEffect, //Removes a status effect.
    AttemptFleeCombat, //Used to flee combat. Scale determines success rate, 100 means 100%, 1 means 1% or 1/100.
    Execute, //Executes based on % max health.
    DealTrueDamage, //Used for combat damage
    DealFlatPhysicalDamage, //Used for combat damage, does not take any scaling or stats into account, only the flat value provided.
    ModifyXP, //Used to change the players current XP, only applies to the player.
    CustomExecutionScript, //Used to run a modular script function.
    CustomPlayerEvent,
    ModifyHunger,
    ModifyThirst,
    ModifyExhaustion,
    ModifyClass,
    AddMantra,
    ModifyPhysicalDamage,
    ModifyMagicDamage,
    ModifyOverallDamage,
    ModifyCompanionCapacity,
    SummonCompanion,
    ChangeLocation,
    ModifySlowTime,
    ModifyLockdownTime,
    ModifyStunTime,
    ModifySilenceTime,
    GiveStoryFlag,
    ModifySkillPoints
}

public enum ApplyType
{
    Flat,
    PercentCurrent,
    PercentMaximum
}

public enum TargetType
{
    Target,
    Self
}

public enum MathOperation
{
    Multiply, Divide, Add, Subtract
}

public enum StatScalingType
{
    NoLevelScaling, LevelLinear, LevelExponential, LevelPercentage, LevelLogarithmic
}

[System.Serializable]
public class StatScaling
{
    public InteractionStat statToScaleBy;
    public float scaleRatio = 1.5f;
    public StatScalingType statScalingType;
    [ShowIf("statScalingType", StatScalingType.NoLevelScaling)]
    public MathOperation appliedOperation;
    public MathOperation inputOperation;

    public float GetScalingResult(float input, UnitStats unit, List<SerializedUsageTag> uTags)
    {
        return 0f;
    }

    public float GetScalingResult(float input, UnitStats unit)
    {
        return 0f;
    }
}

[System.Serializable]
public class UsageTag
{
    public UsageType usageType;
    public ApplyType applyAs;

    [ShowIf("@usageType == UsageType.ModifyName || usageType == UsageType.RemoveItemByNameAndAmount || usageType == UsageType.GiveStoryFlag")]
    [LabelText("$GetStringValueLabel")]
    public string stringValue = "";

    [ShowIf("@usageType == UsageType.ConsumeHealth || usageType == UsageType.ConsumeStamina || usageType == UsageType.ConsumeMana || usageType == UsageType.DealFlatPhysicalDamage || " +
        "usageType == UsageType.DealPhysicalDamage || usageType == UsageType.DealTrueDamage || usageType == UsageType.DealMagicDamage || usageType == UsageType.ModifyCurrentHealth || " +
        "usageType == UsageType.ModifyCurrentStamina || usageType == UsageType.ModifyCurrentMana || usageType == UsageType.AttemptFleeCombat || usageType == UsageType.GiveStatusEffect || " +
        "usageType == UsageType.ModifyCompanionCapacity || usageType == UsageType.ModifyInnateArmor || usageType == UsageType.ModifyXP || usageType == UsageType.ModifyMaxStamina || " +
        "usageType == UsageType.ModifyMaxHealth || usageType == UsageType.ModifyMaxMana || usageType == UsageType.ModifyLevel || usageType == UsageType.ModifyStrength || usageType == UsageType.ModifyConstitution" +
        " || usageType == UsageType.ModifyDexterity || usageType == UsageType.ModifyIntelligence || usageType == UsageType.ModifyAwareness || usageType == UsageType.ModifyStealth || usageType == UsageType.ModifyArcana" +
        " || usageType == UsageType.ModifyLuck || usageType == UsageType.ModifyInitiative || usageType == UsageType.ModifyMuscle || usageType == UsageType.ModifyBrawn || usageType == UsageType.ModifyInnateMagicResist ||" +
        " usageType == UsageType.ModifyAttackSpeed || usageType == UsageType.ModifyCooldownReduction || usageType == UsageType.Execute || usageType == UsageType.ModifyCritDamageMultiplier" +
        " || usageType == UsageType.ModifyPhysicalDamage || usageType == UsageType.ModifyMagicDamage || usageType == UsageType.ModifyOverallDamage || usageType == UsageType.ModifyExhaustion" +
        " || usageType == UsageType.ModifyThirst || usageType == UsageType.ModifyHunger || usageType == UsageType.SummonCompanion || usageType == UsageType.GiveItemWithAmount || usageType == UsageType.RemoveItemByNameAndAmount" +
        " || usageType == UsageType.ModifySlowTime || usageType == UsageType.ModifyLockdownTime || usageType == UsageType.ModifyStunTime || usageType == UsageType.ModifySilenceTime || usageType == UsageType.ModifySkillPoints")]
    [LabelText("$GetIntValueLabel")]
    public int intValue = 0;

    [ShowIf("@usageType == UsageType.ConsumeHealth || usageType == UsageType.ConsumeStamina || usageType == UsageType.ConsumeMana || usageType == UsageType.DealFlatPhysicalDamage || " +
        "usageType == UsageType.DealPhysicalDamage || usageType == UsageType.DealTrueDamage || usageType == UsageType.DealMagicDamage || usageType == UsageType.ModifyCurrentHealth || " +
        "usageType == UsageType.ModifyCurrentStamina || usageType == UsageType.ModifyCurrentMana || usageType == UsageType.AttemptFleeCombat || usageType == UsageType.GiveStatusEffect || " +
        "usageType == UsageType.ModifyCompanionCapacity || usageType == UsageType.ModifyInnateArmor || usageType == UsageType.ModifyXP || usageType == UsageType.ModifyMaxStamina || " +
        "usageType == UsageType.ModifyMaxHealth || usageType == UsageType.ModifyMaxMana || usageType == UsageType.ModifyLevel || usageType == UsageType.ModifyStrength || usageType == UsageType.ModifyConstitution" +
        " || usageType == UsageType.ModifyDexterity || usageType == UsageType.ModifyIntelligence || usageType == UsageType.ModifyAwareness || usageType == UsageType.ModifyStealth || usageType == UsageType.ModifyArcana" +
        " || usageType == UsageType.ModifyLuck || usageType == UsageType.ModifyInitiative || usageType == UsageType.ModifyMuscle || usageType == UsageType.ModifyBrawn || usageType == UsageType.ModifyInnateMagicResist ||" +
        " usageType == UsageType.ModifyAttackSpeed || usageType == UsageType.ModifyCooldownReduction || usageType == UsageType.Execute || usageType == UsageType.ModifyCritDamageMultiplier" +
        " || usageType == UsageType.ModifyPhysicalDamage || usageType == UsageType.ModifyMagicDamage || usageType == UsageType.ModifyOverallDamage || usageType == UsageType.ModifyExhaustion" +
        " || usageType == UsageType.ModifyThirst || usageType == UsageType.ModifyHunger || usageType == UsageType.GiveItemWithAmount || usageType == UsageType.RemoveItemByNameAndAmount || usageType == UsageType.ModifySlowTime" +
        " || usageType == UsageType.ModifyLockdownTime || usageType == UsageType.ModifyStunTime || usageType == UsageType.ModifySilenceTime || usageType == UsageType.ModifySkillPoints")]
    [LabelText("$GetFloatValueLabel")]
    public float floatValue = 1f;

    [ShowIf("@usageType == UsageType.GiveStatusEffect || usageType == UsageType.SummonCompanion || usageType == UsageType.DealPhysicalDamage || usageType == UsageType.DealTrueDamage || usageType == UsageType.DealMagicDamage || usageType == UsageType.DealFlatPhysicalDamage")]
    [LabelText("$GetSecondaryFloatValueLabel")]
    public float secondaryFloatValue = 1f;

    [ShowIf("@usageType == UsageType.DealPhysicalDamage || usageType == UsageType.DealMagicDamage")]
    [LabelText("$GetBoolLabel")]
    public bool boolValue = false;

    private string GetStringValueLabel()
    {
        if (usageType == UsageType.ModifyName)
        {
            return "Name";
        }
        else if (usageType == UsageType.RemoveItemByNameAndAmount)
        {
            return "Item Name";
        }
        else if (usageType == UsageType.GiveStoryFlag)
        {
            return "Story Flag";
        }

        return "Error!";
    }

    private string GetBoolLabel()
    {
        if (usageType == UsageType.DealMagicDamage)
        {
            return "Damage Does Not Use Stat Scalings?";
        }
        else if (usageType == UsageType.DealPhysicalDamage)
        {
            return "Damage Does Not Use Stat Scalings?";
        }

        return "Error!";
    }

    private string GetSecondaryFloatValueLabel()
    {
        if (usageType == UsageType.GiveStatusEffect)
        {
            return "Status Effect Lifetime";
        }
        else if (usageType == UsageType.SummonCompanion)
        {
            return "Amount to Summon";
        }
        else if (usageType == UsageType.DealPhysicalDamage)
        {
            return "Flat Damage Increase";
        }
        else if (usageType == UsageType.DealTrueDamage)
        {
            return "Flat Damage Increase";
        }
        else if (usageType == UsageType.DealMagicDamage)
        {
            return "Flat Damage Increase";
        }
        else if (usageType == UsageType.DealFlatPhysicalDamage)
        {
            return "Flat Damage Increase";
        }

        return "Error!";
    }

    private string GetIntValueLabel()
    {
        return GetValueLabel("int");
    }

    private string GetFloatValueLabel()
    {
        return GetValueLabel("float");
    }

    private string GetValueLabel(string input)
    {
        if (usageType == UsageType.ConsumeHealth || usageType == UsageType.ConsumeStamina || usageType == UsageType.ConsumeMana)
        {
            return "Consumption Amount(" + input + ")";
        }
        else if (usageType == UsageType.DealFlatPhysicalDamage || usageType == UsageType.DealPhysicalDamage || usageType == UsageType.DealTrueDamage || usageType == UsageType.DealMagicDamage)
        {
            return "Damage Amount(" + input + ")";
        }
        else if (usageType == UsageType.GiveStatusEffect)
        {
            return "Status Effect Power";
        }
        else if (usageType == UsageType.AttemptFleeCombat)
        {
            return "Flee Chance";
        }
        else if (usageType == UsageType.Execute)
        {
            if (applyAs == ApplyType.Flat)
                return "Execute if current health lower than:";
            return "Execute if this % or lower of current health:";
        }
        else if (usageType == UsageType.SummonCompanion)
        {
            return "Level of Summon";
        }
        else if (usageType == UsageType.GiveItemWithAmount)
        {
            return "Amount to Give";
        }
        else if (usageType == UsageType.RemoveItemByNameAndAmount)
        {
            return "Amount to Remove";
        }

        return "Modification Amount(" + input + ")";
    }

    [ShowIf("@usageType == UsageType.GiveStatusEffect || usageType == UsageType.RemoveStatusEffect")]
    public StatusEffect statusEffect;
    [ShowIf("@usageType == UsageType.GiveStatusEffect || usageType == UsageType.RemoveStatusEffect")]
    public string statusEffectId;

    public StatusEffect GetStatusEffect()
    {
        return null;
    }

    [ShowIf("@usageType == UsageType.AddSkill || usageType == UsageType.AddMantra")]
    public Skill skill;
    [ShowIf("@usageType == UsageType.AddSkill || usageType == UsageType.AddMantra")]
    public string skillId;

    public Skill GetSkill()
    {
        return null;
    }

    [ShowIf("@usageType == UsageType.AddLanguage || usageType == UsageType.RemoveLanguage")]
    public Language language;
    [ShowIf("@usageType == UsageType.AddLanguage || usageType == UsageType.RemoveLanguage")]
    public string languageId;

    public Language GetLanguage()
    {
        return null;
    }

    [ShowIf("usageType", UsageType.GiveItemWithAmount, true)]
    public SerializedItem item;

    [ShowIf("usageType", UsageType.ChangeLocation, true)]
    public Location location;
    [ShowIf("usageType", UsageType.ChangeLocation, true)]
    public string locationId;

    public Location GetLocation()
    {
        return null;
    }

    [ShowIf("@usageType == UsageType.ModifyElement || usageType == UsageType.DealMagicDamage")]
    public MagicElement element;
    [ShowIf("@usageType == UsageType.ModifyElement || usageType == UsageType.DealMagicDamage")]
    public string elementId;

    public MagicElement GetElement()
    {
        return null;
    }

    [ShowIf("usageType", UsageType.ModifyClass, true)] public Class playerClass;
    [ShowIf("usageType", UsageType.ModifyClass, true)] public string playerClassId;

    public Class GetClass()
    {
        return null;
    }

    [ShowIf("usageType", UsageType.SummonCompanion, true)] public Monster monsterTemplate;
    [ShowIf("usageType", UsageType.SummonCompanion, true)] public string monsterTemplateId;

    public Monster GetMonsterTemplate()
    {
        return null;
    }

    [ShowIf("usageType", UsageType.CustomExecutionScript, true)]
    [SerializeField] private ExecutionScriptWrapper _customExecutionScript;

    [ShowIf("usageType", UsageType.CustomExecutionScript, true)]
    public ExecutionScriptWrapper CustomExecutionScript => _customExecutionScript;

    public bool usesStatScaling = false;

    [ShowIf("usesStatScaling")]
    public List<StatScaling> statScalings = new List<StatScaling>();

    public void Execute(UnitStats caster, UnitStats target)
    {
        return;
    }
}

[System.Serializable]
public class SerializedUsageTag
{
    public UsageTag usageTag = null;
    public float multiplyStrength = 1;

    public bool tagHasRequirementsToExecute = false;
    [ShowIf("tagHasRequirementsToExecute")] public float usageChance = 100; //This is a % based system, 100 means 100%, 50 means 50%.
    [ShowIf("tagHasRequirementsToExecute")] public InteractionRequirement requirementForTag = new InteractionRequirement();

    public TargetType targetType;

    public SerializedUsageTag() { }
    public SerializedUsageTag(UsageTag uTag, float strength = 1f) { usageTag = uTag; multiplyStrength = strength; }
    public SerializedUsageTag(UsageTag uTag, float strength = 1f, TargetType tType = TargetType.Self) { usageTag = uTag; multiplyStrength = strength; targetType = tType; }
}
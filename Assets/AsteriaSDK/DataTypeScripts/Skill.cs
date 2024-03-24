using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum UsageAllowed
{
    All,
    OnlyEnemy,
    OnlyFriendly,
    OnlyFriendly_NotSelf,
    Companions,
    Pets,
    Summons,
    Self
}

public enum MonsterClassification
{
    Unit,
    Companion,
    Pet,
    Summon
}

public enum DamageClassification
{
    Physical,
    Magic,
    Void
}

//Necessary for deciding how an enemy should react in a fight. This includes non-controlled companions.
public enum AIHelper
{
    Damage, //Raw damage for when the enemy wants to get a hit in and isn't in panic mode.
    SelfDefence, //Hunker down and raise stats.
    SelfHealing, //Heal self if mana is available to spare and below 60% health.
    SelfAttackUp, //Increase ones attack if healthy and safe to do so.
    LowerAttackEnemy, //Lower the enemies attack spells.
    LowerArmorEnemy, //Lowers the defences of the enemy temporarily.
    StunEnemy, //Reserved for spells with a disabling effect.
    LastChanceDamage, //Suicide bomb spells, doesn't care about mana or stamina.
    LastChanceMana, //Last minute spells that will devour all mana but give a big effect to the enemy.
    LastChanceStamina, //Last minute spells that will devour all stamina but give a big effect to the enemy.
    Curse, //Leaves a semi-permanent debuff on the player. Chance based usage when in panic mode.
    ApplyDebuff, //Attempt to apply a debuff to the player. Debuffs are specified in the tag on the skill.
    ApplyBuff, //Attempt to apply a buff to self. Debuffs are specified in the tag on the skill.
    ApplyBuffAlly //Attempt to apply a buff to self. Debuffs are specified in the tag on the skill.
}

[HideMonoScript]
[CreateAssetMenu(fileName = "DefaultSkill", menuName = "Asteria/Skill", order = 0)]
public class Skill : ScriptableObject
{
    [TabGroup("Basic Data")] [Tooltip("The name of the skill.")] public string nameOfSkill = "Default Skill";
    [TabGroup("Basic Data")] [TextArea] [Tooltip("Text to describe the skill in greater detail.")] public string flavorText = "This skill does absolutely nothing...";
    [TabGroup("Basic Data")] [Tooltip("What the skill looks like. Leave empty for a default image.")] public Sprite skillImage = null;
    [TabGroup("Basic Data")] [Tooltip("What the skill looks like. Leave empty for a default image.")] public string skillImageId = "";
    [TabGroup("Basic Data")] public bool isMantra = false;
    [TabGroup("Balance Data")] [Tooltip("This is a multiplier used with UsageTags, setting to 2 for example will double the resource cost to cast.")] public int resourceCost = 1;
    [TabGroup("Balance Data")] [Tooltip("The AoE size. Leave as 1 if it only hits 1 target. 2 for enemy to the left or right, 3 if it hits both the left and right, etc.")] public int aoeSize = 1;
    [TabGroup("Balance Data")] [Tooltip("Determines attack speed/cooldown speed of the skill/spell. Will be reduced based on ability type.")] public float cooldownLength = 3.5f;
    [TabGroup("Balance Data")] [Tooltip("Determines how long the skill takes to channel.")] public float channelLength = 0.25f;
    [TabGroup("Balance Data")] [Tooltip("Determines how long the skill takes to channel.")] public float windupLength = 0.25f;
    [TabGroup("Balance Data")] [Tooltip("Determines the amount of skill checks that are made.")] public int amountOfSkillChecks = 3;
    [TabGroup("Balance Data")] [Tooltip("Determines the percent chance each skill check is successful.")] public float accuracy = 100f;
    [Required] [TabGroup("Balance Data")] [Tooltip("Used to classify what element the skill uses, at some point it might change skill borders.")] public MagicElement element = null;
    [TabGroup("Usage Tags")] [Tooltip("Describes to the system how this skill behaves.")] public List<SerializedUsageTag> usageTags = new List<SerializedUsageTag>();
    [TabGroup("Balance Data")] [Tooltip("The class this skill is for, leave blank for all.")] public Class requiredClass = null;
    [TabGroup("Balance Data")] [Tooltip("Leave blank unless the skill needs a translation to use/understand.")] public Language languageRequired = null;
    [TabGroup("Balance Data")] [Tooltip("What this skill can be used on.")] public DamageClassification DamageClassification = DamageClassification.Void;
    [TabGroup("Balance Data")] [Tooltip("What this skill can be used on.")] public UsageAllowed usability = UsageAllowed.All;
    [TabGroup("Balance Data")] [Tooltip("Determines how this spell will be interpreted by an AI. This could be a summon, enemy, companion, etc.")] public AIHelper AISkillUsage;
    [TabGroup("Balance Data")] public bool startOnCooldown = false;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cure
{
    Blessing,
    SpecificItem,
    Doctor,
    LesserHealingMagic,
    HealingMagic,
    GreaterHealingMagic,
    Secret,
    Fire,
    Water,
    Liquid,
    Skill
}

public enum TypeOfStatus
{
    TemporaryDebuff, //Example: On fire
    PermanentDebuff, //Example: Missing limb
    TemporaryBuff, //Example: Well rested
    PermanentBuff, //
    TemporaryBoth,
    PermanentBoth,
}

[Sirenix.OdinInspector.HideMonoScript]
[CreateAssetMenu(fileName = "DefaultStatusEffect", menuName = "Asteria/Status Effect", order = 5)]
public class StatusEffect : ScriptableObject
{
    public string nameOfStatus = "Default Status Effect";
    public string formattedNameOfStatus = "<color=#B51400>Default Status Effect</color>";
    [Tooltip("See: http://digitalnativestudios.com/textmeshpro/docs/rich-text/ for formatting info.")]
    [TextArea] public string flavorText = "Something about this status effect should be written here...";

    [Tooltip("Used to determine how the status is cured. This can be left empty.")]
    public List<Cure> cures = new List<Cure>();

    public bool tickLifetimeInCombat = true;
    public bool tickLifetimeInWorld = true;

    [Tooltip("Anything can go here, will be used for both in and out of combat.")]
    public List<SerializedUsageTag> genericUsageTags = new List<SerializedUsageTag>();
    [Tooltip("The actual impact in the world, will be ignored in combat and instead apply every second in the world.")]
    public List<SerializedUsageTag> usageTagsWorld = new List<SerializedUsageTag>();
    [Tooltip("The actual impact in combat, will be ignored in the world.")]
    public List<SerializedUsageTag> usageTagsCombat = new List<SerializedUsageTag>();
    [Tooltip("This is for special mechanics that are specificly coded. Somewhat modular, but use other tag lists when possible to ensure true functionality.")]
    public List<SerializedUsageTag> specialTag = new List<SerializedUsageTag>();
    [Tooltip("This is for what happens when this effect is cured.")]
    public List<SerializedUsageTag> onCureTag = new List<SerializedUsageTag>();
    [Tooltip("This is for what happens when this effects begins. Good for 1 time applications.")]
    public List<SerializedUsageTag> onStatusBegin = new List<SerializedUsageTag>();
    [Tooltip("This is for what happens when this effects time is up. Good for cleanup of 1 time applications.")]
    public List<SerializedUsageTag> onLifespanOver = new List<SerializedUsageTag>();

    [Tooltip("If this is toggled off then you cannot wait it out and must cure it.")]
    public bool hasLifespan = true;
    [Tooltip("How long this status lasts")]
    public float lifespan = 60f;

    [Tooltip("The icon used to display the status effect in the designated display area.")]
    public Sprite displayImage = null;
    public string displayImageId = "";

    public Color iconTint;
    
    public List<PreGeneratedModifiedStat> preGeneratedModifiers = new List<PreGeneratedModifiedStat>();
    public List<GeneratedModifiedStat> generatedModifiers = new List<GeneratedModifiedStat>();
}
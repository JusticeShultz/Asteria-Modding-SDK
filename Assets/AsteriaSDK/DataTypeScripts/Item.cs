using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum ItemType
{
    Weapon,
    Helmet,
    Chestplate,
    Gloves,
    Pants,
    Boots,
    Belt,
    Necklace,
    Ring,
    Earring,
    Bracelet,
    Consumable,
    Currency,
    Misc
}

public enum ItemUsageSize
{
    OneHanded, TwoHanded
}

public enum LevelScalingMethod
{
    None, Simple, Linear, Exponential, Percentage, Logarithmic
}

[System.Serializable]
public class PreGeneratedModifiedStat
{
    public InteractionStat statToModify;
    public Vector2 generatedValueRange;
    public Vector2 minMaxGeneratedValueRange = new Vector2(-9999, 9999);
    public LevelScalingMethod levelScalingMethod;
    [ShowIf("@levelScalingMethod != LevelScalingMethod.None")] public float levelScale;
}

[System.Serializable]
public class GeneratedModifiedStat
{
    public InteractionStat statToModify;
    public float generatedValue;
    public GeneratedModifiedStat() {}
    public GeneratedModifiedStat(PreGeneratedModifiedStat input, int level, float power = 1f) {}
}

[HideMonoScript]
#if UNITY_EDITOR
[UnityEditor.CanEditMultipleObjects]
#endif
[CreateAssetMenu(fileName = "DefaultItem", menuName = "Asteria/Item", order = 1)]
public class Item : Sirenix.Serialization.OdinSerializer.SerializedScriptableObject
{
    [Tooltip("The name of the item.")]
    [TabGroup("Basic Data")] public string nameOfItem = "Default Item";

    [TextArea]
    [Tooltip("Text to describe the item in greater detail.")]
    [TabGroup("Basic Data")] public string flavorText = "This item does absolutely nothing...";

    [ShowIf("@typeOfItem != ItemType.Consumable && typeOfItem != ItemType.Misc")]
    [TabGroup("Item Set Data")] public string itemSetTag = "";
    [ShowIf("@typeOfItem != ItemType.Consumable && typeOfItem != ItemType.Misc")]
    [TabGroup("Item Set Data")] public int itemSetCountRequired = 5;
    [ShowIf("@typeOfItem != ItemType.Consumable && typeOfItem != ItemType.Misc")]
    [TabGroup("Item Set Data")] public List<PreGeneratedModifiedStat> preGeneratedSetModifierStats = new List<PreGeneratedModifiedStat>();
    [ShowIf("@typeOfItem != ItemType.Consumable && typeOfItem != ItemType.Misc")]
    [TabGroup("Item Set Data")] public List<Skill> setGrantedSkills = new List<Skill>();

    [Tooltip("What the item looks like. Leave empty for a default image.")]
    [TabGroup("Basic Data")] public Sprite itemImage = null;
    [TabGroup("Basic Data")] public string itemImageId = "";

    public bool isMisc
    {
        get
        {
            return typeOfItem == ItemType.Misc;
        }
    }

    [Tooltip("The classification of the item. Effects the actual functionality of the item.")]
    [TabGroup("Basic Data")] public ItemType typeOfItem;

    public bool isConsumable
    {
        get
        {
            return typeOfItem == ItemType.Consumable;
        }
    }

    public bool isEquipment
    {
        get
        {
            return typeOfItem != ItemType.Consumable && typeOfItem != ItemType.Misc;
        }
    }

    [TabGroup("Basic Data")] public string overrideTypeOfItemText = "NA";

    [TabGroup("Basic Data")] public Rarity itemRarity;

    [ShowIf("@isEquipment == true")]
    [TabGroup("Basic Data")] public List<Skill> grantedSkills = new List<Skill>();
    [TabGroup("Basic Data")]
    [Tooltip("The class this item is for, leave blank for all.")]
    [ShowIf("@isEquipment == true")]
    public List<Class> targetClasses = new List<Class>();
    [ShowIf("@isEquipment == true")]
    public List<string> targetClassIds = new List<string>();
    [TabGroup("Basic Data")] public string statFieldText = "";
    [TabGroup("Basic Data")] public List<string> effectsList = new List<string>();

    [TabGroup("Usage Tag Data")] public List<SerializedUsageTag> onObtain = new List<SerializedUsageTag>();
    [ShowIf("@isEquipment == true")]
    [TabGroup("Usage Tag Data")] public List<SerializedUsageTag> onEquip = new List<SerializedUsageTag>();
    [ShowIf("@isConsumable == true")]
    [TabGroup("Usage Tag Data")] public List<SerializedUsageTag> onConsume = new List<SerializedUsageTag>();
    [ShowIf("@isEquipment == true")]
    [TabGroup("Usage Tag Data")] public List<SerializedUsageTag> onAnyDamageTaken = new List<SerializedUsageTag>();
    [ShowIf("@isEquipment == true")]
    [TabGroup("Usage Tag Data")] public List<SerializedUsageTag> onPhysicalDamageTaken = new List<SerializedUsageTag>();
    [ShowIf("@isEquipment == true")]
    [TabGroup("Usage Tag Data")] public List<SerializedUsageTag> onMagicDamageTaken = new List<SerializedUsageTag>();

    [TabGroup("Basic Data")]
    //The actual inputs of the usageTags will be developed over time, a style sheet for documentation will be written up over time.
    [Tooltip("Feel free to leave blank. This will probably be used for cheats or something later on to spawn in items in a console.")]
    public string searchupTag = "Null";

    [TabGroup("Basic Data")]
    [Tooltip("Only really applies to weapons, skip for other types.")]
    public ItemUsageSize itemHandRequirement;

    [TabGroup("Basic Data")]
    [ShowIf("@isEquipment == true")]
    [Tooltip("Only toggle on if you intend for the equipment/weapon to lose durability and eventually break.")]
    public bool usesDurability = false;

    [TabGroup("Basic Data")]
    [ShowIf("@isEquipment == true")]
    [Tooltip("Only applies to equipment and weapons. Requires repairs which costs coin. Make sure use durability is enabled to use this feature.")]
    public float durability = 25f;

    [ShowIf("@isEquipment == false")]
    [TabGroup("Basic Data")] public bool itemCanStack = false;

    [TabGroup("Basic Data")] public float itemWeight = 1.0f;

    [ShowIf("@isEquipment == true")]
    [TabGroup("Basic Data")] public bool overrideLevelOnCreation = false;
    [ShowIf("@isEquipment == true")]
    [TabGroup("Basic Data")][ShowIf("overrideLevelOnCreation")] public int overrideLevel = 0;

    [TabGroup("Basic Data")]
    [Tooltip("The approximate worth of the items sell and buy price. Does not affect shop keepers scalings.")]
    public int worth = 25;

    [ShowIf("@isMisc == false")]
    [TabGroup("Usage Requirements")]
    public InteractionRequirement usageRequirements;

    [ShowIf("@isEquipment == true")]
    [TabGroup("Modifiers")]
    public List<PreGeneratedModifiedStat> preGeneratedModifierStats = new List<PreGeneratedModifiedStat>();

    [ShowIf("@isEquipment == true")]
    [TabGroup("Modifiers")]
    public List<Resistance> elementalResistances = new List<Resistance>();
}
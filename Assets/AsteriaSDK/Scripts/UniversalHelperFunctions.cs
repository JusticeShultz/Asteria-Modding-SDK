using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using Sirenix.OdinInspector;

public enum Difficulty
{
    Story,
    Standard,
    Hard,
    Demonic,
    Hardcore
}

[System.Serializable] public class LocalizationFont
{
    public string localizationLanguage;
    public Material associatedMaterial;
}

public class UniversalHelperFunctions : MonoBehaviour
{
    public static UniversalHelperFunctions Instance;

    public Class noClassReference;

    public Animator levelUpAnim;
    public GameObject mainMenu;
    public GameObject debugMenu;
    public Transform loadableSaves;
    public GameObject saveTemplate;
    public GameObject loadSaveConfirmation;
    public Material skillPointHighlightMaterial;
    public Sprite noSkillIcon;
    public StatusEffect exhaustedEffect;
    public StatusEffect hungryEffect;
    public StatusEffect thirstyEffect;
    public List<ScreenShake> screenShakeControllers = new List<ScreenShake>();

    public static bool KeyInputConsumed
    {
        get
        {
            return false;
        }
    }

    public int statToolbarSetup
    {
        get
        {
            return 0;
        }
        set
        {
            statToolbarSetting.currentSelection = value;
        }
    }

    public MultioptionButton statToolbarSetting;

    public List<LocalizationFont> localizationFonts = new List<LocalizationFont>();
    
    void Start()
    {
    }

    private void Update()
    {
    }
    
    public static bool Roll(float percentageChance)
    {
        return false;
    }
    
    public static bool RollDice(int minimumValue, int numSides)
    {
        return false;
    }

    [TabGroup("Tools")]
    [Button]
    public void CloseGame()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void ReloadScene()
    {
    }

    public static bool IsItemNull(SerializedItem item)
    {
        return false;
    }

    public static bool IsAnimationPlaying(string animationName, Animator animator)
    {
        return false;
    }

    [TabGroup("Tools")]
    [Button]
    public static void GivePlayerStoryFlag(string flag)
    {
    }

    public static float ElementEffectivenessModifier(MagicElement usedElement, MagicElement targetElement, UnitStats unit)
    {
        return 0f;
    }

    public static bool IsValueInRange(Vector2 range, float value)
    {
        return false;
    }

    [TabGroup("Tools")]
    [Button]
    public static void DestroyTheChild(Transform parentTransform)
    {
    }
    
    [TabGroup("Tools")]
    [Button]
    public void ManuallySave(string field)
    {
    }
    
    [TabGroup("Tools")]
    [Button]
    public void LocateUnpopulatedSaveFile(string field)
    {
    }
    
    [TabGroup("Tools")]
    [Button]
    public void AcceptLoadSavePrompt()
    {
    }
    
    [TabGroup("Tools")]
    [Button]
    public void RecreateLoadMenu()
    {
    }
    
    [TabGroup("Tools")]
    [Button]
    public void DenyLoadSavePrompt()
    {
    }

    public static string CalculateCoins(int totalCoins)
    {
        return "";
    }

    public static UnitStats GetUnitWithLowestHealth(List<UnitStats> units)
    {
        return null;
    }

    public static List<UnitStats> SortUnitWithLowestHealth(List<UnitStats> units)
    {
        return null;
    }

    public static UnitStats GetUnitWithHighestHealth(List<UnitStats> units)
    {
        return null;
    }

    public static List<UnitStats> SortUnitWithHighestHealth(List<UnitStats> units)
    {
        return null;
    }

    public static UnitStats GetRandomUnit(List<UnitStats> units)
    {
        return null;
    }

    public static float GetStatFromUnit(InteractionStat statTarget, UnitStats unit, List<SerializedUsageTag> uTags = null)
    {
        return 0;
    }

    public static string GetIconFromStat(InteractionStat statTarget)
    {
        return "";
    }
    
    public static string GetColorHexFromInteractionStat(InteractionStat interactionStat, MagicElement element = null)
    {
        return "";
    }

    public static string GetStringFromInteractionStat(InteractionStat interactionStat)
    {
        return "";
    }

    public static string GetFormattedStringFromInteractionStat(InteractionStat interactionStat)
    {
        return "";
    }

    public static string GetFormattedStringFromValue(InteractionStat interactionStat, float value)
    {
        return "";
    }

    public static float GetStatFromUnit(string statTarget, UnitStats unit)
    {
        return 0f;
    }

    public static InteractionStat GetInteractionStatFromString(string input)
    {
        return 0;
    }

    public static void ScreenShake(float intensity, float duration)
    {
    }

    public static float CalculatePercentage(float currentValue, float maxValue)
    {
        return 0f;
    }
    
    public static string ParseStringStat(string parser, UnitStats unit, MagicElement optionalElement = null, List<SerializedUsageTag> uTags = null)
    {
        return "";
    }
}
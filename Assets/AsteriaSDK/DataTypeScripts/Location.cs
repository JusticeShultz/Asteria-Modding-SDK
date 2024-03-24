using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class LocationalWeather
{
    public string weatherEffectID;

    public Vector2 possibleDurationLengthRange;
    public Vector2 requiredTemperatureRange;
    public float weight;
}

[HideMonoScript]
[CreateAssetMenu(fileName = "New Location", menuName = "Asteria/Location", order = 1)]
public class Location : ScriptableObject
{
    [TabGroup("Basic Data")] public string locationName = "New Location";
    [TabGroup("Basic Data")] [TextArea] public string flavorText = "Some information about this location, this goes into the dossier...";
    [TabGroup("Basic Data")] [TextArea] public string climateType = "Humid";
    [TabGroup("Basic Data")] public List<Location> travelable = new List<Location>();
    [TabGroup("Basic Data")] public List<string> travelableIds = new List<string>(); //Used for mod linking. Adds the location IDs to the travelable list from the loaded mods list.
    [TabGroup("Basic Data")] public List<string> travelToInjectionIds = new List<string>(); //Used for mod linking. Injects the location into the travelable list of the location ID'd here.
    [TabGroup("Basic Data")] public List<Encounter> possibleEncounters = new List<Encounter>();
    [TabGroup("Basic Data")] public List<string> possibleEncountersByID = new List<string>();
    [TabGroup("Basic Data")] public List<string> possibleEncountersByName = new List<string>();
    [TabGroup("Basic Data")] public bool isTown = false;
    
    [TabGroup("Text Popup")] public bool showLocaleSwapText = true;
    [TabGroup("Text Popup")] public Material localePopupMaterial = null;

    [TabGroup("Background")] [Tooltip("The background used for the location")] public List<Sprite> backgroundImage = new List<Sprite>();
    [TabGroup("Background")] [Tooltip("The background used for the location")] public List<string> backgroundImageIds = new List<string>();

    [TabGroup("Level")] public int recommendedLevel = 5;
    [TabGroup("Level")] public int encounterLevelVariabilityMin = -1;
    [TabGroup("Level")] public int encounterLevelVariabilityMax = 2;

    [TabGroup("Weather")] public float generalClimateMin = 30f;
    [TabGroup("Weather")] public float generalClimateAverage = 68f;
    [TabGroup("Weather")] public float generalClimateMax = 95f;
    [TabGroup("Weather")] public List<LocationalWeather> possibleWeather = new List<LocationalWeather>();

    [TabGroup("Skilling")] public int forageRegenerationMinutes = 0;
    [TabGroup("Skilling")] public int forageRegenerationHours = 0;
    [TabGroup("Skilling")] public int forageRegenerationDays = 25;
    [TabGroup("Skilling")] public string foragingLootID;
    [Space(10)]
    [TabGroup("Skilling")] public int miningRegenerationMinutes = 0;
    [TabGroup("Skilling")] public int miningRegenerationHours = 0;
    [TabGroup("Skilling")] public int miningRegenerationDays = 25;
    [TabGroup("Skilling")] public string miningLootID;
    [Space(10)]
    [TabGroup("Skilling")] public int fishingRegenerationMinutes = 0;
    [TabGroup("Skilling")] public int fishingRegenerationHours = 0;
    [TabGroup("Skilling")] public int fishingRegenerationDays = 25;
    [TabGroup("Skilling")] public int minFishingAttempts = 1;
    [TabGroup("Skilling")] public int maxFishingAttempts = 4;
    [TabGroup("Skilling")] public string fishingLootID;
}
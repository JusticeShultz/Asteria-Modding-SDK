using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class WeatherManager : MonoBehaviour
{
    public static WeatherManager Instance;

    [System.Serializable]
    public class LocationWeather
    {
        public string locationName;
        public LocationalWeather currentWeather;
        public WeatherObject linkedWeatherObject;
        public float weatherDuration;
        public float timeRemaining;
        public int currentTemperature;
    }
    
    public Dictionary<string, LocationWeather> locationCache = new Dictionary<string, LocationWeather>();

    public Transform effectRoot;

    public WeatherObject currentLocationsWeather = null;

    public static string currentWeather
    {
        get
        {
            return "";
        }
    }

    public static int currentTemperature
    {
        get
        {
            return -1;
        }
    }

    private void Start()
    {
    }
    
    public LocationWeather DetermineWeather(Location location)
    {
        return null;
    }

    private LocationalWeather DetermineWeatherBasedOnTemperature(float temperature, List<LocationalWeather> availableWeatherTypes)
    {
        return null;
    }

    private LocationalWeather PickLocationByWeight(List<LocationalWeather> choices)
    {
        return null;
    }

    private float DetermineWeatherDuration(LocationalWeather weatherType)
    {
        return 0f;
    }

    private void Update()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void TickHour()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void SimulateTimePassing()
    {
    }

    public WeatherObject SpawnWeatherEffect(GameObject effectToSpawn, LocationWeather locationalWeatherRef)
    {
        return null;
    }

    [TabGroup("Tools")]
    [Button]
    public void StopWeatherEffect(WeatherObject weatherObj)
    {
    }

    public float DetermineLocationsCurrentTemperature(Vector3 range)
    {
        return 0f;
    }

    [TabGroup("Tools")]
    [Button]
    public void DebugLogWeather()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void DebugLogCurrentTemperature()
    {
    }
}
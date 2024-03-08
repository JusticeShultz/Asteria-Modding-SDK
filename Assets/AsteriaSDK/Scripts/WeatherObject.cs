using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class WeatherObject : MonoBehaviour
{
    [TabGroup("Editor Data")] public string weatherName;
    [TabGroup("Editor Data")] public Animator animController;
    [TabGroup("Editor Data")] public WeatherManager.LocationWeather weatherCircularReference;

    [TabGroup("Tools")]
    [Button]
    public void StartWeather()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void StopWeather()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void Kill()
    {
    }
}

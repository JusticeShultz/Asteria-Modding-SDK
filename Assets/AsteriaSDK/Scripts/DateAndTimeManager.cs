using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class DateAndTimeManager : MonoBehaviour
{
    public static DateAndTimeManager Instance;

    [TabGroup("Data")] public int year = 1470;
    [TabGroup("Data")] public int month = 6;
    [TabGroup("Data")] public int day = 23;
    [TabGroup("Data")] public int hour = 14;
    [TabGroup("Data")] public int minute = 32;
    [TabGroup("Data")] public float second = 0;
    [TabGroup("Data")] public float timeScale = 1.0f;

    [TabGroup("Data")] public Gradient skyTimeColoration = new Gradient();

    [TabGroup("Data")] public List<Image> backgrounds = new List<Image>();

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        UpdateDateTime(Time.deltaTime * timeScale);

        foreach(Image background in backgrounds)
        {
            background.color = EvaluateSkyTimeColoration(hour, minute);
        }
    }

    [TabGroup("Tools")]
    [Button]
    private void UpdateDateTime(float deltaTime)
    {
    }

    public string GetDate()
    {
        return "";
    }

    public string GetTime()
    {
        return "";
    }

    string GetDayMonthYearString(int day, int currentMonth, int currentYear)
    {
        return "";
    }
    
    string GetFormattedTime(int currentHour, int currentMinute)
    {
        return "";
    }

    Color EvaluateSkyTimeColoration(int currentHour, int currentMinute)
    {
        return Color.white;
    }

    [TabGroup("Tools")]
    [Button]
    public void SimulateMinute(int minutes = 1)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void SimulateHour(int hours = 1)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public static void PassTime(int minutes, int hours)
    {
    }
}
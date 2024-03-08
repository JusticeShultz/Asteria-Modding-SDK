using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBarUpdate : MonoBehaviour
{
    public enum StatTargetType
    {
        Health, Stamina, Mana, Energy, XP, Level, Date, Time, Weather, Exhaustion, Hunger, Thirst, Coins, LocationName
    }

    public enum StatusBarType
    {
        FillBar, Text, ImageFill
    }

    public StatusBarType statusBarType;
    public StatTargetType statType;
    public float barFillSmoothness = 10f;
    public UnityEngine.UI.Image fillBar;
    //public TMPro.TextMeshProUGUI text;
    public bool updateOnTick = true;

    private void OnEnable()
    {
    }

    private void Awake()
    {
    }

    void Update()
    {
    }

    public void UpdateManually()
    {
    }

    public void Logic()
    {
    }
} 

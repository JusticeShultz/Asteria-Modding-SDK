using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUpdater : MonoBehaviour
{
    public string SettingName;
    [SerializeField] MultioptionButton button;
    [SerializeField] Slider slider;
    [SerializeField] Toggle toggle;
    
    void UpdateValue(int v)
    {
    }

    void UpdateValue(float v)
    {
    }

    void UpdateValue(bool v)
    {
    }

    private void OnValidate()
    {
    }

    public void Start()
    {
    }
}

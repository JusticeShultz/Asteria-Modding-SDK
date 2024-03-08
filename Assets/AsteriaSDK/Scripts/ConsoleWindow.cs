using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ConsoleWindow : MonoBehaviour
{
    public static ConsoleWindow reference;

    public float textReadInSpeed = 0.014f;

    //public TextMeshProUGUI monsterCombatText;

    public string currentConsoleText;

    public List<string> writeInQueue;

    public float timeStep = 0f;

    int lastSubTextIndex = 0;

    void Start()
    {
    }
    
    void Update()
    {
    }

    public static void WriteStringToQueue(string input)
    {
    }
    
    public void AddStringToQueue(string input)
    {
    }

    IEnumerator Typewrite(string text)
    {
        return null;
    }

    public static string Reverse(string s)
    {
        return "";
    }
    
    public void DebugAddToConsole(string text)
    {
    }

    public void ClearConsole()
    {
    }
}

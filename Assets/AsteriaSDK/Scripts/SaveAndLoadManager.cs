using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Linq;
using Sirenix.OdinInspector;

public class SaveAndLoadManager : MonoBehaviour
{
    public static SaveAndLoadManager Instance;
    
    public SaveFileInfo upForLoad = null;

    private void Start()
    {
    }

    public static void Save(string saveName)
    {
    }

    public static void Load(string saveName)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void SaveGame(string saveName)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void LoadGame(string saveName)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void GetSaveList()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void LocateUnpopulatedSaveFile()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void RecreateLoadMenu()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void SelectSaveForLoad(SaveFileInfo info)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void AcceptLoadSavePrompt()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void DenyLoadSavePrompt()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void ManuallySave()
    {
    }

    private IEnumerator ReloadSceneAndLoad(string saveName)
    {
        yield return new WaitForFixedUpdate();
    }
}

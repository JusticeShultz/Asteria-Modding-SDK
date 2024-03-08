using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class ForcedExplorationEvent
{
    public bool happensAnywhere = false;
    public Location locationOfEvent = null;
    public Encounter forcedEnounter = null;
}

public class ExplorationManager : MonoBehaviour
{
    public static ExplorationManager Instance;

    //public Febucci.UI.TypewriterByCharacter locationDiscoveredText;
    //public Febucci.UI.TypewriterByCharacter locationDiscoveredUnderline;
    //public Febucci.UI.TypewriterByCharacter locationDiscoveredLocation;
    
    public List<ForcedExplorationEvent> forcedExplorationEvents = new List<ForcedExplorationEvent>();

    public GameObject explorationModule;
    public GameObject explorationBar;
    public GameObject explorationLocationOverlays;

    public Animator clouds;
    
    public bool canExplore = false;
    public bool inExpedition = true;
    public bool exploring = false;

    public bool canExplore_Check
    {
        get
        {
            return false;
        }
    }

    public static bool CanExplore
    {
        get
        {
            return false;
        }
    }

    public static bool IsExploring
    { 
        get 
        { 
            return false; 
        } 
    }

    bool lastModuleState = false;

    private void Start()
    {
    }

    void Update()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void RefreshExplorationMenu()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void DiscoverLocation(Location location)
    {
    }

    public IEnumerator HideDiscovery()
    {
        yield return new WaitForSeconds(5.0f);
    }

    [TabGroup("Tools")]
    [Button]
    public void SetCanExplore(bool setTo)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void SetInExpedition(bool setTo)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void Explore()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void StartEncounter(Encounter startedEncounter)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void ForceExplorationEvent(ForcedExplorationEvent forcedExploration)
    {
    }

    public IEnumerator SetClouds(float delay, bool setTo)
    {
        yield return new WaitForSeconds(delay);
    }

    public IEnumerator StartDelayedEncounter(float delay, Encounter encounterToStart)
    {
        yield return new WaitForSeconds(delay);
    }

    public static Encounter SelectEncounter(List<Encounter> choices)
    {
        return null;
    }
    
    [TabGroup("Tools")]
    [Button]
    public void ClearAllForcedEncounters()
    {
    }
}

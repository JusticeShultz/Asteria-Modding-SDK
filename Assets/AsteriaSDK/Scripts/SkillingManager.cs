using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public enum FishingState
{
    NotCurrentlyFishing, Casting, WaitingForFish, FishChance, Reeling, Catch
}

public class SkillingManager : MonoBehaviour
{
    public static SkillingManager skillingManager;

    [TabGroup("Balancing - Fishing")] public float fishSurpriseForgiveness = 1.25f;
    [TabGroup("Balancing - Fishing")] public float reelInSpeed = 2.5f;
    [TabGroup("Balancing - Fishing")] public float tensionGain = 5f;
    [TabGroup("Balancing - Fishing")] public float reelInDifficultyScaling = 1f;
    [TabGroup("Balancing - Fishing")] public float tensionGainDifficultyScaling = 1f;
    
    [TabGroup("Game Data - Fishing")] public FishingState fishingState;
    [TabGroup("Game Data - Fishing")] public bool currentlyFishing = false;
    [TabGroup("Game Data - Fishing")] public bool surpriseEffectShown = false;
    [TabGroup("Game Data - Fishing")] public float currentLineDistance = 0f;
    [TabGroup("Game Data - Fishing")] public float castQuality = 0f;
    [TabGroup("Game Data - Fishing")] public float currentActionDelay = 0f;
    [TabGroup("Game Data - Fishing")] public float timeUntilBite = 0f;
    [TabGroup("Game Data - Fishing")] public float fishOnLineChanceTime = 0f;
    [TabGroup("Game Data - Fishing")] public float currentTension = 0f;

    [TabGroup("Editor References - Fishing")] public GameObject fishOnLineSurpriseIndicator;
    [TabGroup("Editor References - Fishing")] public Transform fishOnLineSurpriseAnchor;
    [TabGroup("Editor References - Fishing")] public GameObject fishingModule;
    [TabGroup("Editor References - Fishing")] public GameObject castModule;
    [TabGroup("Editor References - Fishing")] public GameObject reelModule;
    [TabGroup("Editor References - Fishing")] public Animator reelBarAnim;
    [TabGroup("Editor References - Fishing")] public Image castBar;
    [TabGroup("Editor References - Fishing")] public Image tensionBar;
    [TabGroup("Editor References - Fishing")] public Animator poorCast;
    [TabGroup("Editor References - Fishing")] public Animator poorReel;
    [TabGroup("Editor References - Fishing")] public Animator goodCast;
    [TabGroup("Editor References - Fishing")] public Animator goodReel;
    [TabGroup("Editor References - Fishing")] public Animator okayCast;
    [TabGroup("Editor References - Fishing")] public Animator okayReel;
    [TabGroup("Editor References - Fishing")] public Animator fantasticCast;
    [TabGroup("Editor References - Fishing")] public Animator fantasticReel;
    [TabGroup("Editor References - Fishing")] public Animator poleAnimation;
    //[TabGroup("Editor References - Fishing")] public TMPro.TextMeshProUGUI lineDistanceText;

    [TabGroup("Editor References - Hunting")]
    public GameObject huntingModule;

    [TabGroup("Editor References - Foraging")]
    public GameObject foragingModule;

    [TabGroup("Editor References - Mining")]
    public GameObject miningModule;

    void Start()
    {
    }

    void Update()
    {
    }
}

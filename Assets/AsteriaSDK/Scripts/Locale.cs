using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class Locale : MonoBehaviour
{
     public static Locale Instance;
     public static bool swapStatus = false;
     public static int lastRoll = -1;
     public static Location location
    {
        get
        {
            return Instance.currentLocation;
        }
    }

    [TabGroup("Locale Data")]  public Location currentLocation;
    [TabGroup("Locale Data")]  public Location cachedLocation; //Used for when a player enters a returnable location (like camp, a dungeon, etc.)
    [TabGroup("Locale Data")]  public Location savedLocation = null;

    [TabGroup("Editor Data")]  public Location startingLocation;
    //[TabGroup("Editor Data")]  public TMPro.TextMeshProUGUI localeTextRef;
    [TabGroup("Editor Data")]  public Animator localeAnimPlayer;
    [TabGroup("Editor Data")]  public Image backgroundA;
    [TabGroup("Editor Data")]  public Animator backgroundAAnimPlayer;
    [TabGroup("Editor Data")]  public Image backgroundB;
    [TabGroup("Editor Data")]  public Animator backgroundBAnimPlayer;

    
    public static Image currentBackground
    {
        get
        {
            return null;
        }
    }

    
    public static Sprite currentBackgroundSprite
    {
        get
        {
            return null;
        }
    }

    [TabGroup("Editor Data")]  public List<LocationOverlay> locationOverlays;
    [TabGroup("Editor Data")]  public List<StoryTagDependantObjects> storyTagDependantObjects;


    void Start()
    {
    }

    public static void LocaleSwap(Location locationToSwapTo)
    {
    }

    public static void LocaleSwap(Location locationToSwapTo, bool isTriggeredByLoad = false)
    {
    }

    private IEnumerator DelayedLocationOverlayChecks()
    {
        yield return new WaitForSeconds(0.005f);
    }

    public static void BackgroundSwap(Sprite background)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void DoSwap(Location location, bool isTriggeredByLoad = false)
    {
    }
}

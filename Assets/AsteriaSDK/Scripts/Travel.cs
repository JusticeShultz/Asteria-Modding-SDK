using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Travel : MonoBehaviour
{
    public static Travel Instance;

    [TabGroup("Data")] public List<GameObject> currentTravelObjects = new List<GameObject>();
    [TabGroup("Data")] public Location promptedLocation = null;

    [TabGroup("Editor Data")] public GameObject travelMenu;
    [TabGroup("Editor Data")] public GameObject travelTemplateObj;
    [TabGroup("Editor Data")] public GameObject travelLockedTemplateObj;
    [TabGroup("Editor Data")] public GameObject confirmationHUD;
    //[TabGroup("Editor Data")] public TMPro.TextMeshProUGUI confirmationText;
    
    private void Start()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void ConfirmTravel()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void CancelTravel()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void OpenTravelMenu()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public static void PromptTravel(Location toTravelTo)
    {
    }
}

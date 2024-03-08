using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelButton : MonoBehaviour
{
    public Location travelTo;
    //public TMPro.TextMeshProUGUI locationName;
    public Image locationImg;

    public void SendConfirmation()
    {
        Travel.PromptTravel(travelTo);
    }
}

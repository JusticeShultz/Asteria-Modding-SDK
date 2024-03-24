using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationOverlay : MonoBehaviour
{
    public bool locationRequired = true;
    public Location associatedLocation;
    public InteractionRequirement interactionRequirement = new InteractionRequirement();
    public List<Image> linkedIcons = new List<Image>();
    public List<Button> linkedButtons = new List<Button>();

    public bool active = false;
}

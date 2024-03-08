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

    private void Start()
    {
        if (gameObject.activeInHierarchy)
            StartCoroutine(Warmup());
    }

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
            StartCoroutine(Warmup());
    }

    private IEnumerator Warmup()
    {
        yield return new WaitForSeconds(0.1f);

        if (!Locale.Instance.locationOverlays.Contains(this))
            Locale.Instance.locationOverlays.Add(this);

        Check();
    }

    public void Check()
    {
        if (interactionRequirement.AllRequirementsMet())
        {
            if (locationRequired)
            {
                active = Locale.location.locationName == associatedLocation.locationName;

                if(Locale.location.locationName == associatedLocation.locationName)
                    if (gameObject.activeInHierarchy)
                        StartCoroutine(Activate());
                else
                    if (gameObject.activeInHierarchy)
                        StartCoroutine(Deactivate());
            }
            else
            {
                active = true;

                if (gameObject.activeInHierarchy)
                    StartCoroutine(Activate());
            }
        }
        else
        {
            active = false;

            if (gameObject.activeInHierarchy)
                StartCoroutine(Deactivate());
        }
    }

    private IEnumerator Activate()
    {
        foreach (Button b in linkedButtons)
            b.interactable = true;

        foreach (Image i in linkedIcons)
            i.raycastTarget = true;

        yield return new WaitForSeconds(0.5f);

        foreach (Button b in linkedButtons)
            b.gameObject.SetActive(true);

        foreach (Image i in linkedIcons)
            i.gameObject.SetActive(true);

        foreach (var icon in linkedIcons)
        {
            if (gameObject.activeInHierarchy)
                yield return StartCoroutine(FadeTo(icon, 1, 0.5f));
        }
        
        yield return null;
    }

    private IEnumerator Deactivate()
    {
        foreach (Button b in linkedButtons)
            b.interactable = false;

        foreach (Image i in linkedIcons)
            i.raycastTarget = false;

        foreach (var icon in linkedIcons)
        {
            if (gameObject.activeInHierarchy)
                yield return StartCoroutine(FadeTo(icon, 0, 0.1f));
        }

        foreach (Button b in linkedButtons)
            b.gameObject.SetActive(false);

        foreach (Image i in linkedIcons)
            i.gameObject.SetActive(false);

        yield return null;
    }

    private IEnumerator FadeTo(Image icon, float targetAlpha, float duration)
    {
        Color currentColor = icon.color;
        Color targetColor = new Color(currentColor.r, currentColor.g, currentColor.b, targetAlpha);
        float startTime = Time.time;

        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            icon.color = Color.Lerp(currentColor, targetColor, t);
            yield return null;
        }

        icon.color = targetColor;
    }
}

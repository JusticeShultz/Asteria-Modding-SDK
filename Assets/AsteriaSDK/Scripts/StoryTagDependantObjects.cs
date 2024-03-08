using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTagDependantObjects : MonoBehaviour
{
    public List<string> storyFlagsRequired = new List<string>();
    public List<string> storyFlagsNotAllowed = new List<string>();

    public List<GameObject> handledEnable;

    private void Start()
    {
        StartCoroutine(Warmup());
    }

    private IEnumerator Warmup()
    {
        yield return new WaitForSeconds(0.1f);
        Locale.Instance.storyTagDependantObjects.Add(this);
        gameObject.SetActive(false);
    }

    public void Check()
    {
        bool result = true;

        foreach (string requiredFlag in storyFlagsRequired)
            if (!PlayerStats.Instance.storyFlags.Contains(requiredFlag))
                result = false;

        foreach (string notAllowedFlag in storyFlagsNotAllowed)
            if (PlayerStats.Instance.storyFlags.Contains(notAllowedFlag))
                result = false;

        foreach (GameObject obj in handledEnable)
            obj.SetActive(result);
    }
}

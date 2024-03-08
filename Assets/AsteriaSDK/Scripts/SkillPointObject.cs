using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum SkillPointDirection
{
    TopLeft, Top, TopRight, Left, Right, BottomLeft, Bottom, BottomRight
}

public enum UsageTagAmount
{
    Single, List
}

public class SkillPointObject : MonoBehaviour
{
    [TabGroup("Configuration")] public int skillPointsRequired = 1;
    [TabGroup("Configuration")] public UsageTagAmount usageTagAmount;
    [TabGroup("Configuration")] [ShowIf("usageTagAmount", UsageTagAmount.Single)] public SerializedUsageTag triggeredUsageTag;
    [TabGroup("Configuration")] [ShowIf("usageTagAmount", UsageTagAmount.List)] public List<SerializedUsageTag> triggeredUsageTags = new List<SerializedUsageTag>();
    [TabGroup("Configuration")] public List<SkillPointObject> nextSkillPointObjectsInTree;
    [TabGroup("Configuration")] public List<SkillPointObject> requiredObjectsInTreeToUnlock;
    [TabGroup("Configuration")] public List<SkillPointDirection> previousSkillPointDirections;
    [TabGroup("Editor References")] public UnityEngine.UI.Image displayImg;
    [TabGroup("Editor References")] public UnityEngine.UI.Image highlight;
    [TabGroup("Editor References")] public UnityEngine.UI.Button interactionButton;
    [TabGroup("Editor References")] public UnityEngine.UI.Image topRightImg;
    [TabGroup("Editor References")] public UnityEngine.UI.Image topImg;
    [TabGroup("Editor References")] public UnityEngine.UI.Image topLeftImg;
    [TabGroup("Editor References")] public UnityEngine.UI.Image leftImg;
    [TabGroup("Editor References")] public UnityEngine.UI.Image rightImg;
    [TabGroup("Editor References")] public UnityEngine.UI.Image bottomLeftImg;
    [TabGroup("Editor References")] public UnityEngine.UI.Image bottomImg;
    [TabGroup("Editor References")] public UnityEngine.UI.Image bottomRightImg;
    
    void Start()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void Clicked()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void UpdateVisual()
    {
    }

    public bool RequirementsMet()
    {
        return false;
    }

    [TabGroup("Tools")]
    [Button]
    public void SmartPopulateDirections()
    {
        foreach(Transform child in transform)
        {
            if (child.gameObject.name == "Connector_Bottom")
                bottomImg = child.GetComponent<UnityEngine.UI.Image>();
            else if (child.gameObject.name == "Connector_Top")
                topImg = child.GetComponent<UnityEngine.UI.Image>();
            else if (child.gameObject.name == "Connector_BottomRight")
                bottomRightImg = child.GetComponent<UnityEngine.UI.Image>();
            else if (child.gameObject.name == "Connector_BottomLeft")
                bottomLeftImg = child.GetComponent<UnityEngine.UI.Image>();
            else if (child.gameObject.name == "Connector_TopRight")
                topRightImg = child.GetComponent<UnityEngine.UI.Image>();
            else if (child.gameObject.name == "Connector_TopLeft")
                topLeftImg = child.GetComponent<UnityEngine.UI.Image>();
            else if (child.gameObject.name == "Connector_Left")
                leftImg = child.GetComponent<UnityEngine.UI.Image>();
            else if (child.gameObject.name == "Connector_Right")
                rightImg = child.GetComponent<UnityEngine.UI.Image>();
        }
    }

    [TabGroup("Tools")]
    [Button]
    public void AddBranch(SkillPointDirection direction)
    {
        GameObject clone = Instantiate(gameObject, transform.parent);
        SkillPointObject spO = clone.GetComponent<SkillPointObject>();

        spO.topLeftImg.gameObject.SetActive(false);
        spO.topImg.gameObject.SetActive(false);
        spO.topRightImg.gameObject.SetActive(false);
        spO.leftImg.gameObject.SetActive(false);
        spO.rightImg.gameObject.SetActive(false);
        spO.bottomLeftImg.gameObject.SetActive(false);
        spO.bottomImg.gameObject.SetActive(false);
        spO.bottomRightImg.gameObject.SetActive(false);
        
        Vector3 topLeftDisplacement = new Vector3(-220.841582f * transform.parent.localScale.x, 215.9518f * transform.parent.localScale.y, 0f);
        Vector3 topDisplacement = new Vector3(0, 308.148182f * transform.parent.localScale.y, 0f);
        Vector3 topRightDisplacement = new Vector3(220.841582f * transform.parent.localScale.x, 215.9518f * transform.parent.localScale.y, 0f);
        Vector3 leftDisplacement = new Vector3(-308.148182f * transform.parent.localScale.x, 0, 0f);
        Vector3 rightDisplacement = new Vector3(308.148182f * transform.parent.localScale.x, 0, 0f);
        Vector3 bottomLeftDisplacement = new Vector3(-220.841582f * transform.parent.localScale.x, -215.9518f * transform.parent.localScale.y, 0f);
        Vector3 bottomDisplacement = new Vector3(0, -308.148182f * transform.parent.localScale.y, 0f);
        Vector3 bottomRightDisplacement = new Vector3(220.841582f * transform.parent.localScale.x, -215.9518f * transform.parent.localScale.y, 0f);

        spO.requiredObjectsInTreeToUnlock.Clear();
        spO.nextSkillPointObjectsInTree.Clear();
        spO.previousSkillPointDirections.Clear();

        nextSkillPointObjectsInTree.Add(spO);
        spO.requiredObjectsInTreeToUnlock.Add(this);
        spO.name = PlayerStats.GenerateCharacterID(10);

        if (direction == SkillPointDirection.TopLeft)
        {
            clone.transform.position = transform.position + topLeftDisplacement;
            spO.bottomRightImg.gameObject.SetActive(true);
            spO.previousSkillPointDirections.Add(SkillPointDirection.BottomRight);
        }
        else if (direction == SkillPointDirection.Top)
        {
            clone.transform.position = transform.position + topDisplacement;
            spO.bottomImg.gameObject.SetActive(true);
            spO.previousSkillPointDirections.Add(SkillPointDirection.Bottom);
        }
        else if (direction == SkillPointDirection.TopRight)
        {
            clone.transform.position = transform.position + topRightDisplacement;
            spO.bottomLeftImg.gameObject.SetActive(true);
            spO.previousSkillPointDirections.Add(SkillPointDirection.BottomLeft);
        }
        else if (direction == SkillPointDirection.Left)
        {
            clone.transform.position = transform.position + leftDisplacement;
            spO.rightImg.gameObject.SetActive(true);
            spO.previousSkillPointDirections.Add(SkillPointDirection.Right);
        }
        else if (direction == SkillPointDirection.Right)
        {
            clone.transform.position = transform.position + rightDisplacement;
            spO.leftImg.gameObject.SetActive(true);
            spO.previousSkillPointDirections.Add(SkillPointDirection.Left);
        }
        else if (direction == SkillPointDirection.BottomLeft)
        {
            clone.transform.position = transform.position + bottomLeftDisplacement;
            spO.topRightImg.gameObject.SetActive(true);
            spO.previousSkillPointDirections.Add(SkillPointDirection.TopRight);
        }
        else if (direction == SkillPointDirection.Bottom)
        {
            clone.transform.position = transform.position + bottomDisplacement;
            spO.topImg.gameObject.SetActive(true);
            spO.previousSkillPointDirections.Add(SkillPointDirection.Top);
        }
        else if (direction == SkillPointDirection.BottomRight)
        {
            clone.transform.position = transform.position + bottomRightDisplacement;
            spO.topLeftImg.gameObject.SetActive(true);
            spO.previousSkillPointDirections.Add(SkillPointDirection.TopLeft);
        }
    }
}

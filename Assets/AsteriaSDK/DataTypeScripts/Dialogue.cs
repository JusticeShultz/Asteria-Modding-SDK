using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum DialogueType
{
    NormalChat, Branch, Reward, GiveQuest
}

[System.Serializable]
public class RewardLootTable
{
    public int minXP;
    public int maxXP;
    public int minCurrency;
    public int maxCurrency;
    public List<RewardItemStack> table;
}


[System.Serializable]
public class RewardItemStack
{
    public SerializedItem item;
    public int count;

    //Used only by the loot table.
    public int maxCount;
}

[System.Serializable]
public class FishingLootTableItem
{
    public Item item;
    public bool givesMoreThanOne = false;
    public int minAmount;
    public int maxAmount;

    public float qualityReqirement = 0.5f;
    public int catchWeightChance = 1;
    public float catchDifficulty = 1f;

}

[System.Serializable] public class RewardObject
{
    public int xp;
    public int currency;
    public List<RewardItemStack> items;
    public List<RewardLootTable> additiveLootTable;
}

[System.Serializable] public class BranchObject
{
    public string dialogueOptionText;
    public Dialogue switchToDialogue;
    public string switchToDialogueId;
    public bool setsDialogueBackWhenComplete = false;
    public InteractionRequirement interactionRequirements;
    public List<SerializedUsageTag> usageTagsOnSelect = new List<SerializedUsageTag>();
}

[System.Serializable] public class DialogueObject
{
    [TabGroup("Dialogue")] public string name = "NULL";
    [TabGroup("Dialogue")] [TextArea(10, 100)] public string text = "Hmmm...";
    [TabGroup("Style")] public Color nameColor = Color.white;
    [TabGroup("Style")] public Color textColor = Color.white;
    [TabGroup("Dialogue")] public Sprite characterIcon = null;
    [TabGroup("Dialogue")] public string characterIconId = "";

    [TabGroup("Dialogue")] public DialogueType dialogueType = DialogueType.NormalChat;
    [TabGroup("Outcomes")] [ShowIf("@dialogueType == DialogueType.Branch")] public List<BranchObject> branchObjects = new List<BranchObject>();
    [TabGroup("Outcomes")] [ShowIf("@dialogueType == DialogueType.Reward")] public RewardObject rewardObject = new RewardObject();
    [TabGroup("Outcomes")] [ShowIf("@dialogueType == DialogueType.Reward")] public string rewardObjectId;
    [TabGroup("Outcomes")] [ShowIf("@dialogueType == DialogueType.GiveQuest")] public Quest givenQuest = null;
    [TabGroup("Outcomes")] [ShowIf("@dialogueType == DialogueType.GiveQuest")] public string givenQuestId;
    [TabGroup("Outcomes")] public Location swapToLocation = null;
    [TabGroup("Outcomes")] public string swapToLocationId = "";
    [TabGroup("Outcomes")] public bool learnLocationFromSwap = false;
    [TabGroup("Outcomes")] public bool onlyLearnWithNoSwap = false;
    [TabGroup("Outcomes")] public string storyFlag = "None";
    [TabGroup("Outcomes")] public string triggeredStoryEvent = "None";
    [TabGroup("Outcomes")] public bool transitionPortrait = false;
    [TabGroup("Outcomes")] public bool forcesConversationEnd = false;
    [TabGroup("Outcomes")] public List<SerializedUsageTag> triggeredUsageTags = new List<SerializedUsageTag>();
    [TabGroup("Style")] public float hideDialogueForSeconds = 0f;
    [TabGroup("Style")] public bool localizeName = true;
}

[HideMonoScript]
[CreateAssetMenu(fileName = "New Dialogue", menuName = "Asteria/Dialogue", order = 10)]
public class Dialogue : ScriptableObject
{
    [TabGroup("Dialogue")] public List<DialogueObject> orderedDialogue = new List<DialogueObject>();
    [TabGroup("Dialogue")] public Dialogue transitionToAfterEnd;
    [TabGroup("Dialogue")] public string transitionToAfterEndId;
    [TabGroup("Localization")] public LocalizationTable associatedLocalizationTable;
    //[TabGroup("Localization")] public string associatedLocalizationTableId; Localization tables are not yet moddable. This will be added in a future update.

    /*
     * Checks the associated localization table for each dialogue object entry.
     * If the characters name or dialogue text isn't in the entry, add it and then translate it.
     */
    [TabGroup("Localization")]
    [Button("Auto Localize Dialogue + Auto Restranslate")]
    public void AutoTranslate_True()
    {
        AutoTranslate(true);
    }

    [TabGroup("Localization")]
    [Button("Auto Localize Dialogue")]
    public void AutoTranslate_False()
    {
        AutoTranslate(false);
    }

    [TabGroup("Localization")]
    [Button]
    public void AutoTranslate(bool retranslate)
    {
        Debug.Log("Auto translation has began...");

        bool tableNeedsReTranslation = false;

        foreach (DialogueObject dialogueObject in orderedDialogue)
        {
            //Debug.Log("Current translation check - " + dialogueObject.name + ": " + dialogueObject.text);
            bool nameNeedsTranslating = true;
            bool textNeedsTranslating = true;
            
            foreach(LocalizedString localizedString in associatedLocalizationTable.localizedStrings)
            {
                //Debug.Log("Checking: " + localizedString.localizedStrings[0].text);

                if (localizedString.localizedStrings[0].text == dialogueObject.name)
                {
                    //Debug.Log("Name already exists in table, moving on...");
                    nameNeedsTranslating = false;
                }

                if (localizedString.localizedStrings[0].text == dialogueObject.text)
                {
                    //Debug.Log("Text already exists in table, moving on...");
                    textNeedsTranslating = false;
                }
            }

            if (nameNeedsTranslating)
            {
                Debug.Log("Name needs translating...");
                associatedLocalizationTable.localizedStrings.Add(new LocalizedString(associatedLocalizationTable.localizedStrings[0], dialogueObject.name));
                Debug.Log("Name added to table: " + dialogueObject.name);
                //associatedLocalizationTable.localizedStrings[associatedLocalizationTable.localizedStrings.Count].translated = false;
                tableNeedsReTranslation = true;
#if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(associatedLocalizationTable);
#endif
            }

            if (textNeedsTranslating)
            {
                Debug.Log("Text needs translating...");
                associatedLocalizationTable.localizedStrings.Add(new LocalizedString(associatedLocalizationTable.localizedStrings[0], dialogueObject.text));
                Debug.Log("Text added to table: " + dialogueObject.text);
                //associatedLocalizationTable.localizedStrings[associatedLocalizationTable.localizedStrings.Count].translated = false;
                tableNeedsReTranslation = true;
#if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(associatedLocalizationTable);
#endif
            }
        }

        if(tableNeedsReTranslation && retranslate)
        {
            Debug.Log("Table marked for retranslation process, please wait...");
            associatedLocalizationTable.AutoTranslate();
        }

        Debug.Log("Translation marking process complete.");
    }
}

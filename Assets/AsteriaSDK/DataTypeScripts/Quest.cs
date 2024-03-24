using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Sirenix.OdinInspector;

public enum QuestType
{
    Standard, //The standard quest setup
    Sequence, //Sequence quests require other quests to be completed first to complete it
    Kill, //Completed by killing a certain number of a certain kind of enemy
    InteractionRequirements //Makes use of the interaction requirements system.
}

[System.Serializable]
public class MonsterBounty
{
    public string monsterName = "???";
    public int amountToKill = 10;
    public int amountKilled = 0;
}

[HideMonoScript]
[CreateAssetMenu(fileName = "New Quest", menuName = "Asteria/Quest", order = 10)]
public class Quest : ScriptableObject
{
    [TabGroup("Quest Details")] public QuestType questType = QuestType.Sequence;
    [TabGroup("Quest Details")] public string questName = "???";
    [TabGroup("Quest Details")] [TextArea] public string questShortExplanation = "???"; //Shows in the sidemenu quest window.
    [TabGroup("Quest Details")] [TextArea] public string questExplanation = "???"; //Shows in the quest manager tab.
    [TabGroup("Quest Details")] public List<string> additionalQuestGoals = new List<string>();
    [TabGroup("Quest Details")] [ShowIf("@questType == QuestType.Sequence")] public List<Quest> requiredQuestsToBeCompleted = new List<Quest>();
    [TabGroup("Quest Details")] public float startingProgress = 0;
    [TabGroup("Quest Details")] public float startingGoal = 100;
    [TabGroup("Quest Details")] [ShowIf("@questType == QuestType.Kill")] public List<MonsterBounty> targetMonsters = new List<MonsterBounty>();
    [TabGroup("Quest Details")] [ShowIf("@questType == QuestType.InteractionRequirements")] public InteractionRequirement iRequirements = new InteractionRequirement();
    [TabGroup("Quest Details")] public string questTag = "???";
    [TabGroup("Quest Outcomes")] public RewardLootTable questCompletionRewards = new RewardLootTable();
    [TabGroup("Quest Outcomes")] public List<SerializedUsageTag> triggeredUsageTagsOnQuestCompleted = new List<SerializedUsageTag>();
    [TabGroup("Quest Outcomes")] public List<Quest> nextQuests = new List<Quest>();
    [TabGroup("Quest Outcomes")] public Dialogue questCompletionDialogue = null;
}
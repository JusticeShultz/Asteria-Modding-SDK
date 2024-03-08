using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public Transform questTabContent;
    public GameObject questTemplate;
    //public TMPro.TextMeshProUGUI questTemplate_title;
    //public TMPro.TextMeshProUGUI questTemplate_details;

    float updateDelay = 3f;
    float questCompleteCheckDelay = 2f;

    void Start()
    {
    }
    
    void Update()
    {
    }

    public void UpdateQuestTab()
    {
    }

    [Obsolete]
    private void FinishQuest(Quest quest)
    {
    }

    public void MonsterKilled(Monster monster)
    {
    }

    public void AddQuest(Quest givenQuest)
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    [TabGroup("Skill Manager Data")] public SpellInteraction hoveredInteraction = null;
    [TabGroup("Skill Manager Data")] public bool hoveredInteractionIsValid = false;

    [TabGroup("Skill Manager Data")] public List<Skill> registeredSkills = new List<Skill>();
    [TabGroup("Skill Manager Data")] public QueuedSkill queuedSkill = null;

    [TabGroup("Editor Data")] public GameObject channelBar;
    [TabGroup("Editor Data")] public Image channelBar_Fill;
    [TabGroup("Editor Data")] public GameObject windupBar;
    [TabGroup("Editor Data")] public Image windupBar_Fill;
    [TabGroup("Editor Data")] public GameObject tutorialTooltipObj;
    [TabGroup("Editor Data")] public GameObject nextTutorialTooltipObj;

    [TabGroup("Editor Data")] public GameObject skillInformationPanel;
    //[TabGroup("Editor Data")] public Febucci.UI.TextAnimator_TMP skillName;
    //[TabGroup("Editor Data")] public Febucci.UI.TextAnimator_TMP skillDescription;
    //[TabGroup("Editor Data")] public Febucci.UI.TextAnimator_TMP skillCost_HP;
    //[TabGroup("Editor Data")] public Febucci.UI.TextAnimator_TMP skillCost_ST;
    //[TabGroup("Editor Data")] public Febucci.UI.TextAnimator_TMP skillCost_MP;
    //[TabGroup("Editor Data")] public Febucci.UI.TextAnimator_TMP skillCost_CD;

    [TabGroup("Events")] public UnityEvent onSpellFizzle = new UnityEvent();
    [TabGroup("Events")] public UnityEvent onSkillFailed = new UnityEvent();
    [TabGroup("Events")] public UnityEvent onMiss = new UnityEvent();
    [TabGroup("Events")] public UnityEvent onFleeFailed = new UnityEvent();
    
    public class QueuedSkill
    {
        public Skill skill;
        public UnitStats caster;
        public UnitStats target;
        public SpellInteraction spellInteraction;
        public float channelTime = 0f;
        public float windupTime = 0f;

        public QueuedSkill()
        {
        }

        public QueuedSkill(Skill s)
        {
        }

        public QueuedSkill(Skill s, UnitStats t, UnitStats c, SpellInteraction interaction = null)
        {
        }
    }

    public class SerializedQueuedSkill
    {
        public SerializedSkill skill;
        public UnitStats caster;
        public UnitStats target;
        public SpellInteraction spellInteraction;
        public float channelTime = 0f;
        public float windupTime = 0f;

        public SerializedQueuedSkill()
        {
        }

        public SerializedQueuedSkill(SerializedSkill s)
        {
        }

        public SerializedQueuedSkill(SerializedSkill s, UnitStats t, UnitStats c, SpellInteraction interaction = null)
        {
        }
    }
    
    private void Start()
    {
    }

    public void Update()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void UseSkill(Skill skill, SpellInteraction spellInteraction, UnitStats caster, UnitStats target)
    {
    }

    public bool CanAffordResourceCost(Skill skill, UnitStats target = null)
    {
        return false;
    }

    public int CanAffordResourceCost_ReturnTypeMissing(Skill skill, EnemyCard target = null)
    {
        return 0;
    }

    public bool IsValueWithinPercentageThreshold(float percentage, float currentValue, float maxValue)
    {
        return false;
    }

    public static float CalculatePercentage(float percentage, float value)
    {
        return 0;
    }

    public bool IsValueWithinPercentageThreshold(float percentage, float currentValue)
    {
        return false;
    }
    
    [TabGroup("Tools")]
    [Button]
    public static void InflictSerializedUsageTag(SerializedUsageTag uTag, UnitStats caster, UnitStats target, float power = 1.0f)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void PlayerRest()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void PlayerAttemptFlee()
    {
    }

    public static float GetCountOfUsageTagValueFromItem(UsageType usageType, SerializedItem item)
    {
        return 0f;
    }

    public static float GetFloatFromString(string input)
    {
        return 0f;
    }

    public static int GetIntFromString(string input)
    {
        return 0;
    }
    
    public static int GetEnemyPhysicalDamageHit(int tagValue, EnemyCard enemyRef)
    {
        return 0;
    }
}

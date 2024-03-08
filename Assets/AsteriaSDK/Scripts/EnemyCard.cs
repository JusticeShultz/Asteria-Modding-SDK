using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SkillManager;
#if UNITY_EDITOR
using UnityEditor.Experimental.GraphView;
#endif
using Sirenix.OdinInspector;

public class EnemyCard : UnitStats
{
    //[TabGroup("Unit Data", "Editor References")] public TextMeshProUGUI nameText;
    //[TabGroup("Unit Data", "Editor References")] public Febucci.UI.TextAnimator_TMP animatedNameText;
    //[TabGroup("Unit Data", "Editor References")] public TextMeshProUGUI lvText;
    [TabGroup("Unit Data", "Editor References")] public Image enemyImage;
    [TabGroup("Unit Data", "Editor References")] public Image healthBar01;
    [TabGroup("Unit Data", "Editor References")] public Image healthBar02;
    [TabGroup("Unit Data", "Editor References")] public Image staminaBar01;
    [TabGroup("Unit Data", "Editor References")] public Image staminaBar02;
    [TabGroup("Unit Data", "Editor References")] public Image manaBar01;
    [TabGroup("Unit Data", "Editor References")] public Image manaBar02;
    [TabGroup("Unit Data", "Editor References")] public Image icon_plannedAttack;
    [TabGroup("Unit Data", "Editor References")] public Image icon_cursing;
    [TabGroup("Unit Data", "Editor References")] public Image icon_selfDefending;
    [TabGroup("Unit Data", "Editor References")] public Image icon_selfAttackUp;
    [TabGroup("Unit Data", "Editor References")] public Image icon_lowerEnemyDefence;
    [TabGroup("Unit Data", "Editor References")] public Image icon_lowerEnemyAttack;
    [TabGroup("Unit Data", "Editor References")] public Image icon_stun;
    [TabGroup("Unit Data", "Editor References")] public Image icon_healing;
    [TabGroup("Unit Data", "Editor References")] public GameObject channelBar_Obj;
    [TabGroup("Unit Data", "Editor References")] public GameObject windupBar_Obj;
    [TabGroup("Unit Data", "Editor References")] public GameObject textAnchor;
    [TabGroup("Unit Data", "Editor References")] public Image channelBar_Img;
    [TabGroup("Unit Data", "Editor References")] public Image windupBar_Img;
    [TabGroup("Unit Data", "Editor References")] public GameObject templateStatusEffect;
    [TabGroup("Unit Data", "Editor References")] public GameObject textContainer;
    [TabGroup("Unit Data", "Editor References")] public Animator animator;
    [TabGroup("Unit Data", "Editor References")] public MouseHoveredCallback hoveredStatus;
    [TabGroup("Unit Data", "System Set")] public Sprite selectedImage = null;
    [TabGroup("Unit Data", "System Set")] public bool isFriendly = false;
    [TabGroup("Unit Data", "System Set")] public bool alive = true;
    [TabGroup("Unit Data", "System Set")] public float currentActionDelay = 3f;
    [TabGroup("Unit Data", "System Set")] public float livingTime = 0f;
    [TabGroup("Unit Data", "System Set")] public Monster baseMonster;
    [TabGroup("Unit Data", "System Set")] public SerializedQueuedSkill queuedSkill;
    [TabGroup("Unit Data", "System Set")] public bool eligibleLootDrop = true;

    private void Start()
    {
    }

    public override void Update()
    {
    }
    
    [TabGroup("Unit Data", "Tools")]
    [Button]
    public virtual void RefreshEnemyCard()
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public virtual void Kill()
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void InflictDeathTag(UsageTag tag)
    {
    }
    
    public static string GetMonsterNameAndLevel(Combat.Enemy enemyToRead)
    {
        return "";
    }
    
    [TabGroup("Unit Data", "Tools")]
    [Button]
    public SerializedSkill CalculateSkillForCombat()
    {
        return null;
    }
    
    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void PopulateCallback()
    {
    }

    public bool CanAffordResourceCost(SerializedSkill skill, EnemyCard caster)
    {
        return false;
    }

    public bool IsValueWithinPercentageThreshold(float percentage, float currentValue, float maxValue)
    {
        return false;
    }

    public float CalculatePercentage(float percentage, float value)
    {
        return 0f;
    }

    public bool IsValueWithinPercentageThreshold(float percentage, float currentValue)
    {
        return false;
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public void AddStatusEffect(StatusEffect status, EnemyCard caster, EnemyCard target, float lifetimeOfStatus, float statusEffectStrength = 1.0f)
    {
    }
    
    public virtual void OnDestroy()
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public virtual void Initialize(Monster inputMonster, int inputLevel)
    {
    }

    public virtual UnitStats SelectTarget(AIHelper usage)
    {
        return null;
    }
    
    public override void KillUnit()
    {
    }
}
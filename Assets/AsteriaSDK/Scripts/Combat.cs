using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using Sirenix.OdinInspector;

public class Combat : MonoBehaviour
{
    public static Combat Instance;
    public static SpellInteraction currentSpellInteraction;
    
    [TabGroup("Combat Data")] public bool inCombat = false;
    [TabGroup("Combat Data")] public List<GameObject> destroyOnCombatEnd = new List<GameObject>();
    [TabGroup("Combat Data")] public List<EnemyCard> currentEnemyCards = new List<EnemyCard>();
    [TabGroup("Combat Data")] public bool tickToggle = false;
    [TabGroup("Combat Data")] public float enemiesSpawningCooldown = 0.5f;
    [TabGroup("Combat Data")] public float combatPaused = 0f;
    [TabGroup("Combat Data")] public float timeSinceCombatEnded = 0;
    [TabGroup("Combat Data")] public bool lastCombatState = false;
    [TabGroup("Editor Data")] public List<EnemyLayout> enemyLayouts = new List<EnemyLayout>();
    [TabGroup("Editor Data")] public Transform combatTab;
    [TabGroup("Editor Data")] public Animator combatTab_Anim;
    [TabGroup("Editor Data")] public Transform enemyContainer;
    [TabGroup("Editor Data")] public GameObject companionTemplate;
    [TabGroup("Editor Data")] public Transform companionContainer;
    [TabGroup("Editor Data")] public Transform enemyStatusEffectsContainer;
    [TabGroup("Editor Data")] public Transform enemyTextContainer;
    [TabGroup("Editor Data")] public GameObject indicatorText;
    [TabGroup("Editor Data")] public GameObject indicatorText_centered;
    [TabGroup("Editor Data")] public Transform playerIndicatorDamageMarker;
    [TabGroup("Editor Data")] public Transform playerCastedSuccessMarker;
    [TabGroup("Editor Data")] public MouseHoveredCallback targetSelfCallback;
    //[TabGroup("Editor Data")] public TMPro.TextMeshProUGUI countdownTxt;
    [TabGroup("Editor Data")] public UnityEngine.UI.Image countdownSlider;
    [TabGroup("Editor Data")] public Monster initialMonsterTest = null;
    [TabGroup("Editor Data")] public Skill defaultRestSkill;
    [TabGroup("Editor Data")] public Skill defaultFleeSkill;
    [TabGroup("Editor Data")] public Skill defaultStartingSkill;
    [TabGroup("Editor Data")] public GameObject tutorialTooltips;
    [TabGroup("Editor Data")] public List<StatusEffect> registeredStatusEffects = new List<StatusEffect>();

    [System.Serializable]
    public class Enemy
    {
        public Monster baseMonster;

        public int level;
        public float maxHealth;
        public float currentHealth;
        public float maxMana;
        public float currentMana;
        public float maxStamina;
        public float currentStamina;

        public int addedInnatePhysicalArmor = 0;
        public int addedInnateMagicalArmor = 0;

        public SerializedSkill restSkill = null;
        public List<SerializedSkill> skills = new List<SerializedSkill>();

        [SerializeField] public List<AppliableStatusEffect> statusEffects = new List<AppliableStatusEffect>();

        public List<Language> learnedLanguages = new List<Language>();

        public SkillManager.SerializedQueuedSkill queuedSkill;

        public int GetCalculatedStat(string statName)
        {
            return 0;
        }

        public int GetCurrentCritChance()
        {
            return 0;
        }

        public bool CritCheck()
        {
            return false;
        }

        public string GetNameAndLevel()
        {
            return "";
        }

        public string GetDisplayNameAndLevel()
        {
            return "";
        }

        public void GiveHealth(float amount)
        {
        }

        public void TakeHealth(float amount)
        {
        }

        public void GiveStamina(float amount)
        {
        }

        public void TakeStamina(float amount)
        {
        }

        public void GiveMana(float amount)
        {
        }

        public void TakeMana(float amount)
        {
        }
    }
        
    [TabGroup("Events")] public UnityEvent onCombatComplete = new UnityEvent();
    [TabGroup("Events")] public UnityEvent onCombatFlee = new UnityEvent();
    
    void Start()
    {
    }
    
    void Update()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void PlayerFleeCombat()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void StartCombat(List<Monster> inputMonsters, int[] inputLevels)
    {
    }
    
    [TabGroup("Tools")]
    [Button]
    public void SpawnEnemy(Monster inputMonster, int inputLevel)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public Companion SpawnCompanion(Monster inputMonster, int inputLevel, bool ignoreMaxCompanionCount = false)
    {
        return null;
    }

    [TabGroup("Tools")]
    [Button]
    public void UpdateEnemyLayout()
    {
    }

    public static StatusEffect GetStatusEffectByName(string nameOfStatus)
    {
        return null;
    }

    [TabGroup("Tools")]
    [Button]
    public static void CleanTemporaryCombatObjects()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public static void AddStatusEffectToPlayer(StatusEffect status, int lifetimeOfStatus, float statusEffectStrength = 1.0f)
    {
    }

    public List<EnemyLayout> GetEnemyLayoutsForCombatSize(int combatSize)
    {
        return null;
    }
    
    public EnemyLayout RandomlySelectLayout(List<EnemyLayout> layouts)
    {
        return null;
    }

    [TabGroup("Tools")]
    [Button]
    public void LaunchSpell(string spellID, SpellInteraction interactionCallback = null)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public static void CreateVisualText(string displayText, Transform parentTransform, Vector3 offset, Vector3 scale, float lifetime, bool centered)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public static void BeginCombat(List<Monster> monsters, int[] levels)
    {
    }
}

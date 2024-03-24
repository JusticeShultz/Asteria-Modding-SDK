//using UnityEditor;
//using UnityEngine;

//public class BasicModifier : Modifier
//{
//    [SerializeField] public int addStrength;
//    [SerializeField] public float multiplyStrength = 1f;
//    [SerializeField] public int addStrengthLevelScaling;
//    [SerializeField] public float multiplyStrengthLevelScaling;

//    [SerializeField] public int addConstitution;
//    [SerializeField] public float multiplyConstitution = 1f;
//    [SerializeField] public int addConstitutionLevelScaling;
//    [SerializeField] public float multiplyConstitutionLevelScaling;

//    [SerializeField] public int addDexterity;
//    [SerializeField] public float multiplyDexterity = 1f;
//    [SerializeField] public int addDexterityLevelScaling;
//    [SerializeField] public float multiplyDexterityLevelScaling;

//    [SerializeField] public int addIntelligence;
//    [SerializeField] public float multiplyIntelligence = 1f;
//    [SerializeField] public int addIntelligenceLevelScaling;
//    [SerializeField] public float multiplyIntelligenceLevelScaling;

//    [SerializeField] public int addAwareness;
//    [SerializeField] public float multiplyAwareness = 1f;
//    [SerializeField] public int addAwarenessLevelScaling;
//    [SerializeField] public float multiplyAwarenessLevelScaling;

//    [SerializeField] public int addStealth;
//    [SerializeField] public float multiplyStealth = 1f;
//    [SerializeField] public int addStealthLevelScaling;
//    [SerializeField] public float multiplyStealthLevelScaling;

//    [SerializeField] public int addArcana;
//    [SerializeField] public float multiplyArcana = 1f;
//    [SerializeField] public int addArcanaLevelScaling;
//    [SerializeField] public float multiplyArcanaLevelScaling;

//    [SerializeField] public int addLuck;
//    [SerializeField] public float multiplyLuck = 1f;
//    [SerializeField] public int addLuckLevelScaling;
//    [SerializeField] public float multiplyLuckLevelScaling;

//    [SerializeField] public int addInitiative;
//    [SerializeField] public float multiplyInitiative = 1f;
//    [SerializeField] public int addInitiativeLevelScaling;
//    [SerializeField] public float multiplyInitiativeLevelScaling;

//    [SerializeField] public int addMuscle;
//    [SerializeField] public float multiplyMuscle = 1f;
//    [SerializeField] public int addMuscleLevelScaling;
//    [SerializeField] public float multiplyMuscleLevelScaling;

//    [SerializeField] public int addBrawn;
//    [SerializeField] public float multiplyBrawn = 1f;
//    [SerializeField] public int addBrawnLevelScaling;
//    [SerializeField] public float multiplyBrawnLevelScaling;

//    [SerializeField] public int addArmor;
//    [SerializeField] public float multiplyArmor = 1f;
//    [SerializeField] public int addArmorLevelScaling;
//    [SerializeField] public float multiplyArmorLevelScaling;

//    [SerializeField] public int addMagicResist;
//    [SerializeField] public float multiplyMagicResist = 1f;
//    [SerializeField] public int addMagicResistLevelScaling;
//    [SerializeField] public float multiplyMagicResistLevelScaling;

//    [SerializeField] public float addMaxHealth;
//    [SerializeField] public float multiplyMaxHealth = 1f;
//    [SerializeField] public float addMaxHealthLevelScaling;
//    [SerializeField] public float multiplyMaxHealthLevelScaling;

//    [SerializeField] public float addMissingHealth;
//    [SerializeField] public float multiplyMissingHealth = 1f;
//    [SerializeField] public float addMissingHealthLevelScaling;
//    [SerializeField] public float multiplyMissingHealthLevelScaling;

//    [SerializeField] public float addMaxMana;
//    [SerializeField] public float multiplyMaxMana = 1f;
//    [SerializeField] public float addMaxManaLevelScaling;
//    [SerializeField] public float multiplyMaxManaLevelScaling;

//    [SerializeField] public float addMissingMana;
//    [SerializeField] public float multiplyMissingMana = 1f;
//    [SerializeField] public float addMissingManaLevelScaling;
//    [SerializeField] public float multiplyMissingManaLevelScaling;

//    [SerializeField] public float addMissingStamina;
//    [SerializeField] public float multiplyMissingStamina = 1f;
//    [SerializeField] public float addMissingStaminaLevelScaling;
//    [SerializeField] public float multiplyMissingStaminaLevelScaling;

//    [SerializeField] public float addMaxStamina;
//    [SerializeField] public float multiplyMaxStamina = 1f;
//    [SerializeField] public float addMaxStaminaLevelScaling;
//    [SerializeField] public float multiplyMaxStaminaLevelScaling;

//    [SerializeField] public float addMissingEnergy;
//    [SerializeField] public float multiplyMissingEnergy = 1f;
//    [SerializeField] public float addMissingEnergyLevelScaling;
//    [SerializeField] public float multiplyMissingEnergyLevelScaling;

//    [SerializeField] public float addMaxEnergy;
//    [SerializeField] public float multiplyMaxEnergy = 1f;
//    [SerializeField] public float addMaxEnergyLevelScaling;
//    [SerializeField] public float multiplyMaxEnergyLevelScaling;

//    [SerializeField] public float addCurrentEnergy;
//    [SerializeField] public float multiplyCurrentEnergy = 1f;
//    [SerializeField] public float addCurrentEnergyLevelScaling;
//    [SerializeField] public float multiplyCurrentEnergyLevelScaling;

//    [SerializeField] public float addAttackSpeed;
//    [SerializeField] public float multiplyAttackSpeed = 1f;
//    [SerializeField] public float addAttackSpeedLevelScaling;
//    [SerializeField] public float multiplyAttackSpeedLevelScaling;

//    [SerializeField] public float addCooldownReduction;
//    [SerializeField] public float multiplyCooldownReduction = 1f;
//    [SerializeField] public float addCooldownReductionLevelScaling;
//    [SerializeField] public float multiplyCooldownReductionLevelScaling;

//    [SerializeField] public float addMaxCarryWeight;
//    [SerializeField] public float multiplyMaxCarryWeight = 1f;
//    [SerializeField] public float addMaxCarryWeightLevelScaling;
//    [SerializeField] public float multiplyMaxCarryWeightLevelScaling;

//    [SerializeField] private bool _combatOnly;
//    public bool combatOnly { get => _combatOnly; }

//    public override void ModifyStat(InteractionStat stat, ref int value, int Level)
//    {
//        switch (stat)
//        {
//            case InteractionStat.Strength:
//                value = Mathf.FloorToInt((float)value * (multiplyStrength + multiplyStrengthLevelScaling * Level) + addStrength + addStrengthLevelScaling * Level);
//                break;
//            case InteractionStat.Constitution:
//                value = Mathf.FloorToInt((float)value * (multiplyConstitution + multiplyConstitutionLevelScaling * Level) + addConstitution + addConstitutionLevelScaling * Level);
//                break;
//            case InteractionStat.Dexterity:
//                value = Mathf.FloorToInt((float)value * (multiplyDexterity + multiplyDexterityLevelScaling * Level) + addDexterity + addDexterityLevelScaling * Level);
//                break;
//            case InteractionStat.Intelligence:
//                value = Mathf.FloorToInt((float)value * (multiplyIntelligence + multiplyIntelligenceLevelScaling * Level) + addIntelligence + addIntelligenceLevelScaling * Level);
//                break;
//            case InteractionStat.Awareness:
//                value = Mathf.FloorToInt((float)value * (multiplyAwareness + multiplyAwarenessLevelScaling * Level) + addAwareness + addAwarenessLevelScaling * Level);
//                break;
//            case InteractionStat.Stealth:
//                value = Mathf.FloorToInt((float)value * (multiplyStealth + multiplyStealthLevelScaling * Level) + addStealth + addStealthLevelScaling * Level);
//                break;
//            case InteractionStat.Arcana:
//                value = Mathf.FloorToInt((float)value * (multiplyArcana + multiplyArcanaLevelScaling * Level) + addArcana + addArcanaLevelScaling * Level);
//                break;
//            case InteractionStat.Luck:
//                value = Mathf.FloorToInt((float)value * (multiplyLuck + multiplyLuckLevelScaling * Level) + addLuck + addLuckLevelScaling * Level);
//                break;
//            case InteractionStat.Initiative:
//                value = Mathf.FloorToInt((float)value * (multiplyInitiative + multiplyInitiativeLevelScaling * Level) + addInitiative + addInitiativeLevelScaling * Level);
//                break;
//            case InteractionStat.Muscle:
//                value = Mathf.FloorToInt((float)value * (multiplyMuscle + multiplyMuscleLevelScaling * Level) + addMuscle + addMuscleLevelScaling * Level);
//                break;
//            case InteractionStat.Brawn:
//                value = Mathf.FloorToInt((float)value * (multiplyBrawn + multiplyBrawnLevelScaling * Level) + addBrawn + addBrawnLevelScaling * Level);
//                break;
//            case InteractionStat.Armor:
//                value = Mathf.FloorToInt((float)value * (multiplyArmor + multiplyArmorLevelScaling * Level) + addArmor + addArmorLevelScaling * Level);
//                break;
//            case InteractionStat.MagicResist:
//                value = Mathf.FloorToInt((float)value * (multiplyMagicResist + multiplyMagicResistLevelScaling * Level) + addMagicResist + addMagicResistLevelScaling * Level);
//                break;
//        }
//    }

//    public override void ModifyStat(InteractionStat stat, ref float value, int Level)
//    {
//        switch (stat)
//        {
//            case InteractionStat.MaxHealth:
//                value = Mathf.FloorToInt((float)value * (multiplyMaxHealth + multiplyMaxHealthLevelScaling * Level) + addMaxHealth + addMaxHealthLevelScaling * Level);
//                break;
//            case InteractionStat.MissingHealth:
//                value = Mathf.FloorToInt((float)value * (multiplyMissingHealth + multiplyMissingHealthLevelScaling * Level) + addMissingHealth + addMissingHealthLevelScaling * Level);
//                break;
//            case InteractionStat.MaxMana:
//                value = Mathf.FloorToInt((float)value * (multiplyMaxMana + multiplyMaxManaLevelScaling * Level) + addMaxMana + addMaxManaLevelScaling * Level);
//                break;
//            case InteractionStat.MissingMana:
//                value = Mathf.FloorToInt((float)value * (multiplyMissingMana + multiplyMissingManaLevelScaling * Level) + addMissingMana + addMissingManaLevelScaling * Level);
//                break;
//            case InteractionStat.MissingStamina:
//                value = Mathf.FloorToInt((float)value * (multiplyMissingStamina + multiplyMissingStaminaLevelScaling * Level) + addMissingStamina + addMissingStaminaLevelScaling * Level);
//                break;
//            case InteractionStat.MaxStamina:
//                value = Mathf.FloorToInt((float)value * (multiplyMaxStamina + multiplyMaxStaminaLevelScaling * Level) + addMaxStamina + addMaxStaminaLevelScaling * Level);
//                break;
//            case InteractionStat.MissingEnergy:
//                value = Mathf.FloorToInt((float)value * (multiplyMissingEnergy + multiplyMissingEnergyLevelScaling * Level) + addMissingEnergy + addMissingEnergyLevelScaling * Level);
//                break;
//            case InteractionStat.MaxEnergy:
//                value = Mathf.FloorToInt((float)value * (multiplyMaxEnergy + multiplyMaxEnergyLevelScaling * Level) + addMaxEnergy + addMaxEnergyLevelScaling * Level);
//                break;
//            case InteractionStat.AttackSpeed:
//                value = Mathf.FloorToInt((float)value * (multiplyAttackSpeed + multiplyAttackSpeedLevelScaling * Level) + addAttackSpeed + addAttackSpeedLevelScaling * Level);
//                break;
//            case InteractionStat.CooldownReduction:
//                value = Mathf.FloorToInt((float)value * (multiplyCooldownReduction + multiplyCooldownReductionLevelScaling * Level) + addCooldownReduction + addCooldownReductionLevelScaling * Level);
//                break;
//            case InteractionStat.MaxCarryWeight:
//                value = Mathf.FloorToInt((float)value * (multiplyMaxCarryWeight + multiplyMaxCarryWeightLevelScaling * Level) + addMaxCarryWeight + addMaxCarryWeightLevelScaling * Level);
//                break;
//        }
//    }
//}
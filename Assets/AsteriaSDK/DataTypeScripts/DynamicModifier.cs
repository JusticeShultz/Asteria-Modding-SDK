using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum ScalingType { Linear, Exponential, Percentage, Logarithmic, Randomized}

[Serializable]
struct ModifierComponent
{
    public ScalingType ScalingType;
    public float baseStat;
    public float multiplyStat;
    public float minScalingRange;
    public float maxScalingRange;
    public float scalingFactor;
}

class DynamicModifier : Modifier
{
    [SerializeField] public int addStrength;
    public Dictionary<InteractionStat, ModifierComponent> modifierComponents;
    public override void ModifyStat(InteractionStat stat, ref int value, int level) { }
    public override void ModifyStat(InteractionStat stat, ref float value, int level) { }
    public override bool combatOnly { get; }
}
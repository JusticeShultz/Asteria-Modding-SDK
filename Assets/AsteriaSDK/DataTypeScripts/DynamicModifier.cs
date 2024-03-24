using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public enum ScalingType { Linear, Exponential, Percentage, Logarithmic, Randomized}//Randomized does not work yet
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
[ShowOdinSerializedPropertiesInInspector]
class DynamicModifier : Modifier
{
    [SerializeField] public int addStrength;
    [OdinSerialize] public Dictionary<InteractionStat, ModifierComponent> modifierComponents;
    public override void ModifyStat(InteractionStat stat, ref int value, int level) {

        //if(modifierComponents.TryGetValue(stat, out ModifierComponent modifierComponent))
        //{
        //    switch (modifierComponent.ScalingType)
        //    {
        //        case ScalingType.Linear:
        //            break;
        //        case ScalingType.Exponential:
        //            break;
        //        case ScalingType.Percentage:
        //            break;
        //        case ScalingType.Logarithmic:
        //            break;
        //        case ScalingType.Randomized:
        //            break;
        //    }
        //}
    }
    public override void ModifyStat(InteractionStat stat, ref float value, int level) { }
    public override bool combatOnly { get; } //If true, modifier is removed at the end of combat
}
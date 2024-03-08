#if UNITY_EDITOR
using System;
using UnityEditor;
#endif
using UnityEngine;

public enum ModifierSource { Item, StatusEffect }

[System.Serializable]
public class Modifier
{
    //If performance is poor, split this into a new method for each stat. however, performance should not be a issue
    public virtual void ModifyStat(InteractionStat stat, ref int value, int level) { }
    public virtual void ModifyStat(InteractionStat stat, ref float value, int level) { }
    public virtual bool combatOnly { get; } //If true, modifier is removed at the end of combat
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class DroppableItem
{
    public Item item;

    [Tooltip("The min amount that may be dropped.")]
    public int minPossible = 1;
    [Tooltip("The max amount that may be dropped.")]
    public int maxPossible = 1;
    [Tooltip("The chance this item will be picked to drop. The higher the more likely.")]
    public int dropWeight = 1;

    [Tooltip("Determines if there's a requirement for the item to be dropped.")]
    public bool usesInteractionRequirements = false;
    [Sirenix.OdinInspector.ShowIf("@usesInteractionRequirements == true")]
    [Tooltip("The requirements for the item to be dropped.")]
    public InteractionRequirement interactionRequirements = new InteractionRequirement();

    public int CalculateDrops()
    {
        return 1;
    }
}

[CreateAssetMenu(fileName = "DefaultLootPool", menuName = "Asteria/Loot Pool", order = 15)]
public class LootPool : ScriptableObject
{
    public int amountDroppedMin = 1;
    public int amountDroppedMax = 1;

    [Tooltip("All rarities are decided based on the rarity assigned to the item. This is a pool of all possible drops for this monster, chest, quest, etc.")]
    public List<DroppableItem> items = new List<DroppableItem>();
    [Tooltip("Used for quests & stuff, rewards are guaranteed.")]
    public List<DroppableItem> guaranteedItems = new List<DroppableItem>();

    public int CalculateDropCount()
    {
        return 1;
    }
}
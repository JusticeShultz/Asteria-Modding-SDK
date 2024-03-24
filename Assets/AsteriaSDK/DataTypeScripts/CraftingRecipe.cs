using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemStack
{
    public Item item;
    public int count;
}

[System.Serializable]
public class ItemIDStack
{
    public string itemID;
    public int count;
}

[Sirenix.OdinInspector.HideMonoScript]
[CreateAssetMenu(fileName = "DefaultCraftingRecipe", menuName = "Asteria/Crafting Recipe", order = 0)]
public class CraftingRecipe : ScriptableObject
{
    //Alternative recipes will need a new recipe object.
    public List<ItemStack> recipeRequirement = new List<ItemStack>();
    public List<ItemStack> recipeProduction = new List<ItemStack>();
    public int requiredStationLevel = 1;
}
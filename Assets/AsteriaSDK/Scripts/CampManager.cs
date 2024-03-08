using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class CampManager : MonoBehaviour
{
    public static CampManager Instance;

    public static bool inCamp
    {
        get
        {
            return Locale.Instance.currentLocation != null && Locale.Instance.currentLocation.locationName == "Camp";
        }
    }

    public static bool campUnlocked
    {
        get
        {
            return PlayerStats.Instance.storyFlags.Contains("Camp_Unlocked");
        }
    }

    public static bool skillingUnlocked
    {
        get
        {
            return PlayerStats.Instance.storyFlags.Contains("Skilling_Unlocked");
        }
    }

    public static bool travelingUnlocked
    {
        get
        {
            return PlayerStats.Instance.storyFlags.Contains("Traveling_Unlocked");
        }
    }

    [TabGroup("Camp Data")] public bool campDisabled = false;
    [TabGroup("Camp Data")] public List<CraftingRecipe> cookableRecipes;
    [TabGroup("Camp Data")] public SerializedItem failedRecipeDefaultItem;
    [TabGroup("Camp Data")] public GameObject campModule;

    [TabGroup("Events")] public UnityEvent onAllowCampAccess = new UnityEvent();
    [TabGroup("Events")] public UnityEvent onDisableCampAccess = new UnityEvent();
    [TabGroup("Events")] public UnityEvent onAllowSkillingAccess = new UnityEvent();
    [TabGroup("Events")] public UnityEvent onDisableSkillingAccess = new UnityEvent();
    [TabGroup("Events")] public UnityEvent onAllowTravelAccess = new UnityEvent();
    [TabGroup("Events")] public UnityEvent onDisableTravelAccess = new UnityEvent();


    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if(inCamp && DialogueManager.Instance.transitionDelay <= 0f && !DialogueManager.InDialogue)
        {
            campModule.SetActive(true);
        }
        else
        {
            campModule.SetActive(false);
        }
    }

    [TabGroup("Tools")]
    [Button]
    public void LeaveCamp()
    {
        StartCoroutine(LeaveCampDelayed());
    }

    public IEnumerator LeaveCampDelayed()
    {
        yield return new WaitForSeconds(0.3f);
        Locale.LocaleSwap(Locale.Instance.cachedLocation);
        Locale.Instance.cachedLocation = null;
    }

    [TabGroup("Tools")]
    [Button]
    public void CampfireCook(SerializedItem a, SerializedItem b, SerializedItem c, SerializedItem d)
    {
        List<SerializedItem> validIngredients = new List<SerializedItem>();

        if (a != null && a.itemTemplate != null)
            validIngredients.Add(a);
        if (b != null && b.itemTemplate != null)
            validIngredients.Add(b);
        if (c != null && c.itemTemplate != null)
            validIngredients.Add(c);
        if (d != null && d.itemTemplate != null)
            validIngredients.Add(d);

        foreach(SerializedItem sI in validIngredients)
        {
            if (sI.itemTemplate.typeOfItem != ItemType.Consumable && sI.itemTemplate.typeOfItem != ItemType.Misc)
            {
                Debug.Log("Attempted to cook, but an ingredient type was invalid... (only consumable and misc items can be used in recipes.)");
                return;
            }
        }

        if(validIngredients.Count > 0)
        {
            bool recipeFound = false;

            foreach(CraftingRecipe cRecipe in cookableRecipes)
            {
                //This will be a nice filter to remove any possible conflicts and speed up overall lookup tables.
                //This also catches any offcase where ingredients match a lesser crafting result when you have more ingredients.
                if(cRecipe.recipeRequirement.Count == validIngredients.Count)
                {
                    bool recipeIsCraftable = true;

                    foreach(ItemStack requiredItem in cRecipe.recipeRequirement)
                    {
                        bool itemFound = false;
                        
                        foreach(SerializedItem validItem in validIngredients)
                        {
                            if (validItem.itemTemplate.nameOfItem == requiredItem.item.nameOfItem)
                            {
                                if (validItem.stackCount >= requiredItem.count)
                                    itemFound = true;
                            }
                        }

                        //If any item is missing from the recipe break out and continue looking.
                        if(!itemFound)
                        {
                            recipeIsCraftable = false;
                            break;
                        }
                    }

                    //If we found a recipe that our ingredients match, make it.
                    if(recipeIsCraftable)
                    {
                        recipeFound = true;

                        Debug.Log("Recipe was valid, adding resulting item(s)...");

                        foreach (ItemStack stackedResult in cRecipe.recipeProduction)
                        {
                            InventoryManager.Instance.AddItemToInventory(stackedResult.item, stackedResult.count);
                        }

                        break;
                    }
                }
            }

            //Remove ingredients from inventory
            foreach(SerializedItem vIng in validIngredients)
            {
                InventoryManager.Instance.RemoveCountOfItemFromInventory(vIng, 1);
            }

            //If we found no recipe, add 1 of the failed item.
            if(!recipeFound)
            {
                Debug.Log("No valid recipe found, adding failed item...");
                InventoryManager.Instance.AddItemToInventory(failedRecipeDefaultItem);
            }
        }
        else
        {
            Debug.Log("Attempted to cook, but no ingredients were provided...");
        }
    }
}

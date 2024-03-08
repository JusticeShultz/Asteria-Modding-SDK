using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class InventoryManager : MonoBehaviour
{
     public static InventoryManager Instance;

    [TabGroup("Inventory")]  public float combatConsumeDelay = 5f;
    [TabGroup("Inventory")]
     [Tooltip("This determines what the loot pool considers Rare, so if a monster can't drop rares from loot pools, this is whats considered rare from the roll weight.")]
    public int rareWeightThreshold = 12;

    [TabGroup("Inventory")]  public float currentConsumptionCooldown = 0f;
    [TabGroup("Inventory")]  public float setConsumptionCooldown = 0f;

    [TabGroup("Inventory")]  public SerializedItem selectedItem = null;
    [TabGroup("Inventory")]  public bool selectedItemIsEquipped = false;

    [TabGroup("Inventory")]  public ItemUITemplate selectedTemplate = null;

    [TabGroup("Inventory")] public bool inventoryOpen = false;
    
    [TabGroup("Inventory")] public List<SerializedItem> currentLootAvailable = new List<SerializedItem>();

    [TabGroup("Editor References")]  public GameObject lootModule;
    [TabGroup("Editor References")]  public Transform inventoryLoot;
    [TabGroup("Editor References")]  public bool lootTabOpen
    {
        get
        {
            return false;
        }
    }
    
    [TabGroup("Editor References")]  public GameObject inventoryModule;
    [TabGroup("Editor References")]  public RectTransform inventoryModuleRectTrsfm;
    [TabGroup("Editor References")]  public ItemUITemplate itemTemplate;
    [TabGroup("Editor References")]  public Transform inventoryWeapons;
    [TabGroup("Editor References")]  public Transform inventoryEquipment;
    [TabGroup("Editor References")]  public Transform inventoryConsumables;
    [TabGroup("Editor References")]  public Transform inventoryMisc;
    //[TabGroup("Editor References")]  public TMPro.TextMeshProUGUI weightText;
    [TabGroup("Editor References")]  public GameObject inspectionTab;
    //[TabGroup("Editor References")]  public TMPro.TextMeshProUGUI itemName;
    //[TabGroup("Editor References")]  public TMPro.TextMeshProUGUI itemFlavor;
    //[TabGroup("Editor References")]  public TMPro.TextMeshProUGUI itemClassification;
    //[TabGroup("Editor References")]  public TMPro.TextMeshProUGUI itemValue;
    //[TabGroup("Editor References")]  public TMPro.TextMeshProUGUI itemRarity;
    [TabGroup("Editor References")]  public Slider discardAmountSlider;
    //[TabGroup("Editor References")]  public TMPro.TextMeshProUGUI discardAmountText;
    [TabGroup("Editor References")]  public Transform consumableStatuses;
    //[TabGroup("Editor References")]  public TMPro.TextMeshProUGUI consumableStatusTemplate;
    [TabGroup("Editor References")]  public GameObject itemConsumeCooldownBar;
    [TabGroup("Editor References")]  public Image itemConsumeCooldownFill;
    [TabGroup("Editor References")]  public GameObject selectionContainer;

    [TabGroup("Editor References")]  public GameObject equipmentPlaceholder_Helmet;
    [TabGroup("Editor References")]  public GameObject equipmentPlaceholder_Necklace;
    [TabGroup("Editor References")]  public GameObject equipmentPlaceholder_EarringA;
    [TabGroup("Editor References")]  public GameObject equipmentPlaceholder_EarringB;
    [TabGroup("Editor References")]  public GameObject equipmentPlaceholder_Gloves;
    [TabGroup("Editor References")]  public GameObject equipmentPlaceholder_Bracelet;
    [TabGroup("Editor References")]  public GameObject equipmentPlaceholder_Chestplate;
    [TabGroup("Editor References")]  public GameObject equipmentPlaceholder_Belt;
    [TabGroup("Editor References")]  public GameObject equipmentPlaceholder_Pants;
    [TabGroup("Editor References")]  public GameObject equipmentPlaceholder_Boots;
    [TabGroup("Editor References")]  public GameObject equipmentPlaceholder_RingA;
    [TabGroup("Editor References")]  public GameObject equipmentPlaceholder_RingB;
    [TabGroup("Editor References")]  public GameObject equipmentPlaceholder_WeaponA;
    [TabGroup("Editor References")]  public GameObject equipmentPlaceholder_WeaponB;

    [TabGroup("Editor References")]  private GameObject equipmentTemp_Helmet;
    [TabGroup("Editor References")]  private GameObject equipmentTemp_Necklace;
    [TabGroup("Editor References")]  private GameObject equipmentTemp_EarringA;
    [TabGroup("Editor References")]  private GameObject equipmentTemp_EarringB;
    [TabGroup("Editor References")]  private GameObject equipmentTemp_Gloves;
    [TabGroup("Editor References")]  private GameObject equipmentTemp_Bracelet;
    [TabGroup("Editor References")]  private GameObject equipmentTemp_Chestplate;
    [TabGroup("Editor References")]  private GameObject equipmentTemp_Belt;
    [TabGroup("Editor References")]  private GameObject equipmentTemp_Pants;
    [TabGroup("Editor References")]  private GameObject equipmentTemp_Boots;
    [TabGroup("Editor References")]  private GameObject equipmentTemp_RingA;
    [TabGroup("Editor References")]  private GameObject equipmentTemp_RingB;
    [TabGroup("Editor References")]  private GameObject equipmentTemp_WeaponA;
    [TabGroup("Editor References")]  private GameObject equipmentTemp_WeaponB;


    void Start()
    {
    }

    void Update()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void SetInventoryStatus(bool status)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void OpenInventory()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void ToggleInventory()
    {
    }
    
    public float GetCurrentInventoryWeight()
    {
        return 0f;
    }
    
    public bool CanCarryWeightOfNewItem(SerializedItem _item, int _amount = 1)
    {
        return false;
    }

    [TabGroup("Tools")]
    [Button]
    public void AddItemToInventory(Item _item, int _amount = 1, int _level = 1)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void AddItemToInventory(Item _item, int _amount = 1)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void AddItemToInventory(Item _item)
    {
    }
    
    [TabGroup("Tools")]
    [Button]
    public void AddItemToInventory(SerializedItem _item, int _amount = 1)
    {
    }
    
    [TabGroup("Tools")]
    [Button]
    public void MaxSelectedItemLevel()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void Equip(bool secondary = false)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void Unequip(string itemID = "DOITFORME")
    {
    }

    public void SetEquippedWeapon(Item item)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void AlertItemAdded(SerializedItem _item, int _amount = 1)
    {
    }
    
    [TabGroup("Tools")]
    [Button]
    public void SimpleLoot(LootPool lootPool, int itemLevel = 1)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void Loot(LootPool lootPool, int level = 1, bool canLootRareItems = true)
    {
    }

    public DroppableItem SelectLootDrop(List<DroppableItem> droppableItems)
    {
        return null;
    }
    
    [TabGroup("Tools")]
    [Button]
    public void UpdateInventory(bool forceRefreshShop = false)
    {
    }
    
    [TabGroup("Tools")]
    [Button]
    public void RecreateInventory(bool forceRefreshShop = false)
    {
    }
    
    [TabGroup("Tools")]
    [Button]
    public void CleanInventoryComponents()
    {
    }
    
    [TabGroup("Tools")]
    [Button]
    public void ClearInventoryLoot()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void ClearSelectedItem()
    {
    }
    
    public static void DestroyTheChild(Transform parentTransform)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void SelectItem(SerializedItem sItem, bool onlyRefresh = false, bool isEquipment = false)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void ConsumeItem()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void ConfirmDiscardItem(int amountToDiscard)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void ConfirmDiscardItem(Slider discardSlider)
    {
    }
    
    public void ModifyStackData(ref SerializedItem data, int to)
    {
    }
    
    [TabGroup("Tools")]
    [Button]
    public void RemoveCountOfItemFromInventory(ref SerializedItem remove, int amount)
    {
    }
    
    [TabGroup("Tools")]
    [Button]
    public void RemoveCountOfItemFromInventory(SerializedItem remove, int amount)
    {
    }
    
    public static void CreateVisualText(string displayText, Transform parentTransform, Vector3 offset, Vector3 scale, float lifetime, bool centered, bool repointed = true)
    {
    }
}

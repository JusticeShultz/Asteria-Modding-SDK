using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemUITemplate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image rarityFrame;
    public Image itemIcon;
    //public TMPro.TextMeshProUGUI itemCount;
    public GameObject select_weaponNonTwohanded;
    public GameObject select_equipment;
    public GameObject select_equipmentSlottable;
    public GameObject select_consumable;
    public GameObject select_misc;
    public GameObject select_equippedItem;
    public GameObject clickObjRef;
    public SerializedItem linkedItem;
    public GameObject shopPriceObj;
    //public TMPro.TextMeshProUGUI shopPrice;

    public Slider discardAmountSlider;
    //public TMPro.TextMeshProUGUI discardAmountText;

    public bool tooltipOnHover = true;

    [HideInInspector] public bool isLoot = false;
    [HideInInspector] public bool isEquipment = false;
    [HideInInspector] public bool isMerchantItem = false;
    public bool tooltipDisabled = false;

    bool hovered = false;

    private void Update()
    {
    }

    private void OnDestroy()
    {
    }

    private void OnDisable()
    {
    }

    public void UpdateFrame(bool showStack = true)
    {
    }

    public void OnClick()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public static Color RarityColor(Rarity rarity)
    {
        return Color.white;
    }

    public static string RarityText(Rarity rarity)
    {
        return "";
    }

    public static string ItemTypeText(ItemType type, string overrideText = "NA")
    {
        return "";
    }
    
    public void InspectItem()
    {
    }
    
    public void Equip()
    {
    }

    public void Unequip()
    {
    }

    public void EquipSecondary()
    {
    }

    public void Consume()
    {
    }
    
    public void AttemptPurchase()
    {
    }

    public void Discard(Slider targetSlider)
    {
    }
}

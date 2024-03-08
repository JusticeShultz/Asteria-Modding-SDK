using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class MerchantManager : MonoBehaviour
{
    public static MerchantManager Instance;

    public Merchant currentMerchant = null;

    public static bool IsInMerchantMenu
    {
        get
        {
            return false;
        }
    }

    [Required] public GameObject merchantModule;
    [Required] public RectTransform inventoryAnchor;
    [Required] public Transform merchantInventory;
    [Required] public RectTransform resultTextAnchor;
    [Required] public RectTransform noCompareTooltipAnchor;
    //[Required] public TMPro.TextMeshProUGUI merchantName;
    //[Required] public TMPro.TextMeshProUGUI ratesText;

    void Start()
    {
    }

    void Update()
    {
    }

    [Button]
    public void InitializeMerchant(Merchant merchant)
    {
    }

    [Button]
    public void CloseMerchant()
    {
    }

    public void RecreateMerchantInventory()
    {
    }
}

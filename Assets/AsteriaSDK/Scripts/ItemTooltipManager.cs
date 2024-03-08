using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltipManager : MonoBehaviour
{
    public static ItemTooltipManager Instance = null;
    public static SerializedItem hoveredItem = null;
    public static RectTransform targetRectTransform;
    public static bool renderUpdateNeeded = true;
    public RectTransform tooltipAnchor;

    public Vector3 tooltipOffset = new Vector3(0, 50, 0);
    public float compareTabOffset = 1f;
    public float padding = 25f;
    public float maxY = 800f;
    public float minY = 250f;
    public float referenceWidth = 3840f;
    public float referenceHeight = 2160f;

    public GameObject itemTooltipTab;
    //public TMPro.TextMeshProUGUI item_name;
    //public TMPro.TextMeshProUGUI item_type;
    //public TMPro.TextMeshProUGUI item_value;
    //public TMPro.TextMeshProUGUI item_weight;
    //public TMPro.TextMeshProUGUI item_durability;
    //public TMPro.TextMeshProUGUI itemStatField;
    public Image item_icon;
    public Image item_background;
    public RectTransform itemTooltipRect;

    public GameObject compare_itemTooltipTab;
    //public TMPro.TextMeshProUGUI compare_item_name;
    //public TMPro.TextMeshProUGUI compare_item_type;
    //public TMPro.TextMeshProUGUI compare_item_value;
    //public TMPro.TextMeshProUGUI compare_item_weight;
    //public TMPro.TextMeshProUGUI compare_item_durability;
    //public TMPro.TextMeshProUGUI compare_itemStatField;
    public Image compare_item_icon;
    public Image compare_item_background;
    public RectTransform compare_itemTooltipRect;
    public RectTransform compare_maxRightRect;
    
    void Start()
    {
    }
    
    void Update()
    {
    }

    public void CheckAndRenderSecondaryCompareTooltip()
    {
    }

    public static void DestroyTheChild(Transform parentTransform)
    {
    }

    public static bool IsObjectOnLeftSide(Vector3 objectPosition)
    {
        return false;
    }
}

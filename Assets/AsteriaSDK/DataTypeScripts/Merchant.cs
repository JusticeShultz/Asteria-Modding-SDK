using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Sirenix.OdinInspector.HideMonoScript]
[CreateAssetMenu(fileName = "DefaultMerchant", menuName = "Asteria/Merchant", order = 10)]
public class Merchant : ScriptableObject
{
    public string shopKeeperName = "Bob, The General Merchant";

    public List<SerializedItem> shopItems;

    public float merchantSellRate = 1.35f; //how much the item sells for.
    public float merchantBuyRate = 0.25f; //how much the merchant buys for.

    public List<string> openingStatements = new List<string>();
    public List<string> purchasingStatements = new List<string>();
    public List<string> exitingStatements = new List<string>();
    
    public void InitializeMerchant(int level)
    {
        foreach(SerializedItem item in shopItems)
        {
            item.level = Mathf.Clamp(level + Random.Range(-8, 2), 1, 9999999);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationDisabledExitInventoryButton : MonoBehaviour
{
    public GameObject ifDisabled;
    public GameObject enableIfDisabled;

    void Update()
    {
        if (MerchantManager.IsInMerchantMenu)
        {
            enableIfDisabled.SetActive(false);
        }
        else
            enableIfDisabled.SetActive(ifDisabled.activeSelf);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    public static TownManager Instance;
    public static bool InTown
    {
        get
        {
            return Locale.Instance.currentLocation.isTown;
        }
    }


    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        
    }
}

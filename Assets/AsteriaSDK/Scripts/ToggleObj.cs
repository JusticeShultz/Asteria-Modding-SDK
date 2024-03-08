using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObj : MonoBehaviour
{
    public void ToggleActivity(GameObject target)
    {
        target.SetActive(!target.activeSelf); 
    }
}

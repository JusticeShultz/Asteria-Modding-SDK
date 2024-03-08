using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class CombatSkin : MonoBehaviour
{
    public static CombatSkin Instance;

    public List<Image> affectedElements = new List<Image>();

    public Material skin;

    private void Start()
    {
    }

    [Button("Update Skin")]
    public void UpdateSkin()
    {
    }

    public void ChangeSkin(Material mat)
    {
    }
}

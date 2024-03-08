using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewElement", menuName = "Asteria/Magical Element", order = 1)]
public class MagicElement : ScriptableObject
{
    public string ElementName = "Element";

    public Color associatedColor = Color.white;

    public List<MagicElement> resistances = new List<MagicElement>();
    public List<MagicElement> weaknesses = new List<MagicElement>();

    public GameObject associatedEnemyCard_Normal;
    public GameObject associatedEnemyCard_Elite;
    public GameObject associatedEnemyCard_Boss;

    public MagicElement()
    {
    }

    public MagicElement(string nm, Color clr, List<MagicElement> res, List<MagicElement> weak)
    {
    }
}

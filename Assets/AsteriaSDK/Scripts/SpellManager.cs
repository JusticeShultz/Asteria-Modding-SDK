using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SpellManager : MonoBehaviour
{
     public static SpellManager Instance;

    [TabGroup("Data")] public SpellSlot middleSlot;
    [TabGroup("Data")] public SpellSlot leftSlot;
    [TabGroup("Data")] public SpellSlot rightSlot;
    [TabGroup("Data")] public SpellSlot leftmostSlot;
    [TabGroup("Data")] public SpellSlot rightmostSlot;

    [TabGroup("Data")] public SpellPointerLine spellPointerLine;

    [TabGroup("Data")] public SerializedSkill serializedSpell1;
    [TabGroup("Data")] public SerializedSkill serializedSpell2;
    [TabGroup("Data")] public SerializedSkill serializedSpell3;
    [TabGroup("Data")] public SerializedSkill serializedSpell4;
    [TabGroup("Data")] public SerializedSkill serializedSpell5;
    [TabGroup("Data")] public UnityEngine.UI.Image restingMantraImg;

    private void Start()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void InitializeSpellManager()
    {
    }

    void Update()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void SetSpellPointerStatus(bool status, Vector3 startPoint)
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class Companion : EnemyCard
{
    bool nameNeedsRefresh = true;

    public GameObject interactionMenuButton;
    public GameObject interactionMenuSubmenu;

    public override void Kill()
    {
    }

    public void KillFromEvolve()
    {
    }

    public override void Update()
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public override void RefreshEnemyCard()
    {
    }

    public override void OnDestroy()
    {
    }

    [TabGroup("Unit Data", "Tools")]
    [Button]
    public override void Initialize(Monster inputMonster, int inputLevel)
    {
    }

    public override UnitStats SelectTarget(AIHelper usage)
    {
        return null;
    }

    public void DisbandCompanion()
    {
    }

    public override void OnLevelUp()
    {
    }
    
    public override void KillUnit()
    {
    }
}

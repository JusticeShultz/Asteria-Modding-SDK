using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCombatEncounterDebug : MonoBehaviour
{
    public List<Monster> monsters = new List<Monster>();
    public List<int> levels = new List<int>();

    public void StartCombatEncounter()
    {
        Combat.Instance.StartCombat(monsters, levels.ToArray());
    }
}

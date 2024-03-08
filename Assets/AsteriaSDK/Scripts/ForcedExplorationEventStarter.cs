using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ForcedExplorationEventStarter : MonoBehaviour
{
    public ForcedExplorationEvent forcedExplorationEvent;
    
    [Button]
    public void ApplyForcedExplorationEvent()
    {
        ExplorationManager.Instance.ForceExplorationEvent(forcedExplorationEvent);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class EnemyLayout : MonoBehaviour
{
    public int layoutSize
    {
        get
        {
            return enemyCardPositions.Count;
        }
    }

    public List<GameObject> enemyCardPositions = new List<GameObject>();

    //I was lazy and did not feel like manually locking and dragging for every layout group so now it's just a simple button.
    [Button("Lazy Populate")]
    private void LazyPopulate()
    {
        enemyCardPositions = new List<GameObject>();

        RectTransform[] cardPositions = transform.GetComponentsInChildren<RectTransform>();

        foreach (RectTransform cardPosition in cardPositions)
            enemyCardPositions.Add(cardPosition.gameObject);

        //Remove self.
        enemyCardPositions.RemoveAt(0);
    }
}

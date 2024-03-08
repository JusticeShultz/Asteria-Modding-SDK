using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MultioptionButton : MonoBehaviour
{
    private int _currentSelection = 0;
    public int currentSelection
    {
        get { return _currentSelection; }
        set { 
            _currentSelection = value;
        }
    }

    //public TextMeshProUGUI currentSelectionText;

    public List<Image> selections = new List<Image>();
    public List<string> selectionResults = new List<string>();
    public UnityEvent<int> onValueChanged = new UnityEvent<int>();

    private void OnEnable()
    {
    }

    public void LeftSelection()
    {
    }

    public void RightSelection()
    {
    }

    public void UpdateRender()
    {
    }
}

using UnityEngine;
using System.Collections.Generic;

public class DialogueChoiceTray : MonoBehaviour
{
    public List<ButtonDetails> buttonDetailsList = new List<ButtonDetails>();
    public int currentHover = 0;

    public float movementSmoothing = 10f;
    public float scalingSmoothing = 10f;

    public GameObject topTemplate;
    public GameObject middleTemplate;
    public GameObject bottomTemplate;

    public float selectionCooldown = 0f;

    //public TMPro.TextMeshProUGUI moreTopText;
    //public TMPro.TextMeshProUGUI moreBottomText;

    [HideInInspector] public ButtonDetails selectedButtonTop;
    [HideInInspector] public ButtonDetails selectedButton;
    [HideInInspector] public ButtonDetails selectedButtonBottom;

    private void Update()
    {
    }

    public void MoveUp()
    {
    }

    public void MoveDown()
    {
    }

    public void UpdateRender()
    {
    }
}
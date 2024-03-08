using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTextHelper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static HoverTextHelper txtHovered = null;

    [TextArea]
    public string txt;
    public float smoothing = 0.25f;
    public bool lockX = false;
    public bool lockY = true;
    public DisplayableBox displayableBox;
    public DisplayableBox displayableBox_template;
    public Canvas parentCanvas;
    

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}

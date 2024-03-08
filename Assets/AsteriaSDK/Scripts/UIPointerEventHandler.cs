using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UIPointerEventHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent onEnable = new UnityEvent();
    public UnityEvent onAwake = new UnityEvent();
    public UnityEvent onPointerEnter = new UnityEvent();
    public UnityEvent onPointerExit = new UnityEvent();
    public UnityEvent onPointerClick = new UnityEvent();
    public UnityEvent onPointerDown = new UnityEvent();
    public UnityEvent onPointerUp = new UnityEvent();
    public UnityEvent whileHovered = new UnityEvent();
    public UnityEvent whileNotHovered = new UnityEvent();

    bool hovered = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        onPointerClick.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerDown.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
        onPointerEnter.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
        onPointerExit.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onPointerUp.Invoke();
    }

    void OnEnable()
    {
        onEnable.Invoke();
    }

    private void Awake()
    {
        onAwake.Invoke();
    }

    void Update()
    {
        if (hovered)
            whileHovered.Invoke();
        else
            whileNotHovered.Invoke();
    }
}

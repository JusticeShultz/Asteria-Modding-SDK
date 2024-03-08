using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSelectUIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [Header("Assigned in editor")]
    public Image spellIcon;
    public Transform boarder;
    public float normalScale = 0.93f;
    public float hoveredScale = 1f;
    public float growSpeedOnHover = 10f;
    public Skill representedSkill;
    float scalefactor = 0f;
    bool selected = true;
    bool hovered;
    public GraphicRaycaster raycaster;
    void Update()
    {
        scalefactor = Mathf.Clamp(scalefactor, 0f, 1f);
        boarder.localScale = Vector3.Lerp(new Vector3(normalScale, normalScale, normalScale), new Vector3(hoveredScale, hoveredScale, hoveredScale), scalefactor);
        if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
        }
    }
    public void SetSkill(Skill _skill)
    {
        representedSkill = _skill;
        if (representedSkill != null)
        {
            spellIcon.sprite = representedSkill.skillImage;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }

    public void OnMouseUp()
    {
        if (selected)
        {
            var e = new PointerEventData(null);
            e.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(e, results);
            if (results.Count > 0)
            {
                Debug.Log(results[0].gameObject.name + " " + representedSkill.name);
                results[0].gameObject.SendMessage("EquipSkill", representedSkill);
            }
        }
        selected = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        selected = true;
    }
}

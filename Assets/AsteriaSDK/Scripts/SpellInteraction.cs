using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;

//This systems required IPointer events, which require an event system. If IPointer will be an issue when porting, this will need to be rewritten down the line.
public class SpellInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [TabGroup("Editor Data")] public string spellSlotID;
    [TabGroup("Editor Data")] public Canvas canvas;
    [TabGroup("Editor Data")] public SpellSlot spellSlot;

    [TabGroup("Game Data")] public bool hovered = false;
    [TabGroup("Game Data")] public SerializedSkill linkedSpell;

    [TabGroup("Tools")]
    [Button]
    public void OnPointerDown(PointerEventData eventData)
    {
        if (linkedSpell == null)
            return;
        if (linkedSpell.currentCooldown > 0f)
            return;
        if (!spellSlot.canAffordHealth)
            return;
        if (!spellSlot.canAffordStamina)
            return;
        if (!spellSlot.canAffordMana)
            return;

        Vector2 canvasMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out canvasMousePosition);
        Vector2 screenPosition = canvas.transform.TransformPoint(canvasMousePosition);

        SpellManager.Instance.SetSpellPointerStatus(true, new Vector3(screenPosition.x, screenPosition.y, 0));
        Combat.currentSpellInteraction = this;
    }

    [TabGroup("Tools")]
    [Button]
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Combat.Instance.combatPaused > 0f)
            return;

        hovered = true;
        SkillManager.Instance.hoveredInteraction = this;
    }

    [TabGroup("Tools")]
    [Button]
    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;

        if (SkillManager.Instance.hoveredInteraction == this)
            SkillManager.Instance.hoveredInteraction = null;
    }

    [TabGroup("Tools")]
    [Button]
    public void OnPointerUp(PointerEventData eventData)
    {
        if (linkedSpell == null)
            return;
        if (linkedSpell.currentCooldown > 0f)
            return;
        if (!spellSlot.canAffordHealth)
            return;
        if (!spellSlot.canAffordStamina)
            return;
        if (!spellSlot.canAffordMana)
            return;

        SpellManager.Instance.SetSpellPointerStatus(false, Vector3.zero);
        Combat.Instance.LaunchSpell(spellSlotID, this);
        //Debug.Log(gameObject.name);
    }
}

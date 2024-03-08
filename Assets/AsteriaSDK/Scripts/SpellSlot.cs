using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellSlot : MonoBehaviour
{
    [Header("Assigned in editor")]
    public SmoothSlider cooldownSlider;
    public float sliderSmoothing = 4f;
    public Image spellIcon;
    public Image outerSpellBorder;
    public Color onCooldownBorder;
    public Color offCooldownBorder;
    public GameObject cannotAffordHealth;
    public GameObject cannotAffordStamina;
    public GameObject cannotAffordMana;
    public float borderSmoothing = 4f;
    public float normalScale = 0.93f;
    public float hoveredScale = 1f;
    public float growSpeedOnHover = 10f;

    public SpellInteraction interaction;

    public bool canAffordHealth = false;
    public bool canAffordStamina = false;
    public bool canAffordMana = false;

    float delay = 0f;

    void Update()
    {
        if (interaction.hovered)
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(hoveredScale, hoveredScale, hoveredScale), Time.deltaTime * growSpeedOnHover);
        else
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(normalScale, normalScale, normalScale), Time.deltaTime * growSpeedOnHover);

        if (interaction.linkedSpell != null)
            cooldownSlider.fillAmount = Mathf.Lerp(cooldownSlider.fillAmount, interaction.linkedSpell.currentCooldown / interaction.linkedSpell.maxCooldownAfterModifiers, Time.deltaTime * sliderSmoothing);
        else
            cooldownSlider.fillAmount = 1f;

        delay += Time.deltaTime;

        if (delay > 0.1f)
        {
            delay = 0f;

            if (SkillManager.Instance != null && interaction.linkedSpell != null) switch (SkillManager.Instance.CanAffordResourceCost_ReturnTypeMissing(interaction.linkedSpell.baseSkill))
                {
                    case 0:
                        canAffordHealth = true;
                        canAffordStamina = true;
                        canAffordMana = true;
                        break;
                    case 1:
                        canAffordHealth = false;
                        canAffordStamina = true;
                        canAffordMana = true;
                        break;
                    case 2:
                        canAffordHealth = true;
                        canAffordStamina = false;
                        canAffordMana = true;
                        break;
                    case 3:
                        canAffordHealth = true;
                        canAffordStamina = true;
                        canAffordMana = false;
                        break;
                }
        }

        if (interaction.linkedSpell != null)
        {
            cannotAffordHealth.SetActive(!cannotAffordHealth);
            cannotAffordStamina.SetActive(!canAffordStamina);
            cannotAffordMana.SetActive(!canAffordMana);
        }
        else
        {
            cannotAffordHealth.SetActive(false);
            cannotAffordStamina.SetActive(false);
            cannotAffordMana.SetActive(false);
        }
        
        if(interaction.linkedSpell != null)
        {
            if (interaction.linkedSpell.currentCooldown <= 0)
            {
                outerSpellBorder.color = Color.Lerp(outerSpellBorder.color, offCooldownBorder, Time.deltaTime * borderSmoothing);
            }
            else
            {
                interaction.linkedSpell.currentCooldown -= Time.deltaTime;
                //Debug.Log(interaction.linkedSpell.currentCooldown);
                outerSpellBorder.color = Color.Lerp(outerSpellBorder.color, onCooldownBorder, Time.deltaTime * borderSmoothing);
            }
        }
    }
}

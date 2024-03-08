using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelectSkilSlot : MonoBehaviour
{
    public int skillSlot;
    [SerializeField] Image image;
    public void OnEnable()
    {
        if (PlayerStats.Instance.skillSlots[skillSlot] != null)
        {
            image.sprite = PlayerStats.Instance.skillSlots[skillSlot].skillImage;
        }
    }
    public void EquipSkill(Object skill)
    {
        PlayerStats.Instance.SetSkillSlot((Skill)skill, skillSlot);
        image.sprite = ((Skill)skill).skillImage;
    }
}

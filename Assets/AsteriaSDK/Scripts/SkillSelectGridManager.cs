using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelectGridManager : MonoBehaviour
{
    public GameObject SpellUISlotPrefab;
    List<SkillSelectUIButton> skillgrid = new List<SkillSelectUIButton>();
    public GraphicRaycaster raycaster;
    void OnDisable()
    {
        Debug.Log("PrintOnDisable: script was disabled");
    }

    void OnEnable()
    {
        StartCoroutine(SlowLoadSkills());
    }
    public IEnumerator SlowLoadSkills()
    {
        int reusedCount = 0;
        for (int i = 0; i < PlayerStats.Instance.permanentlyLearnedSkills.Count; i++)
        {
            if ((PlayerStats.Instance.permanentlyLearnedSkills[i]) != null)
            {
                if (i >= skillgrid.Count)
                {
                    var go = Instantiate(SpellUISlotPrefab, transform);
                    SkillSelectUIButton btn = go.transform.GetChild(0).GetComponent<SkillSelectUIButton>();
                    btn.SetSkill(PlayerStats.Instance.permanentlyLearnedSkills[i]);
                    btn.raycaster = raycaster;
                    skillgrid.Add(btn);
                    yield return null;
                }
                else
                {
                    reusedCount++;
                    skillgrid[i].SetSkill(PlayerStats.Instance.permanentlyLearnedSkills[i]);
                    skillgrid[i].raycaster = raycaster;
                    skillgrid[i].gameObject.SetActive(true); //reactivates incase this button was deactivated
                }
            }
        }
        for (int i = 0; i < PlayerStats.Instance.equippedItems.Length; i++)
        {
            if (PlayerStats.Instance.equippedItems[i] != null && PlayerStats.Instance.equippedItems[i].itemTemplate != null && PlayerStats.Instance.equippedItems[i].itemTemplate.grantedSkills != null)
            {
                for (int j = 0; j < PlayerStats.Instance.equippedItems[i].itemTemplate.grantedSkills.Count; j++)
                {
                    if (i + reusedCount >= skillgrid.Count)
                    {
                        var go = Instantiate(SpellUISlotPrefab, transform);
                        SkillSelectUIButton btn = go.transform.GetChild(0).GetComponent<SkillSelectUIButton>();
                        btn.SetSkill(PlayerStats.Instance.equippedItems[i].itemTemplate.grantedSkills[j]);
                        btn.raycaster = raycaster;
                        skillgrid.Add(btn);
                        yield return null;
                    }
                    else
                    {
                        reusedCount++;
                        skillgrid[i].SetSkill(PlayerStats.Instance.equippedItems[i].itemTemplate.grantedSkills[j]);
                        skillgrid[i].raycaster = raycaster;
                        skillgrid[i].gameObject.SetActive(true); //reactivates incase this button was deactivated
                    }
                }
            }
        }
    }
}
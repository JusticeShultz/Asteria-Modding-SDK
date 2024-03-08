using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenuManager : MonoBehaviour
{
    public static EscapeMenuManager Instance;

    public GameObject escapeMenu;
    public GameObject mainMenu;
    public GameObject settingsMenu;

    private void Start()
    {
        Instance = this;
    }

    void Update()
    {
        if (!mainMenu.activeSelf)
        {
            if (!UniversalHelperFunctions.KeyInputConsumed)
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if(settingsMenu.activeSelf)
                    {
                        settingsMenu.SetActive(false);
                        escapeMenu.SetActive(true);
                    }
                    else
                    {
                        escapeMenu.SetActive(!escapeMenu.activeSelf);
                    }
                }
        }

        if(!ExplorationManager.Instance.explorationModule.activeSelf && !CampManager.inCamp)
            escapeMenu.SetActive(false);
    }
}

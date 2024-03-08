using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Localizer : MonoBehaviour
{
    public static List<Localizer> localizers = new List<Localizer>();

    public LocalizationTable localizationTable;
    //public TextMeshProUGUI tmpText;
    //public TextAnimator_TMP animatedText;

    public List<LocalizationFont> overrideLocalizationFonts = new List<LocalizationFont>();

    string startingText = "NULL";

    bool initialized = false;

    private void Update()
    {
    }

    public void UpdateLocalizationText()
    {
    }
}

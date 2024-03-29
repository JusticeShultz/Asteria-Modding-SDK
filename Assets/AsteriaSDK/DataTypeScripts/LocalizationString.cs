using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Sirenix.OdinInspector.HideMonoScript]
[CreateAssetMenu(fileName = "LocalizationString", menuName = "Asteria/Localization String", order = 1)]
public class LocalizationString : ScriptableObject
{
    public LocalizedString localizedString;
}

//This could probably be a dictionary, but for the sake of making working in the editor easier I am opting for this solution in order to
//take advantage of the TextArea attribute which gives space to write strings, which makes life a lot easier.
[System.Serializable] public class LocalizedString
{
    [System.Serializable]
    public class LocalizedStringObject
    {
        public string language = "English";
        public string languageInEnglish = "English";
        public string googleTranslateID = "en";
        [TextArea(10, 100)] public string text = "Hmmm...";
        
        public LocalizedStringObject()
        {
            language = "English";
            text = "Hmmm...";
        }

        public LocalizedStringObject(string _language, string _text)
        {
            language = _language;
            text = _text;
        }

        public LocalizedStringObject(string _language, string _languageInEng, string _languageGoogle, string _text)
        {
            language = _language;
            languageInEnglish = _languageInEng;
            googleTranslateID = _languageGoogle;
            text = _text;
        }
    }

    public List<LocalizedStringObject> localizedStrings = new List<LocalizedStringObject>();

    public bool translated = false;

    public string GetTextOfLanguage(string language)
    {
        foreach (LocalizedStringObject stringObj in localizedStrings)
            if (stringObj.language == language)
                return stringObj.text;

        return "No localization for this text in this language...";
    }

    public bool ContainsText(string txt)
    {
        foreach (LocalizedStringObject stringObj in localizedStrings)
            if (stringObj.text == txt)
                return true;

        return false;
    }

    public string GetTextOfLanguage_FromEnglishSpelledLanguage(string engLanguage)
    {
        foreach (LocalizedStringObject stringObj in localizedStrings)
            if (stringObj.languageInEnglish == engLanguage)
                return stringObj.text;

        return "No localization for this text in this language...";
    }

    public LocalizedString()
    {

    }

    public LocalizedString(LocalizedString toCopy)
    {
        localizedStrings = new List<LocalizedStringObject>();

        foreach (LocalizedStringObject sObj in toCopy.localizedStrings)
        {
            localizedStrings.Add(new LocalizedStringObject(sObj.language, sObj.languageInEnglish, sObj.googleTranslateID, sObj.text));
        }
    }

    public LocalizedString(LocalizedString toCopy, string engOverride)
    {
        localizedStrings = new List<LocalizedStringObject>();

        foreach (LocalizedStringObject sObj in toCopy.localizedStrings)
        {
            if(sObj.languageInEnglish == "English")
                localizedStrings.Add(new LocalizedStringObject(sObj.language, sObj.languageInEnglish, sObj.googleTranslateID, engOverride));
            else
                localizedStrings.Add(new LocalizedStringObject(sObj.language, sObj.languageInEnglish, sObj.googleTranslateID, sObj.text));
        }
    }
}
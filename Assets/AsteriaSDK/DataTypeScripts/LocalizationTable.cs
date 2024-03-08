using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Net.Http;
using System.Threading.Tasks;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "LocalizationTable", menuName = "Asteria/Localization Table", order = 1)]
public class LocalizationTable : ScriptableObject
{
    public List<LocalizedString> localizedStrings = new List<LocalizedString>();

    public string GetLocalizedStringFromText(string language, string toTranslate, bool fromEnglishSpelling = true)
    {
        return "";
    }

    [Button("Translate All For Me...")]
    public void AutoTranslate()
    {
        foreach(LocalizedString localizedString in localizedStrings)
        {
            if (!localizedString.translated)
            {
                foreach (LocalizedString.LocalizedStringObject localizedStringObject in localizedString.localizedStrings)
                {
                    if (localizedStringObject.googleTranslateID != "eng")
                    {
                        Translate("eng", localizedStringObject.googleTranslateID, localizedString.localizedStrings[0].text, localizedStringObject);
                    }
                }

                localizedString.translated = true;
            }
        }

#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }

    public string Translate(string sourceLanguage, string targetLanguage, string toTranslate, LocalizedString.LocalizedStringObject modifiedOb)
    {
        string result = "NULL";

        TranslateText(sourceLanguage, targetLanguage, toTranslate, modifiedOb, (success, translatedText) =>
        {
            if (success)
                result = translatedText;
        });

        return result;
    }

    public async void TranslateText(string sourceLanguage, string targetLanguage, string sourceText, LocalizedString.LocalizedStringObject modifiedObj, Action<bool, string> callback)
    {
        string translatedText = await TranslateTextRoutine(sourceLanguage, targetLanguage, sourceText, modifiedObj);
        callback.Invoke(!string.IsNullOrEmpty(translatedText), translatedText);
    }

    private async Task<string> TranslateTextRoutine(string sourceLanguage, string targetLanguage, string sourceText, LocalizedString.LocalizedStringObject modifiedObj)
    {
        int tries = 0;

        //Try 100 times before failing.
        while(tries < 100)
        {
            tries += 1;
            Debug.Log("Translating: " + sourceLanguage + " to " + targetLanguage);

            //Using this method bypasses the need for an API key and credit costs.
            string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={sourceLanguage}&tl={targetLanguage}&dt=t&q={UnityWebRequest.EscapeURL(sourceText)}";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string jsonResult = await response.Content.ReadAsStringAsync();
                    //var parsedTexts = jsonResult; //JSONNode.Parse(jsonResult); - NEED TO FIND A WAY TO DISTRIBUTE JSON, maybe add to modding install reqs later??
                    string translatedText = jsonResult; //parsedTexts[0][0][0];
                    Debug.Log("Translated " + sourceText + " to " + translatedText);

                    if (translatedText == "" || translatedText == string.Empty)
                        continue;

                    modifiedObj.text = translatedText;
                    
                    return translatedText;
                }
                catch (HttpRequestException e)
                {
                    Debug.LogError($"Translation Error: {e.Message}");
                }
            }
        }

        return string.Empty;
    }
}

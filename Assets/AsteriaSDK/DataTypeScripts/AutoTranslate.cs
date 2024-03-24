using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using SimpleJSON;

public class AutoTranslate
{
    //REMOVE ON EXPORT
    private const string APIKey = "AIzaSyDTDlIDZ1zlUBcKbgosAM1liZw829goU-Q";

    public static string Translate(string sourceLanguage, string targetLanguage, string toTranslate)
    {
        string result = "NULL";

        TranslateText(sourceLanguage, targetLanguage, toTranslate, (success, translatedText) =>
        {
            if (success)
                result = translatedText;
        });

        if (result == "NULL")
            return "Error auto translating";
        else
            return result;
    }

    public static void TranslateText(string sourceLanguage, string targetLanguage, string sourceText, Action<bool, string> callback)
    {
        TranslateTextRoutine(sourceLanguage, targetLanguage, sourceText, callback);
    }

    private static void TranslateTextRoutine(string sourceLanguage, string targetLanguage, string sourceText, Action<bool, string> callback)
    {
        var formData = new List<IMultipartFormSection>
        {
            new MultipartFormDataSection("Content-Type", "application/json; charset=utf-8"),
            new MultipartFormDataSection("source", sourceLanguage),
            new MultipartFormDataSection("target", targetLanguage),
            new MultipartFormDataSection("format", "text"),
            new MultipartFormDataSection("q", sourceText)
        };

        var uri = $"https://translation.googleapis.com/language/translate/v2?key={APIKey}";

        var webRequest = UnityWebRequest.Post(uri, formData);

        webRequest.SendWebRequest();

        if (webRequest.isHttpError || webRequest.isNetworkError)
        {
            Debug.LogError(webRequest.error);
            callback.Invoke(false, string.Empty);

            //yield break;
        }

        var parsedTexts = JSONNode.Parse(webRequest.downloadHandler.text);
        var translatedText = parsedTexts["data"]["translations"][0]["translatedText"];

        callback.Invoke(true, translatedText);
    }
}
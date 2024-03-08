using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class SaveFileInfo
{
    public string saveName;
    public string saveDate;
    public string locationName;

    public void SetSaveDate()
    {
        DateTime currentDateTime = DateTime.Now;
        saveDate = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public SaveFileInfo(string name)
    {
        saveName = name;
        SetSaveDate();
        locationName = Locale.Instance.currentLocation.locationName;
    }
}

public class SaveList : MonoBehaviour
{
    public static SaveList Instance;
    public List<SaveFileInfo> savedGames = new List<SaveFileInfo>();

    private void Start()
    {
        Instance = this;
        StartCoroutine(FetchSaveList());
    }

    private IEnumerator FetchSaveList()
    {
        yield return new WaitForSeconds(2);
        SaveAndLoadManager.Instance.GetSaveList();
    }

    public List<SaveFileInfo> SortListByDateTime(List<SaveFileInfo> yourList)
    {
        return savedGames.OrderBy(item => DateTime.ParseExact(item.saveDate, "yyyy-MM-dd HH:mm:ss", null)).ToList();
    }
}

using System.Collections.Generic;
using UnityEngine;

public static class DataPlayer
{
    private const string All_Data = "all_data";
    private static AllData allData;
    static DataPlayer()
    {
        // Chuyen doi du lieu tu json sang alldata
        allData = JsonUtility.FromJson<AllData>(PlayerPrefs.GetString(All_Data));
        // neu du lieu dau vao la null, tuc la user vao lan dau
        // chung ta can khoi tao du lieu mac dinh cho user
        if (allData == null)
        {
            var skinDefaultId = 1;
            allData = new AllData
            {
                skinList = new List<int> { skinDefaultId }
            };
            SaveData();
        }
    }
    private static void SaveData()
    {
        var data = JsonUtility.ToJson(allData);
        PlayerPrefs.SetString(All_Data, data);
    }
    public static bool IsOwnerSkinList(int id)
    {
        return allData.IsOwnerSkinList(id);
    }
    public static void AddSkin(int id) {
        allData.AddSkin(id);
        SaveData();
    }
}
public class AllData {
    public List<int> skinList;
    public bool IsOwnerSkinList(int id)
    {
        return skinList.Contains(id);
    }

    public void AddSkin(int id)
    {
        if (IsOwnerSkinList(id))
        {
            return;
        }
        skinList.Add(id);
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class DataPlayer
{
    private const string All_Data = "all_data";
    private static AllData allData;

    private static UnityEvent updateCoinEvent = new UnityEvent();

    static DataPlayer()
    {
        // Chuyen doi du lieu tu json sang alldata
        allData = JsonUtility.FromJson<AllData>(PlayerPrefs.GetString(All_Data));
        // neu du lieu dau vao la null, tuc la user vao lan dau
        // chung ta can khoi tao du lieu mac dinh cho user
        if (allData == null)
        {
            //var skinDefaultId = 1;
            allData = new AllData();
            /*{
                skinList = new List<int> { skinDefaultId },
                currentSkin = skinDefaultId,
                coin = 1000,
                idRoom = 1,
            };*/
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

    public static int GetCurrentSkin()
    {
        return allData.GetCurrentSkin();
    }
    public static void SetCurrentSkin(int currentSkin)
    {
        allData.SetCurrentSkin(currentSkin);
    }

    public static int GetCoin()
    {
        return allData.GetCoin();
    }

    public static int GetHeart()
    {
        return allData.GetHeart();
    }

    public static void UpdateHeart(int value)
    {
        allData.UpdateHeart(value);
        SaveData();
    }

    public static void AddCoin(int value)
    {
        allData.AddCoin(value);
        SaveData();
    }

    public static void SubCoin(int value)
    {
        allData.SubCoin(value);
        SaveData();
    }

    public static int GetIdRoom()
    {
        return allData.GetIdRoom();
    }

    public static void SetIdRoom(int value) {
        allData.SetIdRoom(value);
        SaveData();
    }

    public static void AddListener(UnityAction updateCoin)
    {
        updateCoinEvent.AddListener(updateCoin);
        updateCoinEvent?.Invoke();
    }
    public static void RemoveListener(UnityAction updateCoin)
    {
        updateCoinEvent.RemoveListener(updateCoin);
    }
}
public class AllData {

    #region Variables
    public List<int> skinList;
    public int currentSkin;
    public int coin;
    public int heart;
    public int idRoom;

    public AllData()
    {
        skinList = new List<int> { 1 };
        currentSkin = 1;
        coin = 1000;
        heart = 3;
        idRoom = 1;
    }
    #endregion

    #region Functions
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
    public int GetCurrentSkin()
    {
        return currentSkin;
    }
    public void SetCurrentSkin(int currentSkin)
    {
        this.currentSkin = currentSkin;
    }

    public int GetHeart()
    {
        return heart;
    }

    public void UpdateHeart(int value)
    {
        heart += value;
    }

    public int GetCoin()
    {
        return coin;
    }
    public void AddCoin(int value)
    {
        coin += value;
    }
    public void SubCoin(int value)
    {
        coin -= value;
    }
    public int GetIdRoom()
    {
        return idRoom;
    }
    public void SetIdRoom(int value)
    {
        idRoom += value;
    }
    #endregion
}

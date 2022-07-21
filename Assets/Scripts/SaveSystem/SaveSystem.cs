using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class SaveSystem
{
    private static string pointsKey = "Points";
    private static string playerWeaponKeys = "PlayerWeapons";
    private static string levelKey = "LevelKey";
    private static string saveDataKey = "saveDataKey";

    public static void SaveGameData(int levelIndexToSave)
    {
        SaveLevel(levelIndexToSave);
        PlayerPrefs.SetInt(saveDataKey, 1);
    }

    private static void SaveLevel(int levelIndex)
    {
        PlayerPrefs.SetInt(levelKey, levelIndex);
    }

    public static int LoadLevelIndex()
    {
        if (IsSaveDataPresent())
            return PlayerPrefs.GetInt(levelKey);
        return -1;
    }

    private static bool IsSaveDataPresent()
    {
        return PlayerPrefs.GetInt(saveDataKey) == 1;
    }

    public static void SaveWeapons(List<string> weaponNames)
    {
        string data = JsonConvert.SerializeObject(new PlayerWeapons { playerWeapons = weaponNames });
        PlayerPrefs.SetString(playerWeaponKeys, data);
    }

    public static List<string> LoadWeapons()
    {
        if (IsSaveDataPresent())
        {
            string data = PlayerPrefs.GetString(playerWeaponKeys);
            if(data.Length > 0)
            {
                return JsonConvert.DeserializeObject<PlayerWeapons>(data).playerWeapons;
            } 
        }

        return null;
    }

    public static void SavePoints(int amount)
    {
        PlayerPrefs.SetInt(pointsKey, amount);
    }

    public static int GetPoints()
    {
        return PlayerPrefs.GetInt(pointsKey);
    }

    public static void ResetSaveData()
    {
        PlayerPrefs.DeleteKey(pointsKey);
        PlayerPrefs.DeleteKey(playerWeaponKeys);
        PlayerPrefs.DeleteKey(levelKey);
        PlayerPrefs.DeleteKey(saveDataKey);
    }

    private struct PlayerWeapons
    {
        public List<string> playerWeapons;
    }
}

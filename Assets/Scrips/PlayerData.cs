using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public WorldDataHolder.RegionList worldData;
    public TownDataHolder.Town townData;
    public ResourseHolder.Resourses resourseData;
    public int playerArmyLimit;
    //public WorldDataHolder worldDataHolder;
    //public TownDataHolder townDataHolder;

    [Serializable]
    class SaveData
    {
        public WorldDataHolder.RegionList savedWorldData;
        public TownDataHolder.Town savedTownData;
        public ResourseHolder.Resourses savedResourseData;
        public int savedPlayerArmyLimit;
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.savedWorldData = worldData;
        data.savedTownData = townData;
        data.savedResourseData = resourseData;
        data.savedPlayerArmyLimit = playerArmyLimit;
        bf.Serialize(file, data);
        file.Close();
    }
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            worldData = data.savedWorldData;
            townData = data.savedTownData;
            resourseData = data.savedResourseData;
            playerArmyLimit = data.savedPlayerArmyLimit;
        }
        else
            Debug.Log("There is no save data!");
    }
    [ContextMenu("ResetData")]
    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath + "/MySaveData.dat");
            worldData = null;
            townData = null;
            resourseData = null;
            playerArmyLimit = 0;
        }
        else
            Debug.Log("No save data to delete.");
    }
    
}

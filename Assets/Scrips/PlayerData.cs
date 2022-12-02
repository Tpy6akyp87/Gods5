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
    public WorldDataHolder worldDataHolder;
    public TownDataHolder townDataHolder;

    [Serializable]
    class SaveData
    {
        public WorldDataHolder.RegionList savedWorldData;
        public TownDataHolder.Town savedTownData;
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.savedWorldData = worldData;
        data.savedTownData = townData;
        bf.Serialize(file, data);
        file.Close();
        //Debug.Log("Game data saved!");
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
            //Debug.Log("Game data loaded!");
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
           // Debug.Log("Data reset complete!");
        }
        else
            Debug.Log("No save data to delete.");
    }
    void Awake()
    {
    }

    void Update()
    {
        
    }
}

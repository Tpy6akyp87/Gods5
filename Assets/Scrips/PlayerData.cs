using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public WorldDataHolder.RegionList worldData;
    public TownDataHolder townData;

    [Serializable]
    class SaveData
    {
        public WorldDataHolder.RegionList savedWorldData;
        //public TownDataHolder savedTownData;
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.savedWorldData = worldData;
        //data.savedTownData = townData;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
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
            //townData = data.savedTownData;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

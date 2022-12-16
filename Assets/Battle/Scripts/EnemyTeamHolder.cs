using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

public class EnemyTeamHolder : MonoBehaviour
{
    public int[,] weight = new int[10, 3] { { 100, 110, 121 },{ 110, 121, 133 }, { 121, 133, 146 }, { 133, 146, 161 }, { 146, 161, 177 }, { 161, 177, 195 }, { 177, 195, 214 }, { 195, 214, 236 }, { 214, 236, 259 }, { 236, 259, 285 } };
    //public StartEnemyTeam enemyTeam;

    public int enemyArmyWeight;
    public int healers;
    public int damagers;
    public int defenders;
    [System.Serializable]
    class SaveData
    {
        public int Saved_enemyArmyWeight;
        public int Saved_healers;
        public int Saved_damagers;
        public int Saved_defenders;
    }

    public void Save_EnemyTeam()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/enemyteam.dat");
        SaveData data = new SaveData();
        data.Saved_enemyArmyWeight = enemyArmyWeight;
        data.Saved_healers = healers;
        data.Saved_damagers = damagers;
        data.Saved_defenders = defenders;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("enemyteam saved!");
    }
    public void Load_EnemyTeam()
    {
        if (File.Exists(Application.persistentDataPath + "/enemyteam.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/enemyteam.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            enemyArmyWeight = data.Saved_enemyArmyWeight;
            healers = data.Saved_healers;
            damagers = data.Saved_damagers;
            defenders = data.Saved_defenders;

            Debug.Log("enemyteam loaded!");
        }
        else
            Debug.Log("There is no enemyteam!");
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

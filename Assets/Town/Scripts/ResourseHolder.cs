using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ResourseHolder : MonoBehaviour
{
    public Resourses resources;
    public PlayerData playerData;
    public ResouceInfo resouceInfo;
    void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        resouceInfo = FindObjectOfType<ResouceInfo>();
        Load_Resourses();
        resouceInfo.GetResouces_Info(resources.stone, resources.wood, resources.clay, resources.fiber, resources.iron, resources.charcoal, resources.cloth, resources.skyStone, resources.fireStone);
       // Get_Resourses();

    }

    [System.Serializable]
    public class Resourses
    {
        public int stone;
        public int wood;
        public int clay;
        public int fiber;
        public int iron;
        public int charcoal;
        public int cloth;
        public int skyStone;
        public int fireStone;
        public int exp;
    }
    public void Get_Resourses(int enemyArmyWeight)// для получения лута нужно сделать метод для вызова из эндофбатл, со случайно генерацией кол-ва ресурсов. + ввести ресурс опыта.
    {
        Load_Resourses();
        int stone = 0;
        int wood = 0;
        int clay = 0;
        int fiber = 0;
        int iron = 0;
        int charcoal = 0;
        int cloth = 0;
        int skyStone = 0;
        int fireStone = 0;
        int rnd = Random.Range(0, 100);
        if (rnd < 16)
        {
            Debug.Log("rnd < 16");
            stone = Random.Range(10, 15); 
            wood = Random.Range(10, 15); 
            clay = Random.Range(10, 15); 
            fiber = Random.Range(10, 15); 
            iron = Random.Range(5, 8); 
            charcoal = Random.Range(5, 8); 
            cloth = Random.Range(5, 8); 
            skyStone = Random.Range(1, 4); 
            fireStone = Random.Range(1, 4); 
        }
        if (rnd < 41 && rnd > 15)
        {
            Debug.Log("rnd < 41 && rnd > 15");
            stone = Random.Range(5, 13);
            wood = Random.Range(5, 13);
            clay = Random.Range(5, 13);
            fiber = Random.Range(5, 13);
            iron = Random.Range(1, 4);
            charcoal = Random.Range(1, 4);
            cloth = Random.Range(1, 4);
            skyStone = 0;
            fireStone = 0;
        }
        if (rnd > 40)
        {
            Debug.Log("rnd > 40");
            stone = Random.Range(3, 10);
            wood = Random.Range(3, 10);
            clay = Random.Range(3, 10);
            fiber = Random.Range(3, 10);
            iron = Random.Range(0, 3);
            charcoal = Random.Range(0, 3);
            cloth = Random.Range(0, 3);
            skyStone = 0;
            fireStone = 0;
        }
        resources.stone += stone * Mathf.RoundToInt(enemyArmyWeight / 100);
        resources.wood += wood * Mathf.RoundToInt(enemyArmyWeight / 100);
        resources.clay += clay * Mathf.RoundToInt(enemyArmyWeight / 100);
        resources.fiber += fiber * Mathf.RoundToInt(enemyArmyWeight / 100);
        resources.iron += iron * Mathf.RoundToInt(enemyArmyWeight / 100);   
        resources.charcoal += charcoal * Mathf.RoundToInt(enemyArmyWeight / 100);
        resources.cloth += cloth * Mathf.RoundToInt(enemyArmyWeight / 100);
        resources.skyStone += skyStone * Mathf.RoundToInt(enemyArmyWeight / 100);
        resources.fireStone += fireStone * Mathf.RoundToInt(enemyArmyWeight / 100);
        resources.exp += enemyArmyWeight;

        Save_Resourses();
    }
    public void Load_Resourses()
    {
        playerData.LoadGame();
        resources = playerData.resourseData;
        resouceInfo.GetResouces_Info(resources.stone, resources.wood, resources.clay, resources.fiber, resources.iron, resources.charcoal, resources.cloth, resources.skyStone, resources.fireStone);
    }
    public void Save_Resourses()
    {
        playerData.resourseData = resources;
        playerData.SaveGame();
        resouceInfo.GetResouces_Info(resources.stone, resources.wood, resources.clay, resources.fiber, resources.iron, resources.charcoal, resources.cloth, resources.skyStone, resources.fireStone);
    }
}

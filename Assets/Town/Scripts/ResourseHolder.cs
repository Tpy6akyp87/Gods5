using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ResourseHolder : MonoBehaviour
{
    public Resourses resources;
    public PlayerData playerData;
    void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        Get_Resourses();
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
    }
    public void Get_Resourses()
    {
        playerData.LoadGame();
        Load_Resourses();
        if ((resources.charcoal+resources.clay+resources.cloth+resources.fiber+resources.fireStone+resources.iron+resources.skyStone+resources.stone+resources.wood) == 0)
        {
            resources.charcoal = 20;
            resources.clay = 20;
            resources.cloth = 20;
            resources.fiber = 20;
            resources.fireStone = 20;
            resources.iron = 20;
            resources.skyStone = 20;
            resources.stone = 20;
            resources.wood = 20;
            Save_Resourses();
        }
    }
    public void Load_Resourses()
    {
        playerData.LoadGame();
        resources = playerData.resourseData;
    }
    public void Save_Resourses()
    {
        playerData.resourseData = resources;
        playerData.SaveGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TownDataHolder : MonoBehaviour
{
    public Town town;
    public PlayerData playerData;
    void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
    }
    public void MyOwnAwake()
    {
        playerData = FindObjectOfType<PlayerData>();
        Get_Buildings();
        for (int i = 0; i < town.buildings.Count; i++)
        {
            if (town.buildings[i].isBuilded)
            {
                town.townLevel += town.buildings[i].weightBuild;
            }
        }
    }
    [System.Serializable]
    public class Town
    {
        public int townLevel;

        public List<Buildings> buildings;
    }
    [System.Serializable]
    public class Buildings
    {
        public int weightBuild;
        public int idBuild;
        public bool isBuilded;
        public int buildType;
        public int level;
        public PlayerEffects playerEffects = new PlayerEffects();
    }
    [System.Serializable]
    public class PlayerEffects
    {
        public float maxHPEffect;
        public float startTimeToActionEffect;
        public int phisicalDamageEffect;
        public bool inRageEffect;
        public int magicDamageEffect;
        public int magicArmorEffect;
        public int healPowerEffect;
        public int lifeStealEffect;
        public int critChanceEffect;
        public int dodgeChanceEffect;
        public int phisicalArmorEffect;
    }

    public void Add_NewBuilding(
        int weightBuild,
        int idBuild,
        bool isBuilded,
        int buildType,
        int level,
        float maxHPEffect,
        float startTimeToActionEffect,
        int phisicalDamageEffect,
        int magicDamageEffect,
        int magicArmorEffect,
        int healPowerEffect,
        int lifeStealEffect,
        int critChanceEffect,
        int dodgeChanceEffect,
        int phisicalArmorEffect)
    {
        Buildings building = new Buildings();
        building.weightBuild = weightBuild;
        building.idBuild = idBuild;
        building.isBuilded = isBuilded;
        building.buildType = buildType;
        building.level = level;
        //PlayerEffects building.playerEffects = new PlayerEffects();
        building.playerEffects.maxHPEffect = maxHPEffect;
        building.playerEffects.startTimeToActionEffect = startTimeToActionEffect;
        building.playerEffects.phisicalDamageEffect = phisicalDamageEffect;
        building.playerEffects.magicDamageEffect = magicDamageEffect;
        building.playerEffects.magicArmorEffect = magicArmorEffect;
        building.playerEffects.healPowerEffect = healPowerEffect;
        building.playerEffects.lifeStealEffect = lifeStealEffect;
        building.playerEffects.critChanceEffect = critChanceEffect;
        building.playerEffects.dodgeChanceEffect = dodgeChanceEffect;
        building.playerEffects.phisicalArmorEffect = phisicalArmorEffect;
        town.buildings.Add(building);
    }

    public void Save_Town()
    {
        Building[] buildings = FindObjectsOfType<Building>();
        for (int i = 0; i < buildings.Length; i++)
        {
            for (int j = 0; j < town.buildings.Count; j++)
            {
                if (buildings[i].idBuild == town.buildings[j].idBuild)
                {
                    town.buildings[j].level = buildings[i].level;
                    town.buildings[j].isBuilded = buildings[i].isBuilded;
                }
            }
        }
        playerData.townData = town;
        playerData.SaveGame();
    }

    public void Load_Town()
    {
        playerData.LoadGame();
        town = playerData.townData;
    }

    [ContextMenu("Clear")]
    public void Reset_Town()
    {
        town.buildings.Clear();
        Save_Town();
    }

    public void Get_Buildings()
    {
        Load_Town();
        Building[] buildings = FindObjectsOfType<Building>();
        if (town.buildings.Count == 0)
        {
            for (int i = 0; i < buildings.Length; i++)
            {
               Add_NewBuilding(
               buildings[i].weightBuild,
               buildings[i].idBuild,
               buildings[i].isBuilded,
               buildings[i].buildType,
               buildings[i].level,
               buildings[i].maxHPEffect,
               buildings[i].startTimeToActionEffect,
               buildings[i].phisicalDamageEffect,
               buildings[i].magicDamageEffect,
               buildings[i].magicArmorEffect,
               buildings[i].healPowerEffect,
               buildings[i].lifeStealEffect,
               buildings[i].critChanceEffect,
               buildings[i].dodgeChanceEffect,
               buildings[i].phisicalArmorEffec);
            }
        }
        for (int i = 0; i < buildings.Length; i++)
        {
            for (int j = 0; j < town.buildings.Count; j++)
            {
                if (buildings[i].idBuild == town.buildings[j].idBuild)
                {
                    buildings[i].Take_Data(town.buildings[j]);
                }
            }
        }
        Save_Town();
    }




    public enum BuildType
    {
        WindMill,
        Forge,
        TempleOfMagnus,
        Armory,
        WizardTower
    }

}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TownDataHolder : MonoBehaviour
{
    public Town town;
    [System.Serializable]
    public class Town
    {
        public List<Buildings> buildings;
    }
    [System.Serializable]
    public class Buildings
    {
        public bool isBuilded;
        public int buildType;
        public int level;
        public Vector3 position;
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
        bool isBuilded,
        int buildType,
        int level,
        Vector3 position,
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
        building.isBuilded = isBuilded;
        building.buildType = buildType;
        building.level = level;
        building.position = position;
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
        File.WriteAllText(Application.dataPath + "/Town/townData.json", JsonUtility.ToJson(town));
    }
    public void Load_Town()
    {
        town = JsonUtility.FromJson<Town>(File.ReadAllText(Application.dataPath + "/Town/townData.json"));
    }
    [ContextMenu("Clear")]
    public void Reset_Town()
    {
        town.buildings.Clear();
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

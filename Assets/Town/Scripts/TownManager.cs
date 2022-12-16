using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    public TownDataHolder townData;
    public Building[] buildings; 
    void Nenenene()
    {
        townData = FindObjectOfType<TownDataHolder>();
        buildings = FindObjectsOfType<Building>();
        townData.Load_Town();
        for (int i = 0; i < buildings.Length; i++)
        {
            townData.Add_NewBuilding(
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
    private void Awake()
    {
        townData = FindObjectOfType<TownDataHolder>();
        townData.MyOwnAwake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

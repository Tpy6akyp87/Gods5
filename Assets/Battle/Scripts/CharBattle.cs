using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharBattle : UnitBattle
{
    public int minWeight;
    public TownDataHolder townData;
    void Awake()
    {
        townData = FindObjectOfType<TownDataHolder>();
        townData.Load_Town();
        for (int i = 0; i < townData.town.buildings.Count; i++)
        {
            maxHP += townData.town.buildings[i].playerEffects.maxHPEffect;
            startTimeToAction += townData.town.buildings[i].playerEffects.maxHPEffect;
            phisicalDamage += townData.town.buildings[i].playerEffects.phisicalDamageEffect;
            magicDamage += townData.town.buildings[i].playerEffects.magicDamageEffect;
            magicArmor += townData.town.buildings[i].playerEffects.magicArmorEffect;
            healPower += townData.town.buildings[i].playerEffects.healPowerEffect;
            lifeSteal += townData.town.buildings[i].playerEffects.lifeStealEffect;
            critChance += townData.town.buildings[i].playerEffects.critChanceEffect;
            dodgeChance += townData.town.buildings[i].playerEffects.dodgeChanceEffect;
            phisicalArmor += townData.town.buildings[i].playerEffects.phisicalArmorEffect;
        }
       
   
}

    void Update()
    {
    
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildType buildType;
    public int level;
    public Vector3 position;
    public float maxHPEffect;
    public float startTimeToActionEffect;
    public int phisicalDamageEffect;
    public int magicDamageEffect;
    public int magicArmorEffect;
    public int healPowerEffect;
    public int lifeStealEffect;
    public int critChanceEffect;
    public int dodgeChanceEffect;
    public int phisicalArmorEffec;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

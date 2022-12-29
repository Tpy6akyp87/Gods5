using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public TownDataHolder townData;
    public int weightBuild;
    public int idBuild;
    public bool isBuilded;
    public int buildType;
    public int level;
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

    public SpriteRenderer image;
    public Sprite sprite0;
    public Sprite sprite1;
    public Sprite sprite2;


    // Start is called before the first frame update
    void Start()
    {
        townData = FindObjectOfType<TownDataHolder>();
      //  townData.Add_NewBuilding(idBuild, isBuilded, buildType,level,maxHPEffect,startTimeToActionEffect,phisicalDamageEffect,magicDamageEffect,magicArmorEffect,healPowerEffect,lifeStealEffect,critChanceEffect,dodgeChanceEffect,phisicalArmorEffec);
        //townData.Save_Town();
    }
    void Awake()
    {
        image = GetComponentInChildren<SpriteRenderer>();
        image.sprite = sprite1;
        //sprite = Resources.Load<Sprite>("Assets/Resources/22.png");
    }

    // Update is called once per frame
    void Update()
    {
        if (level == 0)
        {
            image.sprite = sprite0;
        }
        if (level == 1)
        {
            image.sprite = sprite1;
        }
        if (level == 2)
        {
            image.sprite = sprite2;
        }
    }
    void OnMouseDown()
    {
        image.sprite = sprite2;
        //image.sprite = Resources.Load("Assets/Resources/22.png") as Sprite;
    }
    public void UpgradeBuilding()
    {
        level++;
    }
    public void Take_Data(TownDataHolder.Buildings buildings)
    {
        isBuilded = buildings.isBuilded;
        level = buildings.level;
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

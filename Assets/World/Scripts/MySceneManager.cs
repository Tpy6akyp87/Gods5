using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : MonoBehaviour
{
    public WorldDataHolder dataHolder;
    public TownDataHolder townData;
    void Start()
    {
        dataHolder = FindObjectOfType<WorldDataHolder>();
        dataHolder.MyOwnAwake();
        townData = FindObjectOfType<TownDataHolder>();
        townData.MyOwnAwake();
        dataHolder.GetPlArmLvl();
    }

}

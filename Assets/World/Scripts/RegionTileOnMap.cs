using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class RegionTileOnMap : MonoBehaviour
{
    public int idRegion;
    public bool visitedRegion = false;
    public int visitedPoints = 5;
    public int numberOfPoints = 10;
    public int levelOfRegion = 3;
    public string typeOfRegion = "Wild";

    public WorldDataHolder dataHolder;
    //public RegionList regionList;
    void Start()
    {
        dataHolder = FindObjectOfType<WorldDataHolder>();
        SaveField();
    }
    void Update()
    {
        
    }
    
    public void SaveField()
    {
        dataHolder.SaveField(idRegion, visitedRegion = false, visitedPoints = 5, numberOfPoints = 10, levelOfRegion = 3, typeOfRegion = "Wild");
    }
}

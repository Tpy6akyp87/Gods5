using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegionTileOnMap : MonoBehaviour
{
    public bool loaded = false;
    public int idRegion;
    public bool isVisitedRegion;
    public int visitedPoints;
    public int numberOfPoints;
    public int levelOfRegion;
    public string typeOfRegion;
    public int structType = 0;
    public int[] structVariant = {0,0,0,0,0,0};
    public bool mouseOnTile;
    public WorldDataHolder dataHolder;
    public RegionTileInfo tileInfo;
      
    
    void Start()
    {
        dataHolder = FindObjectOfType<WorldDataHolder>();
        tileInfo = FindObjectOfType<RegionTileInfo>();
    }

    public void Take_Data(WorldDataHolder.Region savedRegion)
    {
        isVisitedRegion = savedRegion.isVisitedRegion;
        visitedPoints = savedRegion.visitedPoints;
        numberOfPoints = savedRegion.numberOfPoints;
        levelOfRegion = savedRegion.levelOfRegion;
        typeOfRegion = savedRegion.typeOfRegion;
        structType = savedRegion.structType;
        structVariant = savedRegion.structVariant;
}

    public void Send_Data(WorldDataHolder.Region savedRegion)
    {
        savedRegion.isVisitedRegion = isVisitedRegion;
        savedRegion.visitedPoints = visitedPoints;
        savedRegion.numberOfPoints = numberOfPoints;
        savedRegion.levelOfRegion = levelOfRegion;
        savedRegion.typeOfRegion = typeOfRegion;
        savedRegion.structType = structType;
        savedRegion.structVariant = structVariant;
    }
    void Update()
    {
        if (mouseOnTile)
        {
            tileInfo.GetRegionData(idRegion, isVisitedRegion, visitedPoints, numberOfPoints, levelOfRegion, typeOfRegion);
        }
    }
  

    void OnMouseOver()
    {
        mouseOnTile = true;
    }

    void OnMouseExit()
    {
        mouseOnTile = false;
    }

    void OnMouseDown()
    {
        //dataHolder.Load_RegionList();
        for (int i = 0; i < dataHolder.regionList.regionS.Count; i++)
        {
            if (dataHolder.regionList.regionS[i].idRegion == idRegion)
            {
                dataHolder.regionList.regionS[i].loaded = true;
            }
        }
        dataHolder.Save_RegionList();
        if (typeOfRegion == "Wild")
        {
            SwitchScene("ExploreScene");
        }
        if (typeOfRegion == "Town")
        {
            SwitchScene("Town");
        }
        //SwitchScene("ExploreScene");
    }
    public void SwitchScene(string nextscene)
    {
        SceneManager.LoadScene(nextscene);
    }
}

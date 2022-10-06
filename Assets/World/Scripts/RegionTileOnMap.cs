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
    public bool visitedRegion;
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
        dataHolder.Load_RegionList();
        bool regionSaved = false;

        if (dataHolder.regionList != null)
        {
            for (int i = 0; i < dataHolder.regionList.regionS.Count; i++)
            {
                if (dataHolder.regionList.regionS[i].idRegion == idRegion)
                {
                    regionSaved = true;
                }
            }
            
        }
        if (!regionSaved)
        {
            dataHolder.Add_NewRegionToList(loaded, idRegion, visitedRegion = false, visitedPoints = 99, numberOfPoints = 99, levelOfRegion = 99, typeOfRegion = "Wild", structType, structVariant);
            dataHolder.Save_RegionList();
        }
        else LoadRegionData();

    }
    void Update()
    {
        if (mouseOnTile)
        {
            tileInfo.GetRegionData(idRegion, visitedRegion, visitedPoints, numberOfPoints, levelOfRegion, typeOfRegion);
        }
    }
    public void LoadRegionData()
    {
        for (int i = 0; i < dataHolder.regionList.regionS.Count; i++)
        {
            if (dataHolder.regionList.regionS[i].idRegion == idRegion)
            {
                visitedRegion = dataHolder.regionList.regionS[i].isVisitedRegion;
                visitedPoints = dataHolder.regionList.regionS[i].visitedPoints;
                numberOfPoints = dataHolder.regionList.regionS[i].numberOfPoints;
                levelOfRegion = dataHolder.regionList.regionS[i].levelOfRegion;
                typeOfRegion = dataHolder.regionList.regionS[i].typeOfRegion;
            }
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
        dataHolder.Load_RegionList();
        for (int i = 0; i < dataHolder.regionList.regionS.Count; i++)
        {
            if (dataHolder.regionList.regionS[i].idRegion == idRegion)
            {
                Debug.Log(idRegion);
                Debug.Log(dataHolder.regionList.regionS[i].idRegion);
                dataHolder.regionList.regionS[i].loaded = true;
            }
        }
        dataHolder.Save_RegionList();
        SwitchScene("ExploreScene");
    }
    public void SwitchScene(string nextscene)
    {
        SceneManager.LoadScene(nextscene);
    }
}

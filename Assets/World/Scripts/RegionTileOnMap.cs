using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegionTileOnMap : MonoBehaviour
{
    public int idRegion;
    public bool visitedRegion = false;
    public int visitedPoints = 5;
    public int numberOfPoints = 10;
    public int levelOfRegion = 3;
    public string typeOfRegion = "Wild";

    public bool mouseOnTile;

    public WorldDataHolder dataHolder;
    public RegionTileInfo tileInfo;
    void Start()
    {
        dataHolder = FindObjectOfType<WorldDataHolder>();
        tileInfo = FindObjectOfType<RegionTileInfo>();
        SaveField();
    }
    void Update()
    {
        if (mouseOnTile)
        {
            tileInfo.GetRegionData(idRegion, visitedRegion = false, visitedPoints = 5, numberOfPoints = 10, levelOfRegion = 3, typeOfRegion = "Wild");
        }
    }
    
    public void SaveField()
    {
        dataHolder.SaveField(idRegion, visitedRegion = false, visitedPoints = 5, numberOfPoints = 10, levelOfRegion = 3, typeOfRegion = "Wild");
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
        SwitchScene("ExploreScene");
    }
    public void SwitchScene(string nextscene)
    {
        SceneManager.LoadScene(nextscene);
    }

}

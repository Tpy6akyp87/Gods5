using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegionTileOnMap : MonoBehaviour
{
    public bool loaded;
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
        dataHolder.SaveField(loaded, idRegion, visitedRegion = false, visitedPoints = 5, numberOfPoints = 10, levelOfRegion = 3, typeOfRegion = "Wild", structType, structVariant);
    }



    public void AddPoint(int Xpos, int Ypos)
    {

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
        //сделать сортировку и переместить кликнутый тайл на 1 место в листе.или дать ему уник. флаг, который заберется после загрузки сцены
        loaded = true;
        SaveField();
        SwitchScene("ExploreScene");
    }
    public void SwitchScene(string nextscene)
    {
        SceneManager.LoadScene(nextscene);
    }

}

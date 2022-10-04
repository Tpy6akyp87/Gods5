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

    public RegionList regionList;

    public bool mouseOnTile;

    public WorldDataHolder dataHolder;
    public RegionTileInfo tileInfo;
    void Start()
    {
        dataHolder = FindObjectOfType<WorldDataHolder>();
        tileInfo = FindObjectOfType<RegionTileInfo>();
        AddSaveField();
    }
    void Update()
    {
        if (mouseOnTile)
        {
            tileInfo.GetRegionData(idRegion, visitedRegion = false, visitedPoints = 5, numberOfPoints = 10, levelOfRegion = 3, typeOfRegion = "Wild");
        }
    }
    
    public void AddSaveField()
    {
        dataHolder.AddField(loaded, idRegion, visitedRegion = false, visitedPoints = 5, numberOfPoints = 10, levelOfRegion = 3, typeOfRegion = "Wild", structType, structVariant);
        dataHolder.SaveField();
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
        LoadField();
        for (int i = 0; i < regionList.regionS.Count; i++)
        {
            if (regionList.regionS[i].idRegion == idRegion)
            {
                Debug.Log(idRegion);
                Debug.Log(regionList.regionS[i].idRegion);
                regionList.regionS[i].loaded = true;
            }
        }
        SaveField();
        SwitchScene("ExploreScene");
    }
    public void SwitchScene(string nextscene)
    {
        SceneManager.LoadScene(nextscene);
    }
    public void LoadField()
    {
        regionList = JsonUtility.FromJson<RegionList>(File.ReadAllText(Application.dataPath + "/World/regionsData.json"));
    }
    public void SaveField()
    {
        File.WriteAllText(Application.dataPath + "/World/regionsData.json", JsonUtility.ToJson(regionList));
    }


    [System.Serializable]
    public class Region
    {
        public bool loaded;
        public int idRegion;
        public bool isVisitedRegion;
        public int visitedPoints;
        public int numberOfPoints;
        public int levelOfRegion;
        public string typeOfRegion;
        public int structType;
        public int[] structVariant = new int[6];
        public List<Point> points;

    }
    [System.Serializable]
    public class RegionList
    {
        public List<Region> regionS;
    }
    [System.Serializable]
    public class Point
    {
        public bool isVisitedPoint;
        public bool isPossibleToMove;
        public bool isExplorerOnMe;
        public bool canGoUp;
        public bool canGoDown;
        public bool canGoRight;
        public bool canGoLeft;
        public int levelOfPoint;
    }
}

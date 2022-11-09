using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WorldDataHolder : MonoBehaviour
{    
    public RegionList regionList;
    public PlayerData playerData;

    void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        //Get_RegionList();
    }
    [System.Serializable]
    public class RegionList
    {
        public List<Region> regionS;
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
    public class Point
    {
        public float Xpos;
        public float Ypos;
        public bool isVisitedPoint;
        public bool isPossibleToMove;
        public bool isExplorerOnMe;
        public bool canGoUp;
        public bool canGoDown;
        public bool canGoRight;
        public bool canGoLeft;
        public int levelOfPoint;
    }


    public void Add_NewRegionToList(bool loaded, int idRegion, bool isVisitedRegion, int visitedPoints, int numberOfPoints, int levelOfRegion, string typeOfRegion, int structType, int[] structVariant)
    {
        Region region = new Region();
        region.loaded = loaded;
        region.idRegion = idRegion;
        region.isVisitedRegion = isVisitedRegion;
        region.visitedPoints = visitedPoints;
        region.numberOfPoints = numberOfPoints;
        region.levelOfRegion = levelOfRegion;
        region.typeOfRegion = typeOfRegion;
        region.structType = structType;
        region.structVariant = structVariant;
        regionList.regionS.Add(region);
    }

    public void Save_RegionList()
    {
        //File.WriteAllText(Application.dataPath + "/World/regionsData.json", JsonUtility.ToJson(regionList));
        playerData.worldData = regionList;
        playerData.SaveGame();
    }
    [ContextMenu("Load_RegionList()")]
    public void Load_RegionList()
    {
        playerData.LoadGame();
        regionList = playerData.worldData; 
        //regionList = JsonUtility.FromJson<RegionList>(File.ReadAllText(Application.dataPath + "/World/regionsData.json"));
    }

    [ContextMenu("Get_RegionList()")]
    public void Get_RegionList()
    {
        RegionTileOnMap[] regions = FindObjectsOfType<RegionTileOnMap>();
        for (int i = 0; i < regions.Length; i++)
        {
            Add_NewRegionToList(regions[i].loaded, regions[i].idRegion, regions[i].isVisitedRegion, regions[i].visitedPoints, regions[i].numberOfPoints, regions[i].levelOfRegion, regions[i].typeOfRegion, regions[i].structType, regions[i].structVariant);
        }
        Save_RegionList();
    }


    [ContextMenu("Clear")]
    public void Reset_RegionList()
    {
        regionList.regionS.Clear();
        Save_RegionList();
    }
    [ContextMenu("Count")]
    public void Count_RegionList()
    {
        for (int i = 0; i < regionList.regionS.Count; i++)
        {
            Debug.Log("id region = " + regionList.regionS[i].idRegion + ", lvl of Region = " + regionList.regionS[i].levelOfRegion);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WorldDataHolder : MonoBehaviour
{
    public RegionList regionList;
    public PlayerData playerData;

    public void MyOwnAwake()
    {
        playerData = FindObjectOfType<PlayerData>();
        Get_RegionList();
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
        public List<rPoint> points;

    }
    [System.Serializable]
    public class rPoint
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
        region.points = new List<rPoint>();
        regionList.regionS.Add(region);
    }
    //[ContextMenu("111")]
    //public void AAA()
    //{
    //    Add_NewPointToRegion(5, 2.0f, 2.0f, true, true, true, true, true, true, true, 2);
    //}
    public void Add_NewPointToRegion(int regionId, float Xpos, float Ypos, bool isVisitedPoint, bool isPossibleToMove, bool isExplorerOnMe, bool canGoUp, bool canGoDown, bool canGoRight, bool canGoLeft, int levelOfPoint)
    {
        rPoint point = new rPoint();
        point.Xpos = Xpos;
        point.Ypos = Ypos;
        point.isVisitedPoint = isVisitedPoint;
        point.isPossibleToMove = isPossibleToMove;
        point.isExplorerOnMe = isExplorerOnMe;
        point.canGoUp = canGoUp;
        point.canGoDown = canGoDown;
        point.canGoRight = canGoRight;
        point.canGoLeft = canGoLeft;
        point.levelOfPoint = levelOfPoint;
        regionList.regionS[regionId].points.Add(point);
    }

    public void Save_RegionList()
    {
        playerData.worldData = regionList;
        playerData.SaveGame();
        Load_RegionList();
    }
    [ContextMenu("Load_RegionList()")]
    public void Load_RegionList()
    {
        playerData = FindObjectOfType<PlayerData>();
        playerData.LoadGame();
        regionList = playerData.worldData;
    }

    [ContextMenu("Get_RegionList()")]
    public void Get_RegionList()
    {
        Load_RegionList();
        RegionTileOnMap[] regions = FindObjectsOfType<RegionTileOnMap>();
        if (regionList.regionS.Count == 0)
        {
            for (int i = 0; i < regions.Length; i++)
            {
                Add_NewRegionToList(regions[i].loaded, regions[i].idRegion, regions[i].isVisitedRegion, regions[i].visitedPoints, regions[i].numberOfPoints, regions[i].levelOfRegion, regions[i].typeOfRegion, regions[i].structType, regions[i].structVariant);
            }
        }
        for (int i = 0; i < regions.Length; i++)
        {
            for (int j = 0; j < regionList.regionS.Count; j++)
            {
                if (regions[i].idRegion == regionList.regionS[j].idRegion)
                {
                    regions[i].Take_Data(regionList.regionS[j]);
                }
            }
        }
        Save_RegionList();
    }
    public void GetPlArmLvl()
    {
        playerData.LoadGame();
        if (playerData.playerArmyLimit == 0)
        {
            playerData.playerArmyLimit = 100 + playerData.townData.townLevel;
        }
        playerData.SaveGame();
    }
}

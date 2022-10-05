using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WorldDataHolder : MonoBehaviour
{    
    public RegionList regionList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void AddField(bool loaded, int idRegion, bool isVisitedRegion, int visitedPoints, int numberOfPoints, int levelOfRegion, string typeOfRegion, int structType, int[] structVariant)
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

    public void SaveField()
    {
        File.WriteAllText(Application.dataPath + "/World/regionsData.json", JsonUtility.ToJson(regionList));
    }
}

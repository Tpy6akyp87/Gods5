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

    public RegionList regionList;
    void Start()
    {
        SaveField();
    }
    void Update()
    {
        
    }
    [System.Serializable]
    public class Region
    {
        public int idRegion;
        public bool isvisitedRegion;
        public int visitedPoints;
        public int numberOfPoints;
        public int levelOfRegion;
        public string typeOfRegion;
    }
    [System.Serializable]
    public class RegionList
    {
        public List<Region> regionS;
    }
    
    [ContextMenu("Load")]
    public void LoadField()
    {
        regionList = JsonUtility.FromJson<RegionList>(File.ReadAllText(Application.dataPath + "/World/regionsData.json"));
    }
    public void SaveField()
    {
        Region region = new Region();
        region.idRegion = idRegion;
        region.isvisitedRegion = visitedRegion;
        region.visitedPoints = visitedPoints;
        region.numberOfPoints = numberOfPoints;
        region.levelOfRegion = levelOfRegion;
        region.typeOfRegion = typeOfRegion;
        Debug.Log(region.idRegion);
        regionList.regionS.Add(region);
        File.WriteAllText(Application.dataPath + "/World/regionsData.json", JsonUtility.ToJson(regionList));
    }
}

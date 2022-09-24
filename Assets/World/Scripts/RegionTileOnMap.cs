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

    public Region region;
    public RegionList regionList;
    void Start()
    {
        PutRegionStats();
        SaveField();
    }

    public void PutRegionStats()
    {
        region.regidRegion = idRegion;
        region.regIsvisitedRegion = visitedRegion;
        region.regvisitedPoints = visitedPoints;
        region.regnumberOfPoints = numberOfPoints;
        region.reglevelOfRegion = levelOfRegion;
        region.regtypeOfRegion = typeOfRegion;
    }
    
    void Update()
    {
        
    }

    [System.Serializable]
    public class Region
    {
        public int regidRegion;
        public bool regIsvisitedRegion;
        public int regvisitedPoints;
        public int regnumberOfPoints;
        public int reglevelOfRegion;
        public string regtypeOfRegion;
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
        Debug.Log(region.regidRegion);
        regionList.regionS.Add(region);
        File.WriteAllText(Application.dataPath + "/World/regionsData.json", JsonUtility.ToJson(regionList));
    }
}

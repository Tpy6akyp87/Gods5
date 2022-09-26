using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataHolder : MonoBehaviour
{
    public Region[] regionEs = new Region[12];
    public RegionList regionList;
    public RegionTileOnMap[] regionTiles;
    void Start()
    {
        regionTiles = FindObjectsOfType<RegionTileOnMap>();
        //regionTiles = GetComponents<RegionTileOnMap>();
        for (int i = 0; i < regionTiles.Length; i++)
        {
            regionEs[i].regidRegion = regionTiles[i].idRegion;
            regionEs[i].regIsvisitedRegion = regionTiles[i].visitedRegion;
            regionEs[i].regvisitedPoints = regionTiles[i].visitedPoints;
            regionEs[i].regnumberOfPoints = regionTiles[i].numberOfPoints;
            regionEs[i].reglevelOfRegion = regionTiles[i].levelOfRegion;
            regionEs[i].regtypeOfRegion = regionTiles[i].typeOfRegion;
        }
    }

    // Update is called once per frame
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
        public Region[] regionS = new Region[12];
    }
    [ContextMenu("Save")]
    public void SaveField()
    {
        File.WriteAllText(Application.dataPath + "/World/regionsData.json", JsonUtility.ToJson(regionEs));
    }
}

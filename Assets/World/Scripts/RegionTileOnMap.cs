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

    //public DataHolder dataHolder;
    //public Region region;
    //public RegionList regionList;
    void Start()
    {
        //dataHolder = FindObjectOfType<DataHolder>();
        
        //SaveField();
    }

    //public void PutRegionStats()
    //{
    //    region.regidRegion = idRegion;
    //    region.regIsvisitedRegion = visitedRegion;
    //    region.regvisitedPoints = visitedPoints;
    //    region.regnumberOfPoints = numberOfPoints;
    //    region.reglevelOfRegion = levelOfRegion;
    //    region.regtypeOfRegion = typeOfRegion;
    //}
    
    void Update()
    {
        
    }
    //[System.Serializable]
    //public class Region
    //{
    //    public int regidRegion;
    //    public bool regIsvisitedRegion;
    //    public int regvisitedPoints;
    //    public int regnumberOfPoints;
    //    public int reglevelOfRegion;
    //    public string regtypeOfRegion;
    //}

    //[ContextMenu("Load")]
    ////public void LoadField()
    ////{
    ////    dataHolder.regionList = JsonUtility.FromJson<RegionList>(File.ReadAllText(Application.dataPath + "/World/regionsData.json"));
    ////}
    //public void SaveField()
    //{
    //    //PutRegionStats();
    //    dataHolder.regionList.regionS.Add(region); //при каждом добавлении в лист, я меняю только переменную регион в датахолдере, лист - это набор ссылок, поэтому надо сделать массив регионов?
    //    Debug.Log(dataHolder.region.regidRegion);
    //    //File.WriteAllText(Application.dataPath + "/World/regionsData.json", JsonUtility.ToJson(dataHolder.regionList));
    //}
}

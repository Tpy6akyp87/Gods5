using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegionBuilder : MonoBehaviour
{
    public int structType = 0;
    public int[] structVariant = new int[6];
    public GameObject tile00;
    public GameObject tile10;
    public GameObject tile20;
    public GameObject tile01;
    public GameObject tile11;
    public GameObject tile21;
    public int numberOfPoints;

    public int currentNum;
    public WorldDataHolder dataHolder;

    //public RegionList regionList;
    public WorldDataHolder.Point [] pointArray;


    void Start()
    {
        dataHolder = FindObjectOfType<WorldDataHolder>();
        dataHolder.Load_RegionList();

        for (int i = 0; i < dataHolder.regionList.regionS.Count; i++) //поиск региона по флагу loaded
        {
            if (dataHolder.regionList.regionS[i].loaded)
            {
                currentNum = i; break;
            }
        }
        dataHolder.regionList.regionS[currentNum].loaded = false;

        if (dataHolder.regionList.regionS[currentNum].isVisitedRegion)
        {
            Debug.Log(dataHolder.regionList.regionS[currentNum].idRegion + "  Visited");
            structType = dataHolder.regionList.regionS[currentNum].structType;
            structVariant = dataHolder.regionList.regionS[currentNum].structVariant;
        }
        else 
        {
            for (int i = 0; i < structVariant.Length; i++)
            {
                structVariant[i] = Random.Range(0, 3);
            }
            dataHolder.regionList.regionS[currentNum].isVisitedRegion = true;
            
        }
        
        tile00 = Resources.Load<GameObject>(structType.ToString() + structVariant[0].ToString() + ".0-0");
        tile10 = Resources.Load<GameObject>(structType.ToString() + structVariant[1].ToString() + ".1-0");
        tile20 = Resources.Load<GameObject>(structType.ToString() + structVariant[2].ToString() + ".2-0");
        tile01 = Resources.Load<GameObject>(structType.ToString() + structVariant[3].ToString() + ".0-1");
        tile11 = Resources.Load<GameObject>(structType.ToString() + structVariant[4].ToString() + ".1-1");
        tile21 = Resources.Load<GameObject>(structType.ToString() + structVariant[5].ToString() + ".2-1");

        GameObject neweTile00 = Instantiate(tile00, new Vector3(0f, 0f, 0), tile00.transform.rotation) as GameObject;
        GameObject neweTile10 = Instantiate(tile10, new Vector3(2f, 0f, 0), tile10.transform.rotation) as GameObject;
        GameObject neweTile20 = Instantiate(tile20, new Vector3(4f, 0f, 0), tile20.transform.rotation) as GameObject;
        GameObject neweTile01 = Instantiate(tile01, new Vector3(0f, 2f, 0), tile01.transform.rotation) as GameObject;
        GameObject neweTile11 = Instantiate(tile11, new Vector3(2f, 2f, 0), tile11.transform.rotation) as GameObject;
        GameObject neweTile21 = Instantiate(tile21, new Vector3(4f, 2f, 0), tile21.transform.rotation) as GameObject;
        CountPoints();
        SaveField();
    }

    // выходит в json по idReg - stuctType/structVariant/numberOfPoints
    void Update()
    {
        
    }
    public void CountPoints()
    {
        pointArray = FindObjectsOfType<WorldDataHolder.Point>();
        numberOfPoints = pointArray.Length;
        for (int i = 0; i < pointArray.Length; i++)
        {
            WorldDataHolder.Point point = new WorldDataHolder.Point();
            point.Xpos = pointArray[i].transform.position.x;
            point.Ypos = pointArray[i].transform.position.y;
            point.isVisitedPoint = pointArray[i].isVisitedPoint;
            point.isPossibleToMove = pointArray[i].isPossibleToMove;
            point.isExplorerOnMe = pointArray[i].isExplorerOnMe;
            point.canGoUp = pointArray[i].canGoUp;
            point.canGoDown = pointArray[i].canGoDown;
            point.canGoRight = pointArray[i].canGoRight;
            point.canGoLeft = pointArray[i].canGoLeft;
            point.levelOfPoint = pointArray[i].levelOfPoint;
            dataHolder.regionList.regionS[currentNum].points.Add(point);
        }
    }
    //public void LoadField()
    //{
    //    dataHolder.regionList = JsonUtility.FromJson<RegionList>(File.ReadAllText(Application.dataPath + "/World/regionsData.json"));
    //}
    public void SaveField()
    {
        dataHolder.regionList.regionS[currentNum].isVisitedRegion = true;
        dataHolder.regionList.regionS[currentNum].structType = structType;
        dataHolder.regionList.regionS[currentNum].structVariant = structVariant;
        dataHolder.regionList.regionS[currentNum].numberOfPoints = numberOfPoints;
        dataHolder.Save_RegionList();
    }
    public void SwitchScene(string nextscene)
    {
        SceneManager.LoadScene(nextscene);
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
        public List<PointBuilder> points;
        
    }
    [System.Serializable]
    public class RegionList
    {
        public List<Region> regionS;
    }
    [System.Serializable]
    public class PointBuilder
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
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class RegionBuilder : MonoBehaviour
{
    public int stuctType = 0;
    public int[] structVariant = new int[6];
    public GameObject tile00;
    public GameObject tile10;
    public GameObject tile20;
    public GameObject tile01;
    public GameObject tile11;
    public GameObject tile21;
    public int numberOfPoints;

    public RegionList regionList;


    // сюда приходит idReg/lvlReg/typeReg
    void Start()
    {
        LoadField();
        for (int i = 0; i < structVariant.Length; i++)
        {
            structVariant[i] = Random.Range(0, 3);
        }
        tile00 = Resources.Load<GameObject>(stuctType.ToString() + structVariant[0].ToString() + ".0-0");
        tile10 = Resources.Load<GameObject>(stuctType.ToString() + structVariant[1].ToString() + ".1-0");
        tile20 = Resources.Load<GameObject>(stuctType.ToString() + structVariant[2].ToString() + ".2-0");
        tile01 = Resources.Load<GameObject>(stuctType.ToString() + structVariant[3].ToString() + ".0-1");
        tile11 = Resources.Load<GameObject>(stuctType.ToString() + structVariant[4].ToString() + ".1-1");
        tile21 = Resources.Load<GameObject>(stuctType.ToString() + structVariant[5].ToString() + ".2-1");

        GameObject neweTile00 = Instantiate(tile00, new Vector3(0f, 0f, 0), tile00.transform.rotation) as GameObject;
        GameObject neweTile10 = Instantiate(tile10, new Vector3(2f, 0f, 0), tile10.transform.rotation) as GameObject;
        GameObject neweTile20 = Instantiate(tile20, new Vector3(4f, 0f, 0), tile20.transform.rotation) as GameObject;
        GameObject neweTile01 = Instantiate(tile01, new Vector3(0f, 2f, 0), tile01.transform.rotation) as GameObject;
        GameObject neweTile11 = Instantiate(tile11, new Vector3(2f, 2f, 0), tile11.transform.rotation) as GameObject;
        GameObject neweTile21 = Instantiate(tile21, new Vector3(4f, 2f, 0), tile21.transform.rotation) as GameObject;
    }

    // выходит в json по idReg - stuctType/structVariant/numberOfPoints
    void Update()
    {
        
    }

    [System.Serializable]
    public class Region
    {
        public int idRegion;
        public bool isVisitedRegion;
        public int visitedPoints;
        public int numberOfPoints;
        public int levelOfRegion;
        public string typeOfRegion;
        public int structType;
        public int[] structVariant = new int[6];
        public List<Point> points;

        public void AddPoint(int Xpos, int Ypos)
        {

        }
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
    [System.Serializable]
    public class RegionList
    {
        public List<Region> regionS;
    }
    public void SaveField(int idRegion, bool isVisitedRegion, int visitedPoints, int numberOfPoints, int levelOfRegion, string typeOfRegion, int structType, int[] structVariant)
    {
        Region region = new Region();
        region.idRegion = idRegion;
        region.isVisitedRegion = isVisitedRegion;
        region.visitedPoints = visitedPoints;
        region.numberOfPoints = numberOfPoints;
        region.levelOfRegion = levelOfRegion;
        region.typeOfRegion = typeOfRegion;
        region.structType = structType;
        region.structVariant = structVariant;
        regionList.regionS.Add(region);
        File.WriteAllText(Application.dataPath + "/World/regionsData.json", JsonUtility.ToJson(regionList));
    }
    public void LoadField()
    {
        regionList = JsonUtility.FromJson<RegionList>(File.ReadAllText(Application.dataPath + "/World/regionsData.json"));
    }
}

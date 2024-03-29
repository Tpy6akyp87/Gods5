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
    public int thisRegionID;
    public WorldDataHolder dataHolder;
    public Point [] pointArray;
    public Explorer explorer;
    void Start()
    {
        dataHolder = FindObjectOfType<WorldDataHolder>();
        dataHolder.Load_RegionList();
        explorer = FindObjectOfType<Explorer>();
        for (int i = 0; i < dataHolder.regionList.regionS.Count; i++)
        {
            if (dataHolder.regionList.regionS[i].loaded)
            {
                thisRegionID = i; break;
            }
        }
        
        if (dataHolder.regionList.regionS[thisRegionID].isVisitedRegion)
        {
            structType = dataHolder.regionList.regionS[thisRegionID].structType;
            structVariant = dataHolder.regionList.regionS[thisRegionID].structVariant;
        }
        else 
        {
            for (int i = 0; i < structVariant.Length; i++)
            {
                structVariant[i] = Random.Range(0, 3);
            }
            dataHolder.regionList.regionS[thisRegionID].isVisitedRegion = true;
            dataHolder.Save_RegionList();
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
        Save_RegionStruct();
    }
    public void CountPoints()
    {
        pointArray = FindObjectsOfType<Point>();
        numberOfPoints = pointArray.Length;
        for (int i = 0; i < pointArray.Length; i++)
        {
            WorldDataHolder.Point point = new WorldDataHolder.Point();
            point.Xpos = pointArray[i].transform.position.x;
            point.Ypos = pointArray[i].transform.position.y;
            point.isVisitedPoint = false;
            point.isVisitedPoint = pointArray[i].isVisitedPoint;
            point.isPossibleToMove = pointArray[i].isPossibleToMove;
            point.isExplorerOnMe = pointArray[i].isExplorerOnMe;
            point.canGoUp = pointArray[i].canGoUp;
            point.canGoDown = pointArray[i].canGoDown;
            point.canGoRight = pointArray[i].canGoRight;
            point.canGoLeft = pointArray[i].canGoLeft;
            point.levelOfPoint = pointArray[i].levelOfPoint;
            dataHolder.regionList.regionS[thisRegionID].points.Add(point);
        }
    }
    public void Save_RegionStruct()
    {
        dataHolder.regionList.regionS[thisRegionID].isVisitedRegion = true;
        dataHolder.regionList.regionS[thisRegionID].structType = structType;
        dataHolder.regionList.regionS[thisRegionID].structVariant = structVariant;
        dataHolder.regionList.regionS[thisRegionID].numberOfPoints = numberOfPoints;
        dataHolder.Save_RegionList();
    }
    public void SwitchScene(string nextscene)
    {
        if (nextscene == "World")
        {
            explorer.Save_Position(new Vector3(-0.5f, -0.5f, 0.0f));
        }
        dataHolder.regionList.regionS[thisRegionID].loaded = false;
        Save_RegionStruct();
        SceneManager.LoadScene(nextscene);
    }
}

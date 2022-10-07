using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Explorer : MonoBehaviour
{
    public WorldDataHolder dataHolder;
    public int thisRegionID;
    public float Xpos;
    public float Ypos;
    public float speed;
    public Vector3 nextPoint;
    public bool needToMove;
    public bool canGoUp;
    public bool canGoDown;
    public bool canGoRight;
    public bool canGoLeft;





    void Start()
    {
        dataHolder = FindObjectOfType<WorldDataHolder>();
        dataHolder.Load_RegionList();
        for (int i = 0; i < dataHolder.regionList.regionS.Count; i++)
        {
            if (dataHolder.regionList.regionS[i].loaded)
            {
                thisRegionID = i; break;
            }
        }
    }
    void Update()
    {
        if (needToMove)
        {
            MoveToPoint(nextPoint);
        }
        if (canGoUp) // need to add PointList here
        {
            for (int i = 0; i < dataHolder.regionList.regionS[thisRegionID].points.Count; i++)
            {
                
            }
        }
    }

    public void MoveToPoint(Vector3 pointPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, pointPosition, speed * Time.deltaTime);
    }

    public void CheckMyPoint(float Xpos, float Ypos) //убрать отсюда, и проверку isExplorerOnMe поставить в Point
    {
        for (int i = 0; i < dataHolder.regionList.regionS[thisRegionID].points.Count; i++)
        {
            if (dataHolder.regionList.regionS[thisRegionID].points[i].Xpos == Xpos && dataHolder.regionList.regionS[thisRegionID].points[i].Ypos == Ypos)
            {
                dataHolder.regionList.regionS[thisRegionID].points[i].isExplorerOnMe = true;
            }
            else
            {
                dataHolder.regionList.regionS[thisRegionID].points[i].isExplorerOnMe = false;
            }
        }
    }














































    //public Text text;
    //public Pos pos;
    //public PointToSave pointToSave;
    //public Point[] points;


    //public float speed;
    //public float mindist;
    //public bool needToMove;
    //public Vector3 poointToMove;

    //void Start()
    //{

    //}

    //void Update()
    //{
    //    if (needToMove)
    //    {
    //        MoveToPoint(poointToMove);
    //    }
    //}
    //void Awake()
    //{
    //    LoadField();
    //    points = FindObjectsOfType<Point>();
    //    for (int i = 0; i < points.Length; i++)
    //    {
    //        points[i].LoadPoint();
    //    }

    //    transform.position = pos.PosX;
    //}
    //public void MoveToPoint(Vector3 pointPosition)
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, pointPosition, speed * Time.deltaTime);
    //}
    //[System.Serializable]
    //public class Pos
    //{
    //    public Vector3 PosX;
    //}
    //[System.Serializable]
    //public class PointToSave
    //{
    //    public List<Vector3> points;
    //}
    //[ContextMenu("Load")]
    //public void LoadField()
    //{
    //    pos = JsonUtility.FromJson<Pos>(File.ReadAllText(Application.dataPath + "/Explorer/exploredata.json"));
    //    pointToSave = JsonUtility.FromJson<PointToSave>(File.ReadAllText(Application.dataPath + "/Explorer/exploredata1.json"));
    //}
    //public void SaveField()
    //{
    //    pos.PosX = poointToMove;
    //    pointToSave.points.Add(poointToMove);
    //    File.WriteAllText(Application.dataPath + "/Explorer/exploredata.json", JsonUtility.ToJson(pos));
    //    File.WriteAllText(Application.dataPath + "/Explorer/exploredata1.json", JsonUtility.ToJson(pointToSave));
    //}
}

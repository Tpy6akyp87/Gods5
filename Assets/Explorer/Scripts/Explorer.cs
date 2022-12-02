using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

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
    public Point[] pointArray;
    public Vector3 explorerPosition;

   
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
        CheckMyPoint();
        Load_Position(out explorerPosition);
        transform.position = explorerPosition;
    }
    void Update()
    {
        if (needToMove)
        {
            MoveToPoint(nextPoint);
        }
    }

    public void MoveToPoint(Vector3 pointPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, pointPosition, speed * Time.deltaTime);
    }

    public void CheckMyPoint()
    {
        dataHolder.Load_RegionList();
        for (int i = 0; i < dataHolder.regionList.regionS[thisRegionID].points.Count; i++)
        {
            if (dataHolder.regionList.regionS[thisRegionID].points[i].Xpos == transform.position.x && (dataHolder.regionList.regionS[thisRegionID].points[i].Ypos - 1.0) == transform.position.y && canGoUp)
                dataHolder.regionList.regionS[thisRegionID].points[i].isPossibleToMove = true;
            else if (dataHolder.regionList.regionS[thisRegionID].points[i].Xpos == transform.position.x && (dataHolder.regionList.regionS[thisRegionID].points[i].Ypos + 1.0) == transform.position.y && canGoDown)
                dataHolder.regionList.regionS[thisRegionID].points[i].isPossibleToMove = true;
            else if ((dataHolder.regionList.regionS[thisRegionID].points[i].Xpos - 1) == transform.position.x && dataHolder.regionList.regionS[thisRegionID].points[i].Ypos == transform.position.y && canGoLeft)
                dataHolder.regionList.regionS[thisRegionID].points[i].isPossibleToMove = true;
            else if ((dataHolder.regionList.regionS[thisRegionID].points[i].Xpos + 1) == transform.position.x && dataHolder.regionList.regionS[thisRegionID].points[i].Ypos == transform.position.y && canGoRight)
                dataHolder.regionList.regionS[thisRegionID].points[i].isPossibleToMove = true;
            else dataHolder.regionList.regionS[thisRegionID].points[i].isPossibleToMove = false;
        }
        dataHolder.Save_RegionList();        
    }
    public void Save_Position(Vector3 explorerPosition)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/explorerPosition.dat");
        SaveData data = new SaveData();
        data.x = explorerPosition.x;
        data.y = explorerPosition.y;
        data.z = explorerPosition.z;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Explorer position saved!");

        //File.WriteAllText(Application.dataPath + "/Explorer/explorerData.json", JsonUtility.ToJson(explorerPosition));
    }
    public void Load_Position(out Vector3 explorerPosition)
    {
        explorerPosition = new Vector3();
        if (File.Exists(Application.persistentDataPath + "/explorerPosition.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/explorerPosition.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            explorerPosition.x = data.x;
            explorerPosition.y = data.y;
            explorerPosition.z = data.z;

            Debug.Log("Explorer position loaded!");
        }
        else
            Debug.Log("There is no Explorer position!");

        
        //transform.position = JsonUtility.FromJson<Vector3>(File.ReadAllText(Application.dataPath + "/Explorer/explorerData.json"));
    }
    [System.Serializable]
    class SaveData
    {
        public float x;
        public float y;
        public float z;
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

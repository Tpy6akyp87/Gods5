using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

   
    // сюда приходит idReg/lvlReg/typeReg
    void Start()
    {
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

}

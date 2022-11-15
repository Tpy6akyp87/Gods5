using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionTileInfo : MonoBehaviour
{
    public Text txtidRegion;
    public Text txtvisitedRegion;
    public Text txtvisitedPoints;
    public Text txtnumberOfPoints;
    public Text txtlevelOfRegion;
    public Text txttypeOfRegion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetRegionData(int idRegion, bool isVisitedRegion, int visitedPoints, int numberOfPoints, int levelOfRegion, string typeOfRegion)
    {
        txtidRegion.text = "ID ������� = " + idRegion.ToString();
        if (isVisitedRegion)
        {
            txtvisitedRegion.text = "��������";
        }
        else
        {
            txtvisitedRegion.text = "�� ��������";
        }
        txtvisitedPoints.text = "�������� ���� " + visitedPoints.ToString();
        txtnumberOfPoints.text = "����� ���� " + numberOfPoints.ToString();
        txtlevelOfRegion.text = "��������� ������� = " + levelOfRegion.ToString();
        txttypeOfRegion.text = "��� ������� - " + typeOfRegion.ToString();
    }
    public void NoneRegionData()
    {
        txtidRegion.text = "";
        txtvisitedRegion.text = "";
        txtvisitedPoints.text = "" ;
        txtnumberOfPoints.text = "";
        txtlevelOfRegion.text = "";
        txttypeOfRegion.text = "";
    }
}

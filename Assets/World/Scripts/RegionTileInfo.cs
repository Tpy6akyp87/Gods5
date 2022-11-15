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
        txtidRegion.text = "ID региона = " + idRegion.ToString();
        if (isVisitedRegion)
        {
            txtvisitedRegion.text = "Посещено";
        }
        else
        {
            txtvisitedRegion.text = "Не посещено";
        }
        txtvisitedPoints.text = "Посещено мест " + visitedPoints.ToString();
        txtnumberOfPoints.text = "Всего мест " + numberOfPoints.ToString();
        txtlevelOfRegion.text = "Сложность региона = " + levelOfRegion.ToString();
        txttypeOfRegion.text = "Тип региона - " + typeOfRegion.ToString();
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

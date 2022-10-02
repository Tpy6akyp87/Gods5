using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegionTileOnMap : MonoBehaviour
{
    public int idRegion;
    public bool visitedRegion;
    public int visitedPoints;
    public int numberOfPoints;
    public int levelOfRegion;
    public string typeOfRegion;
    public int structType = 1;
    public int[] structVariant = {0,0,0,0,0,0};

    public bool mouseOnTile;

    public WorldDataHolder dataHolder;
    public RegionTileInfo tileInfo;
    void Start()
    {
        dataHolder = FindObjectOfType<WorldDataHolder>();
        tileInfo = FindObjectOfType<RegionTileInfo>();
        SaveField();
    }
    void Update()
    {
        if (mouseOnTile)
        {
            tileInfo.GetRegionData(idRegion, visitedRegion = false, visitedPoints = 5, numberOfPoints = 10, levelOfRegion = 3, typeOfRegion = "Wild");
        }
    }
    
    public void SaveField()
    {
        dataHolder.SaveField(idRegion, visitedRegion = false, visitedPoints = 5, numberOfPoints = 10, levelOfRegion = 3, typeOfRegion = "Wild", structType, structVariant);
    }

    void OnMouseOver()
    {
        mouseOnTile = true;
    }

    void OnMouseExit()
    {
        mouseOnTile = false;
    }

    void OnMouseDown()
    {
        //������� ���������� � ����������� ��������� ���� �� 1 ����� � �����.��� ���� ��� ����. ����, ������� ��������� ����� �������� �����
        SwitchScene("ExploreScene");
    }
    public void SwitchScene(string nextscene)
    {
        SceneManager.LoadScene(nextscene);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldOperator : MonoBehaviour
{
    public WorldDataHolder dataHolder;
    public RegionTileOnMap[] regionTiles;

    void Start()
    {
        dataHolder = FindObjectOfType<WorldDataHolder>();
        regionTiles = FindObjectsOfType<RegionTileOnMap>();
    }
    [ContextMenu("Get_RegionsList")]
    public void Get_RegionsList()
    {
        for (int i = 0; i < regionTiles.Length; i++)
        {
            dataHolder.Add_NewRegionToList(regionTiles[i].loaded, regionTiles[i].idRegion, regionTiles[i].isVisitedRegion, regionTiles[i].visitedPoints, regionTiles[i].numberOfPoints, regionTiles[i].levelOfRegion, regionTiles[i].typeOfRegion, regionTiles[i].structType = 0, regionTiles[i].structVariant);
        }
    }

}

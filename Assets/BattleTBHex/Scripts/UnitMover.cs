using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMover : MonoBehaviour
{
    public bool myTurn;
    public float moveDistance;

    [ContextMenu("MyTurn_Test")]
    public void MyTurn_Test()
    {
        HexTile[] hexTiles = FindObjectsOfType<HexTile>();
        for (int i = 0; i < hexTiles.Length; i++)
        {
            if ((transform.position - hexTiles[i].transform.position).magnitude > 0.5f && (transform.position - hexTiles[i].transform.position).magnitude < moveDistance)
            {
                hexTiles[i].sprite.color = Color.red;
                hexTiles[i].canMoveOnMe = true;
            }
        }
    }
}

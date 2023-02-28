using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{
    public bool empty;
    //public bool unitOnMe;
    public bool canMoveOnMe;
    public SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMoveOnMe) sprite.color = Color.gray;
        else sprite.color = Color.white;

    }
    void OnMouseDown()
    {
        UnitMover[] unitMovers;
        unitMovers = FindObjectsOfType<UnitMover>();
        for (int i = 0; i < unitMovers.Length; i++)
        {
            if (unitMovers[i].myTurn == true && canMoveOnMe)
            {
                unitMovers[i].Move_To(transform.position);
            }
        }
        
        Debug.Log("OnMouseDown");
    }
    public void Check_OnMe()
    {
        Debug.Log("Check_OnMe");
        UnitMover[] unitMovers;
        unitMovers = FindObjectsOfType<UnitMover>();
        empty = true;
        for (int i = 0; i < unitMovers.Length; i++)
        {
            if (unitMovers[i].transform.position == transform.position)
            {
                //unitOnMe = true;
                empty = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HexTile : MonoBehaviour, IPointerEnterHandler//, IPointerExitHandler
{
    public bool empty;
    public bool canMoveOnMe;
    public bool canbeAttacked;
    public bool canMove;
    public SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (canMoveOnMe) sprite.color = Color.gray;
        else if (canbeAttacked) sprite.color = Color.red;
        else if (canMove) sprite.color = Color.green;
        else sprite.color = Color.white;

    }
    public void Check_OnMe()
    {
        HexUnit[] hexUnits = FindObjectsOfType<HexUnit>();
        empty = true;
        for (int i = 0; i < hexUnits.Length; i++)
        {
            if (hexUnits[i].transform.position == transform.position)
            {
                empty = false;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UnitMover[] unitMovers;
        unitMovers = FindObjectsOfType<UnitMover>();
        for (int i = 0; i < unitMovers.Length; i++)
        {
            if (unitMovers[i].myTurn == true && canMoveOnMe)
            {
                unitMovers[i].moveTo = transform.position;
                break;
            }
        }
        for (int i = 0; i < unitMovers.Length; i++)
        {
            if (unitMovers[i].myTurn == true && !empty || unitMovers[i].myTurn == true && empty && !canMoveOnMe)
            {
                unitMovers[i].moveTo = new Vector3(100, 100, 100);
            }
        }
        
    }

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    UnitMover[] unitMovers;
    //    unitMovers = FindObjectsOfType<UnitMover>();
    //    for (int i = 0; i < unitMovers.Length; i++)
    //    {
    //        if (unitMovers[i].myTurn == true && canMoveOnMe)
    //        {
    //            unitMovers[i].moveTo = new Vector3(100,100,100);
    //            break;
    //        }
    //    }
    //}

}

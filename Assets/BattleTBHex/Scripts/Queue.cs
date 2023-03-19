using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    public HexUnit[] hexUnits;
    UnitAction unitAction;
    public void MyStart()
    {
        unitAction = FindObjectOfType<UnitAction>();
        HexUnit tempMover;
        hexUnits = FindObjectsOfType<HexUnit>();
        for (int i = 0; i < hexUnits.Length -1; i++)
            for (int j = i+1; j < hexUnits.Length; j++)
                if (hexUnits[i].initative > hexUnits[j].initative)
                {
                    tempMover = hexUnits[i];
                    hexUnits[i] = hexUnits[j];
                    hexUnits[j] = tempMover;
                }
        hexUnits[0].myTurn = true;
        hexUnits[0].MyTurn();
        unitAction.Check_UnitForAbility();
    }
    [ContextMenu("Next_Turn")]
    public void Next_Turn()
    {
        for (int i = 0; i < hexUnits.Length; i++)
        {
            if (hexUnits[i].myTurn == true)
            {
                if (i == hexUnits.Length - 1)
                {
                    hexUnits[i].myTurn = false;
                    hexUnits[0].myTurn = true;
                    hexUnits[0].MyTurn();
                }
                else
                {
                    hexUnits[i].myTurn = false;
                    hexUnits[i+1].myTurn = true;
                    hexUnits[i + 1].MyTurn();
                }
                break;
            }
        }
        unitAction.Check_UnitForAbility();
    }

    void Update()
    {
        
    }
}

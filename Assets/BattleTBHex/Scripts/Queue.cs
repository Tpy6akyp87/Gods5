using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    public UnitMover[] unitMovers;
    public void MyStart()
    {
        UnitMover tempMover;
        unitMovers = FindObjectsOfType<UnitMover>();
        for (int i = 0; i < unitMovers.Length -1; i++)
            for (int j = i+1; j < unitMovers.Length; j++)
                if (unitMovers[i].initative > unitMovers[j].initative)
                {
                    tempMover = unitMovers[i];
                    unitMovers[i] = unitMovers[j];
                    unitMovers[j] = tempMover;
                }
        unitMovers[0].myTurn = true;
        unitMovers[0].MyTurn_Test();
    }
    [ContextMenu("Next_Turn")]
    public void Next_Turn()
    {
        for (int i = 0; i < unitMovers.Length; i++)
        {
            if (unitMovers[i].myTurn == true)
            {
                if (i == unitMovers.Length - 1)
                {
                    unitMovers[i].myTurn = false;
                    unitMovers[0].myTurn = true;
                    unitMovers[0].MyTurn_Test();
                }
                else
                {
                    unitMovers[i].myTurn = false;
                    unitMovers[i+1].myTurn = true;
                    unitMovers[i + 1].MyTurn_Test();
                }
                break;
            }
        }
    }

    void Update()
    {
        
    }
}

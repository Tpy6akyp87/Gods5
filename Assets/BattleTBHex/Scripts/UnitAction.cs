using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAction : MonoBehaviour
{
    public int numOfAbility;
    public GameObject defenderAbSet;
    public GameObject damagerAbSet;
    public GameObject healerAbSet;
    public void Swing_1_Attack()
    {
        numOfAbility = 1;
    }
    public void Fire_2_Ball()
    {
        numOfAbility = 2;
    }
    public void Check_UnitForAbility()
    {
        UnitMover[] unitMovers = FindObjectsOfType<UnitMover>();
        for (int i = 0; i < unitMovers.Length; i++)
        {
            if (unitMovers[i].myTurn && unitMovers[i].name == "Defender")
            {
                defenderAbSet.SetActive(true);
                damagerAbSet.SetActive(false);
                healerAbSet.SetActive(false);
                numOfAbility = 1;
            }
            else if (unitMovers[i].myTurn && unitMovers[i].name == "Damager")
            {
                defenderAbSet.SetActive(false);
                damagerAbSet.SetActive(true);
                healerAbSet.SetActive(false);
                numOfAbility = 2;
            }
            else if (unitMovers[i].myTurn && unitMovers[i].name == "Healer")
            {
                defenderAbSet.SetActive(false);
                damagerAbSet.SetActive(false);
                healerAbSet.SetActive(true);
            }
        }
    }
}

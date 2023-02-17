using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfBattle : MonoBehaviour
{
    public Field field;
    public ResourseHolder resourseHolder; 
    public EnemyBattle[] enemyBattles;
    public CharBattle[] charBattles;
    public bool startCount;
    void Start()
    {
        field = FindObjectOfType<Field>();
        resourseHolder = FindObjectOfType<ResourseHolder>();
    }
    void Update()
    {
        if (startCount)
        {
            CountOf_Army();
        }
    }
    [ContextMenu ("CountOf_Army")]
    public void CountOf_Army()
    {
        enemyBattles = FindObjectsOfType<EnemyBattle>();
        charBattles = FindObjectsOfType<CharBattle>();
        Debug.Log("CountOf_Army():  " + "  charBattles.Length = " + charBattles.Length + ",  enemyBattles.Length = " + enemyBattles.Length);
        
        if (enemyBattles.Length == 0)
        {
            Debug.Log("Player Wins");
            for (int i = 0; i < charBattles.Length; i++)
            {
                charBattles[i].start = false;
                Debug.Log("false");
            }
            startCount = false;
            resourseHolder.resources.charcoal += Mathf.RoundToInt(12*field.enemyTeam.enemyArmyWeight/100);
            resourseHolder.Save_Resourses();
        }
    
        if (charBattles.Length == 0)
        {
            Debug.Log("Enemy Wins");
            for (int i = 0; i < enemyBattles.Length; i++)
            {
                enemyBattles[i].start = false;
                Debug.Log("false");
            }
            startCount = false;
        }
    }
}

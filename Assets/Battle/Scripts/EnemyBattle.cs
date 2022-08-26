using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBattle : UnitBattle
{
    void Start()
    {
    }

    void Update()
    {
       
    }
    public void Attack(int Xpos, int Ypos, int damage)
    {
        field.isDamaged[Xpos,2] = true;
        field.damage[Xpos, 2] = damage;
        field.isDamaged[Xpos - 1,2] = true;
        field.damage[Xpos - 1,2] = damage;
        field.isDamaged[Xpos + 1, 2] = true;
        field.damage[Xpos + 1, 2] = damage;
        timeToAttack = false;
    }
    public void FireBall(int Xpos, int Ypos, int damage)
    {
        field.isDamaged[Xpos, 1] = true;
        field.damage[Xpos, 1] = damage;

        field.isDamaged[Xpos - 1, 1] = true;
        field.damage[Xpos - 1, 1] = damage;

        field.isDamaged[Xpos + 1, 1] = true;
        field.damage[Xpos + 1, 1] = damage;

        field.isDamaged[Xpos, 0] = true;
        field.damage[Xpos, 0] = damage;

        field.isDamaged[Xpos, 2] = true;
        field.damage[Xpos, 2] = damage;

        timeToAttack = false;
    }
}

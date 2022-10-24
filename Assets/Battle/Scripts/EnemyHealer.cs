using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealer : EnemyBattle
{
    
    void Start()
    {
        Xpos = gameObject.transform.position.x;
        Ypos = gameObject.transform.position.y;
        field = FindObjectOfType<Field>();
        hp = maxHP;
        hpBar = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
        if (timeToStepForward)
        {
            StepForward(-1);
        }
        if (timeToAttack && start)
        {
            MassHeal((int)Xpos, (int)Ypos, heal);
        }
        hpBar.fillAmount = hp / maxHP;
        if (timeToAction <= 0)
        {
            //Debug.Log("Лечит  " + gameObject.name);
            timeToAttack = true;
            timeToAction = startTimeToAction;
        }
        else
        {
            timeToAction -= Time.deltaTime;
        }
        if (field.isDamaged[(int)Xpos, (int)Ypos])
        {
            Debug.Log(gameObject.name + "   получил   " + field.damage[(int)Xpos, (int)Ypos] + "  урона"); //не забыть завернуть в метод
            field.isDamaged[(int)Xpos, (int)Ypos] = false;
            hp -= field.damage[(int)Xpos, (int)Ypos];
            field.damage[(int)Xpos, (int)Ypos] = 0;
            hpBar.fillAmount = hp / maxHP;
        }

        if (field.isHealed[(int)Xpos, (int)Ypos])
        {
            Debug.Log(gameObject.name + "   получил   " + field.heal[(int)Xpos, (int)Ypos] + "  исцеления"); //не забыть завернуть в метод
            field.isHealed[(int)Xpos, (int)Ypos] = false;
            hp += field.heal[(int)Xpos, (int)Ypos];
            if (hp > maxHP)
            {
                hp = maxHP;
            }
            field.heal[(int)Xpos, (int)Ypos] = 0;
            hpBar.fillAmount = hp / maxHP;
        }


    }
    public void MassHeal(int Xpos, int Ypos, int heal)
    {
        field.isHealed[Xpos, 5] = true;
        field.heal[Xpos, 5] = heal;
        field.isHealed[Xpos, 4] = true;
        field.heal[Xpos, 4] = heal;
        field.isHealed[Xpos, 3] = true;
        field.heal[Xpos, 3] = heal;

        field.isHealed[Xpos - 1, 5] = true;
        field.heal[Xpos - 1, 5] = heal;
        field.isHealed[Xpos - 1, 4] = true;
        field.heal[Xpos - 1, 4] = heal;
        field.isHealed[Xpos - 1, 3] = true;
        field.heal[Xpos - 1, 3] = heal;

        field.isHealed[Xpos + 1, 5] = true;
        field.heal[Xpos + 1, 5] = heal;
        field.isHealed[Xpos + 1, 4] = true;
        field.heal[Xpos + 1, 4] = heal;
        field.isHealed[Xpos + 1, 3] = true;
        field.heal[Xpos + 1, 3] = heal;


        timeToAttack = false;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defender : CharBattle
{
    void Start()
    {
        Xpos = gameObject.transform.position.x;
        Ypos = gameObject.transform.position.y;
        field = FindObjectOfType<Field>();
        hp = maxHP;
        hpBar = GetComponentInChildren<Image>();
    }

    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
        if (timeToStepForward)
        {
            StepForward(1);
        }
        if (timeToAttack && start)
        {
            Attack((int)Xpos, (int)Ypos, phisicalDamage);
        }
        hpBar.fillAmount = hp / maxHP;
        if (timeToAction <= 0)
        {
            //Debug.Log("јтакует  " + gameObject.name);
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
            //Debug.Log(gameObject.name + "   получил   " + field.heal[(int)Xpos, (int)Ypos] + "  исцелени€"); //не забыть завернуть в метод
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
    public void Attack(int Xpos, int Ypos, int damage)
    {
        field.isDamaged[Xpos, Ypos + 1] = true;
        field.damage[Xpos, Ypos + 1] = damage;
        field.isDamaged[Xpos - 1, Ypos + 1] = true;
        field.damage[Xpos - 1, Ypos + 1] = damage;
        field.isDamaged[Xpos + 1, Ypos + 1] = true;
        field.damage[Xpos + 1, Ypos + 1] = damage;
        timeToAttack = false;
    }
}

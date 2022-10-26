using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamager : EnemyBattle
{
    // Start is called before the first frame update
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
        if (field.isDamaged[(int)Xpos, (int)Ypos])
        {
            //Debug.Log(gameObject.name + "   получил   " + field.damage[(int)Xpos, (int)Ypos] +"  урона"); //не забыть завернуть в метод
            field.isDamaged[(int)Xpos, (int)Ypos] = false;
            hp -= field.damage[(int)Xpos, (int)Ypos];
            field.damage[(int)Xpos, (int)Ypos] = 0;
            hpBar.fillAmount = hp / maxHP;
        }
        if (field.isHealed[(int)Xpos, (int)Ypos])
        {
            Debug.Log(gameObject.name + "   получил   " + field.heal[(int)Xpos, (int)Ypos] + "  исцелени€"); //не забыть завернуть в метод
            field.isHealed[(int)Xpos, (int)Ypos] = false;
            hp += field.heal[(int)Xpos, (int)Ypos];
            if (hp > maxHP)
            {
                hp = maxHP;
            }
            field.heal[(int)Xpos, (int)Ypos] = 0;
            hpBar.fillAmount = hp / maxHP;
        }
        if (timeToStepForward)
        {
            StepForward(-1);
        }
        if (timeToAttack && start)
        {
            FireBall((int)Xpos, (int)Ypos, magicDamage);
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
    }
}

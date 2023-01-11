using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damager : CharBattle
{
    // Start is called before the first frame update
    void Start()
    {
        minWeight = 11;
        Xpos = gameObject.transform.position.x;
        Ypos = gameObject.transform.position.y;
        field = FindObjectOfType<Field>();
        hp = maxHP;
        hpBar = GetComponentInChildren<Image>();
        playerData = FindObjectOfType<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            playerData.playerArmyLimit -= minWeight;
            Die();
        }
        if (timeToStepForward)
        {
            StepForward(1);
        }
        if (timeToAttack && start)
        {
            FireBall((int)Xpos, (int)Ypos, magicDamage);
        }
        hpBar.fillAmount = hp / maxHP;
        if (timeToAction <= 0)
        {
            //Debug.Log("Атакует  " + gameObject.name);
            timeToAttack = true;
            timeToAction = startTimeToAction;
        }
        else
        {
            timeToAction -= Time.deltaTime;
        }
        if (field.isDamaged[(int)Xpos, (int)Ypos])
        {
            
            field.isDamaged[(int)Xpos, (int)Ypos] = false;
            hp -= field.damage[(int)Xpos, (int)Ypos];
            Debug.Log(gameObject.name + "   получил   " + field.damage[(int)Xpos, (int)Ypos] + "  урона и у него осталось  " + hp +" здоровья"); //не забыть завернуть в метод
            field.damage[(int)Xpos, (int)Ypos] = 0;
            hpBar.fillAmount = hp / maxHP;
        }
        if (field.isHealed[(int)Xpos, (int)Ypos])
        {
            //Debug.Log(gameObject.name + "   получил   " + field.heal[(int)Xpos, (int)Ypos] + "  исцеления"); //не забыть завернуть в метод
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
    public void FireBall(int Xpos, int Ypos, int damage)
    {
        field.isDamaged[Xpos, 4] = true;
        field.damage[Xpos, 4] = damage;

        field.isDamaged[Xpos - 1, 4] = true;
        field.damage[Xpos - 1,4] = damage;

        field.isDamaged[Xpos + 1, 4] = true;
        field.damage[Xpos + 1,4] = damage;

        field.isDamaged[Xpos, 3] = true;
        field.damage[Xpos, 3] = damage;

        field.isDamaged[Xpos, 5] = true;
        field.damage[Xpos, 5] = damage;

        timeToAttack = false;
    }
}

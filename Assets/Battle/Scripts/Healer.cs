using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healer : CharBattle
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
            Die();
            playerData.playerArmyLimit -= minWeight;
        }
        if (timeToStepForward)
        {
            StepForward(1);
        }
        if (timeToAttack && start)
        {
            MassHeal((int)Xpos, (int)Ypos, healPower);
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
        field.isHealed[Xpos, 0] = true;
        field.heal[Xpos, 0] = heal;
        field.isHealed[Xpos, 1] = true;
        field.heal[Xpos, 1] = heal;
        field.isHealed[Xpos, 2] = true;
        field.heal[Xpos, 2] = heal;

        field.isHealed[Xpos-1, 0] = true;
        field.heal[Xpos-1, 0] = heal;
        field.isHealed[Xpos - 1, 1] = true;
        field.heal[Xpos - 1, 1] = heal;
        field.isHealed[Xpos - 1, 2] = true;
        field.heal[Xpos - 1, 2] = heal;

        field.isHealed[Xpos + 1, 0] = true;
        field.heal[Xpos + 1, 0] = heal;
        field.isHealed[Xpos + 1, 1] = true;
        field.heal[Xpos + 1, 1] = heal;
        field.isHealed[Xpos + 1, 2] = true;
        field.heal[Xpos + 1, 2] = heal;


        timeToAttack = false;
    }
}

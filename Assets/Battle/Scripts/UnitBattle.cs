using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitBattle : MonoBehaviour
{
    public float maxHP;
    public float startTimeToAction;
    public int phisicalDamage;
    public bool inRage;
    public int magicDamage;
    public int magicArmor;
    public int healPower;
    public int lifeSteal;
    public int critChance;
    public int dodgeChance;
    public int phisicalArmor;







    public float hp;
    public Image hpBar;
    public float Xpos;
    public float Ypos;
    public Field field;
    public bool timeToAttack;
    public bool timeToStepForward;
    public float timeToAction;

    public PlayerData playerData;
    

    public bool start;

    void Start()
    {
        
        UpdatePosition();
        field = FindObjectOfType<Field>();
        hp = maxHP;
        hpBar = GetComponentInChildren<Image>();
    }
    
    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = hp / maxHP;
    }
    public void StepForward(float vectorMove)
    {
        gameObject.transform.position += new Vector3(0, vectorMove, 0);
        timeToStepForward = false;
        UpdatePosition();
    }
    
    public void Die()
    {
        Destroy(gameObject);
        
        Debug.Log("Somebody die");
        field.CheckSide((int)Xpos, (int)Ypos);
        field.CheckLine(1, 0, -1);
        field.CheckLine(2, 1, 0);
        field.CheckLine(3, 4, 5);
        field.CheckLine(4, 5, 6);
        //field.endOfBattle.CountOf_Army();
    }
    public void UpdatePosition()
    {
        Xpos = gameObject.transform.position.x;
        Ypos = gameObject.transform.position.y;
    }
}

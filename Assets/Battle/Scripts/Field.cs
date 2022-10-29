using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class Field : MonoBehaviour
{
    public EnemyTeamHolder enemyTeam;
    public Text enemyArmyWeightText;
    public Text playerArmyWeightText;
    public int playerArmyWeight;
    [SerializeField]
    private string nextscene = null;
    
    public bool[,] isDamaged = new bool [8,6];
    public int[,] damage = new int[8, 6];
    public bool[,] isHealed = new bool[8, 6];
    public int[,] heal = new int[8, 6];
    public EnemyHealer eHeal;
    public EnemyDamager eDam;
    public EnemyDefender eDef;
    public Defender defender;
    public Damager damager;
    public Healer healer;
    public UnitBattle[] units;

    int countOf0 = 0;
    int countOf1 = 0;
    int countOf2 = 0;
    int countOf3 = 0;
    int countOf4 = 0;
    int countOf5 = 0;

    void Start()
    {
        enemyTeam.LoadField();
        playerArmyWeight = 0;

        for (int i = 0; i < enemyTeam.enemyTeam.healers; i++)
        {
            AddUnit(5);
        }
        for (int i = 0; i < enemyTeam.enemyTeam.damagers; i++)
        {
            AddUnit(0);
        }
        for (int i = 0; i < enemyTeam.enemyTeam.defenders; i++)
        {
            AddUnit(1);
        }
        enemyArmyWeightText.text = enemyTeam.enemyTeam.enemyArmyWeight.ToString();
    }
    public void Awake()
    {
        enemyTeam = FindObjectOfType<EnemyTeamHolder>();
        enemyTeam.LoadField();
        eHeal = Resources.Load<EnemyHealer>("EnemyHealer"); //5
        eDam = Resources.Load<EnemyDamager>("EnemyDamager"); //0
        eDef = Resources.Load<EnemyDefender>("EnemyDefender"); //1
        defender = Resources.Load<Defender>("Defender"); //2
        damager = Resources.Load<Damager>("Damager"); //3
        healer = Resources.Load<Healer>("Healer"); //4        
    }

    
    public void CheckLine(int emptyLine,int lineTogo1, int lineTogo2)
    {
        float hpOnLine = 0;
        UnitBattle[] units;
        units = FindObjectsOfType<UnitBattle>();
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i].Ypos == emptyLine)
            {
                hpOnLine = hpOnLine + units[i].hp;
            }
        }
        if (hpOnLine <= 0)
        {
            for (int i = 0; i < units.Length; i++)
            {
                if (units[i].Ypos== lineTogo1|| units[i].Ypos == lineTogo2)
                {
                    units[i].timeToStepForward = true;
                }
            }
        }
    }
    public void CheckSide(int Xpos, int Ypos)
    {
        UnitBattle[] units;
        units = FindObjectsOfType<UnitBattle>();
        if (Xpos <4)
        {
            for (int i = 0; i < units.Length; i++)
            {
                if (units[i].Ypos == Ypos && units[i].Xpos < Xpos)
                {
                    units[i].transform.position += new Vector3(1, 0, 0);
                    units[i].UpdatePosition();
                }
            }
        }
        if (Xpos > 3)
        {
            for (int i = 0; i < units.Length; i++)
            {
                if (units[i].Ypos == Ypos && units[i].Xpos > Xpos)
                {
                    units[i].transform.position += new Vector3(-1, 0, 0);
                    units[i].UpdatePosition();
                }
            }
        }
    }
    public void StartBattle(bool start)
    {
        units = FindObjectsOfType<UnitBattle>();
        if (start)
        {
            for (int i = 0; i < units.Length; i++)
            {
                units[i].start = true;
            }
        }
        else
        {
            for (int i = 0; i < units.Length; i++)
            {
                units[i].hp = 0;
                countOf0 = 0;
                countOf1 = 0;
                countOf2 = 0;
                countOf3 = 0;
                countOf4 = 0;
                countOf5 = 0;
            }
        }
        
    }

    public void AddUnit(int numberOFUnit)
    {
        int x=0;
        
        if (numberOFUnit == 0 && countOf0 < 8)
        {
            switch (countOf0)
            {
                case 0: x = 3; break;
                case 1: x = 4; break;
                case 2: x = 2; break;
                case 3: x = 5; break;
                case 4: x = 1; break;
                case 5: x = 6; break;
                case 6: x = 0; break;
                case 7: x = 7; break;
            }
            EnemyDamager neweDam = Instantiate(eDam, new Vector3(x, 4, 0), eDam.transform.rotation) as EnemyDamager;
            neweDam.maxHP = Mathf.RoundToInt(neweDam.maxHP*enemyTeam.enemyTeam.enemyArmyWeight / 100);
            neweDam.magicDamage = Mathf.RoundToInt(neweDam.magicDamage*enemyTeam.enemyTeam.enemyArmyWeight / 100);
            countOf0++;
        }
        if (numberOFUnit == 1 && countOf1 < 8)
        {
            switch (countOf1)
            {
                case 0: x = 3; break;
                case 1: x = 4; break;
                case 2: x = 2; break;
                case 3: x = 5; break;
                case 4: x = 1; break;
                case 5: x = 6; break;
                case 6: x = 0; break;
                case 7: x = 7; break;
            }
            EnemyDefender neweDam = Instantiate(eDef, new Vector3(x, 3, 0), eDam.transform.rotation) as EnemyDefender;
            neweDam.maxHP = Mathf.RoundToInt(neweDam.maxHP*(enemyTeam.enemyTeam.enemyArmyWeight / 100));
            neweDam.phisicalDamage = Mathf.RoundToInt(neweDam.phisicalDamage*(enemyTeam.enemyTeam.enemyArmyWeight / 100));
            countOf1++;
        }
        if (numberOFUnit == 2 && countOf2 < 8 && (playerArmyWeight + defender.minWeight) <= enemyTeam.enemyTeam.enemyArmyWeight)
        {
            switch (countOf2)
            {
                case 0: x = 3; break;
                case 1: x = 4; break;
                case 2: x = 2; break;
                case 3: x = 5; break;
                case 4: x = 1; break;
                case 5: x = 6; break;
                case 6: x = 0; break;
                case 7: x = 7; break;
            }
            Defender neweDam = Instantiate(defender, new Vector3(x, 2, 0), eDam.transform.rotation) as Defender;
            playerArmyWeight += defender.minWeight;
            playerArmyWeightText.text = playerArmyWeight.ToString();
            countOf2++;
        }
        if (numberOFUnit == 3 && countOf3 < 8 && (playerArmyWeight + damager.minWeight) <= enemyTeam.enemyTeam.enemyArmyWeight)
        {
            switch (countOf3)
            {
                case 0: x = 3; break;
                case 1: x = 4; break;
                case 2: x = 2; break;
                case 3: x = 5; break;
                case 4: x = 1; break;
                case 5: x = 6; break;
                case 6: x = 0; break;
                case 7: x = 7; break;
            }
            Damager neweDam = Instantiate(damager, new Vector3(x, 1, 0), eDam.transform.rotation) as Damager;
            Debug.Log(damager.minWeight);
            playerArmyWeight += damager.minWeight;
            playerArmyWeightText.text = playerArmyWeight.ToString();
            countOf3++;
        }
        if (numberOFUnit == 4 && countOf4 < 8 && (playerArmyWeight + healer.minWeight) <= enemyTeam.enemyTeam.enemyArmyWeight)
        {
            switch (countOf4)
            {
                case 0: x = 3; break;
                case 1: x = 4; break;
                case 2: x = 2; break;
                case 3: x = 5; break;
                case 4: x = 1; break;
                case 5: x = 6; break;
                case 6: x = 0; break;
                case 7: x = 7; break;
            }
            Healer neweDam = Instantiate(healer, new Vector3(x, 0, 0), eDam.transform.rotation) as Healer;
            playerArmyWeight += healer.minWeight;
            playerArmyWeightText.text = playerArmyWeight.ToString();
            countOf4++;
        }
        if (numberOFUnit == 5 && countOf5 < 8)
        {
            switch (countOf5)
            {
                case 0: x = 3; break;
                case 1: x = 4; break;
                case 2: x = 2; break;
                case 3: x = 5; break;
                case 4: x = 1; break;
                case 5: x = 6; break;
                case 6: x = 0; break;
                case 7: x = 7; break;
            }
            EnemyHealer neweDam = Instantiate(eHeal, new Vector3(x, 5, 0), eDam.transform.rotation) as EnemyHealer;
            neweDam.maxHP = Mathf.RoundToInt(neweDam.maxHP*enemyTeam.enemyTeam.enemyArmyWeight / 100);
            neweDam.healPower = Mathf.RoundToInt(neweDam.healPower*enemyTeam.enemyTeam.enemyArmyWeight / 100);
            countOf5++;
        }
    }

    public void EndBattle()
    {
        SceneManager.LoadScene(nextscene);
    }
    
}

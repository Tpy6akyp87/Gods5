using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Field : MonoBehaviour
{

    [SerializeField]
    private string nextscene = null;
    
    public bool[,] isDamaged = new bool [8,6];
    public int[,] damage = new int[8, 6];
    public bool[,] isHealed = new bool[8, 6];
    public int[,] heal = new int[8, 6];
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

    void Start()
    {
        
    }
    private void Awake()
    {
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
       // Debug.Log("Check  " + emptyLine + "   line");
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i].Ypos == emptyLine)
            {
                hpOnLine = hpOnLine + units[i].hp;
            }
        }
       // Debug.Log("Здоровья на линии =  " + hpOnLine);
        if (hpOnLine <= 0)
        {
            //Debug.Log(emptyLine + "  линия пустая, шагают " + lineTogo1 + "  и  " + lineTogo2 + "  ряды");
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
            countOf1++;
        }
        if (numberOFUnit == 2 && countOf2 < 8)
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
            countOf2++;
        }
        if (numberOFUnit == 3 && countOf3 < 8)
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
            countOf3++;
        }
        if (numberOFUnit == 4 && countOf4 < 8)
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
            countOf4++;
        }
    }

    public void EndBattle()
    {
        SceneManager.LoadScene(nextscene);
    }

}

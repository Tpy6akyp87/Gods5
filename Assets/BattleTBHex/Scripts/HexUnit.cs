using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexUnit : MonoBehaviour
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

    public bool myTurn;
    public float moveDistance;
    public float speed;
    public int initative;
    public bool endMove;
    public bool canBeAttacked;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Receive_Damage(int damage)
    {
        Debug.Log(name + " Receive_Damage = "+ damage);
    }

    public void MyTurn()
    {
        HexTile[] hexTiles = FindObjectsOfType<HexTile>();
        for (int i = 0; i < hexTiles.Length; i++)
        {
            hexTiles[i].Check_OnMe();
            if (hexTiles[i].transform.position == transform.position)
                hexTiles[i].canMove = true;
            else
                hexTiles[i].canMove = false;
        }

        for (int i = 0; i < hexTiles.Length; i++)
            if ((transform.position - hexTiles[i].transform.position).magnitude > 0.5f && (transform.position - hexTiles[i].transform.position).magnitude < moveDistance && hexTiles[i].empty)
                hexTiles[i].canMoveOnMe = true;
    }
    public void Move_To(Vector3 move_to)
    {
        StartCoroutine(Move_to(move_to));
    }
    IEnumerator Move_to(Vector3 move_to)
    {
        while (transform.position != move_to)
        {
            yield return null;
            transform.position = Vector3.MoveTowards(transform.position, move_to, speed * Time.deltaTime);
        }
        HexTile[] hexTiles = FindObjectsOfType<HexTile>();
        for (int i = 0; i < hexTiles.Length; i++)
        {
            hexTiles[i].canMoveOnMe = false;
            hexTiles[i].canMove = false;
        }
        endMove = true;
    }
    public void Melee_Attack(HexUnit[] hexEnemies, Vector3 target, int damage) // хуета, надо сделать метод подсветки цели для своих и поиска цели для ИИ
    {
        HexTile[] hexTiles = FindObjectsOfType<HexTile>();
        for (int i = 0; i < hexTiles.Length; i++)
            for (int j = 0; j < hexEnemies.Length; j++)
                if (hexTiles[i].transform.position == hexEnemies[j].transform.position && (transform.position - hexTiles[i].transform.position).magnitude < 1.0f)
                    hexTiles[i].canbeAttacked = true; 
        for (int i = 0; i < hexEnemies.Length; i++)
            if (hexEnemies[i].transform.position == target)
                hexEnemies[i].Receive_Damage(damage);
    }
    public void Check_MeeleeAtack()
    {
        EnemyMover[] enemyMovers = FindObjectsOfType<EnemyMover>();
        HexTile[] hexTiles = FindObjectsOfType<HexTile>();
        for (int i = 0; i < hexTiles.Length; i++)
            for (int j = 0; j < enemyMovers.Length; j++)
                {
                    hexTiles[i].canbeAttacked = false;
                    enemyMovers[j].canBeAttacked = false;
                }
        for (int i = 0; i < hexTiles.Length; i++)
            for (int j = 0; j < enemyMovers.Length; j++)
                if (hexTiles[i].transform.position == enemyMovers[j].transform.position && (transform.position - hexTiles[i].transform.position).magnitude < 1.0f)
                {
                    hexTiles[i].canbeAttacked = true;
                    enemyMovers[j].canBeAttacked = true;
                }
    }
    public enum CharStateIs
    {
        Start,
        Move,
        Ability,
        Next
    }
}

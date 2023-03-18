using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMover : HexUnit, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public SpriteRenderer sprite;
    public Queue queue;
    public CharStateIs switcher;
    public Vector3 moveTo;
    public Vector3 target;
    public TownDataHolder townData;

    void Start()
    {
        queue = FindObjectOfType<Queue>();
        switcher = CharStateIs.Start;
    }
    void Awake()
    {
        townData = FindObjectOfType<TownDataHolder>();
        townData.Load_Town();
        for (int i = 0; i < townData.town.buildings.Count; i++)
        {
            if (townData.town.buildings[i].isBuilded)
            {
                maxHP += townData.town.buildings[i].playerEffects.maxHPEffect;
                startTimeToAction += townData.town.buildings[i].playerEffects.maxHPEffect;
                phisicalDamage += townData.town.buildings[i].playerEffects.phisicalDamageEffect;
                magicDamage += townData.town.buildings[i].playerEffects.magicDamageEffect;
                magicArmor += townData.town.buildings[i].playerEffects.magicArmorEffect;
                healPower += townData.town.buildings[i].playerEffects.healPowerEffect;
                lifeSteal += townData.town.buildings[i].playerEffects.lifeStealEffect;
                critChance += townData.town.buildings[i].playerEffects.critChanceEffect;
                dodgeChance += townData.town.buildings[i].playerEffects.dodgeChanceEffect;
                phisicalArmor += townData.town.buildings[i].playerEffects.phisicalArmorEffect;
            }
        }
    }
    void Update()
    {
        if (myTurn)
            switch (switcher)
            {
                case CharStateIs.Start:
                    {
                        //sprite.color = Color.green;
                        MyTurn();
                        Find_Target(out moveTo, out target);
                        Move_To(moveTo);
                        switcher = CharStateIs.Move;
                    }
                    break;
                case CharStateIs.Move:
                    {
                        
                        if (endMove)
                        {
                            switcher = CharStateIs.Ability;
                        }
                    }
                    break;
                case CharStateIs.Ability:
                    {
                        endMove = false;
                        Deal_Damage(target);
                        switcher = CharStateIs.Next;
                    }
                    break;
                case CharStateIs.Next:
                    {
                        if (Input.GetMouseButton(1))
                        {
                            switcher = CharStateIs.Start;
                            queue.Next_Turn();
                            sprite.color = Color.white;
                        }
                    }
                    break;
            }
    }

    public void Find_Target(out Vector3 move_to, out Vector3 target)
    {
        UnitMover tempMover;
        UnitMover[] unitMovers = FindObjectsOfType<UnitMover>();
        for (int i = 0; i < unitMovers.Length - 1; i++)
            for (int j = i+1; j < unitMovers.Length; j++)
                if ((transform.position - unitMovers[i].transform.position).magnitude > (transform.position - unitMovers[j].transform.position).magnitude)
                {
                    tempMover = unitMovers[i];
                    unitMovers[i] = unitMovers[j];
                    unitMovers[j] = tempMover;
                }
        target = unitMovers[0].transform.position;
        if ((transform.position - unitMovers[0].transform.position).magnitude > 0.9f)
        {
            HexTile[] hexTiles = FindObjectsOfType<HexTile>();
            Debug.Log(hexTiles.Length);
            List<HexTile> hexList = new List<HexTile>();
            HexTile tempHexTile;
            for (int i = 0; i < hexTiles.Length; i++)
                if (hexTiles[i].canMoveOnMe)
                    hexList.Add(hexTiles[i]);
            Debug.Log(hexList.Count);
            for (int i = 0; i < hexList.Count - 1; i++)
                for (int j = i + 1; j < hexList.Count; j++)
                    if ((unitMovers[0].transform.position - hexList[i].transform.position).magnitude > (unitMovers[0].transform.position - hexList[j].transform.position).magnitude)
                    {
                        tempHexTile = hexList[i];
                        hexList[i] = hexList[j];
                        hexList[j] = tempHexTile;
                    }
            move_to = hexList[0].transform.position;
        }
        else move_to = transform.position;
    }
    public void Deal_Damage(Vector3 target)
    {
        UnitMover[] unitMovers = FindObjectsOfType<UnitMover>();
        for (int i = 0; i < unitMovers.Length; i++)
            if (unitMovers[i].transform.position == target)
                unitMovers[i].Receive_Damage(13);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        EnemyMover[] enemyMovers = FindObjectsOfType<EnemyMover>();
        for (int i = 0; i < enemyMovers.Length; i++)
        {
            if ((transform.position - enemyMovers[i].transform.position).magnitude < 1.0f && enemyMovers[i].canBeAttacked)
            {
                enemyMovers[i].sprite.color = Color.white;
            }
        }
       // sprite.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (canBeAttacked)
        {
            EnemyMover[] enemyMovers = FindObjectsOfType<EnemyMover>();
            for (int i = 0; i < enemyMovers.Length; i++)
            {
                if ((transform.position - enemyMovers[i].transform.position).magnitude < 1.0f && enemyMovers[i].canBeAttacked)
                {
                    enemyMovers[i].sprite.color = Color.red;
                }
            }
            //sprite.color = Color.red;
        }
        else
            sprite.color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (canBeAttacked)
        {
            EnemyMover[] enemyMovers = FindObjectsOfType<EnemyMover>();
            for (int i = 0; i < enemyMovers.Length; i++)
            {
                if ((transform.position - enemyMovers[i].transform.position).magnitude < 1.0f && enemyMovers[i].canBeAttacked)
                {
                    enemyMovers[i].Receive_Damage(11);
                    enemyMovers[i].canBeAttacked = false;
                }
                enemyMovers[i].sprite.color = Color.white;
            }
            UnitMover [] unitMovers = FindObjectsOfType<UnitMover>();
            for (int i = 0; i < unitMovers.Length; i++)
            {
                if (unitMovers[i].myTurn)
                {
                    unitMovers[i].switcher = CharStateIs.Next;
                }
            }
            HexTile[] hexTiles = FindObjectsOfType<HexTile>();
            for (int i = 0; i < hexTiles.Length; i++)
            {
                hexTiles[i].canbeAttacked = false;
                hexTiles[i].canMoveOnMe = false;
                hexTiles[i].canMove = false;
            }

        }
    }

    //public enum CharStateIs
    //{
    //    Start,
    //    Move,
    //    Ability,
    //    Next
    //}
}
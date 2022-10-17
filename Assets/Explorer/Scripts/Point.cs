using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Point : MonoBehaviour
{
    public bool isVisitedPoint;
    public bool isPossibleToMove;
    public bool isExplorerOnMe;
    public bool canGoUp;
    public bool canGoDown;
    public bool canGoRight;
    public bool canGoLeft;
    public int levelOfPoint;
    public EnemyTeamHolder enemyTeam;
    public SpriteRenderer spriteRenderer;
    public Explorer explorer;
    [SerializeField]
    PointType pointType;
    void Awake()
    {
        enemyTeam = FindObjectOfType<EnemyTeamHolder>();
        explorer = FindObjectOfType<Explorer>();
        explorer.dataHolder.Load_RegionList();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        GetTypeOfPoint(transform.position.x, transform.position.y, out pointType);
        WhereExplorerCanGo();
    }
    void OnMouseDown()
    {
        if (isPossibleToMove)
        {
            explorer.nextPoint = transform.position;
            if (explorer.transform.position.x != transform.position.x || explorer.transform.position.y != transform.position.y) explorer.needToMove = true;
           // else explorer.needToMove = false;//unusable string
        }
    }
    void Update()
    {
        if (canGoDown && explorer.canGoUp && (transform.position.y - 1) == explorer.transform.position.y && transform.position.x == explorer.transform.position.x) isPossibleToMove = true;
        else if (canGoUp && explorer.canGoDown && (transform.position.y + 1) == explorer.transform.position.y && transform.position.x == explorer.transform.position.x) isPossibleToMove = true;
        else if(canGoLeft && explorer.canGoRight && transform.position.y == explorer.transform.position.y && (transform.position.x - 1) == explorer.transform.position.x) isPossibleToMove = true;
        else if(canGoRight && explorer.canGoLeft && transform.position.y == explorer.transform.position.y && (transform.position.x + 1) == explorer.transform.position.x) isPossibleToMove = true;
        else isPossibleToMove = false;
        if (isExplorerOnMe) spriteRenderer.color = Color.blue;
        else if (!isExplorerOnMe && isPossibleToMove) spriteRenderer.color = Color.green;
        else if (!isExplorerOnMe && !isPossibleToMove) spriteRenderer.color = Color.white;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < explorer.dataHolder.regionList.regionS[explorer.thisRegionID].points.Count; i++)
            {
                if (explorer.dataHolder.regionList.regionS[explorer.thisRegionID].points[i].Xpos == transform.position.x && explorer.dataHolder.regionList.regionS[explorer.thisRegionID].points[i].Ypos == transform.position.y)
                {
                    explorer.dataHolder.regionList.regionS[explorer.thisRegionID].points[i].isVisitedPoint = true;
                }
            }
            explorer.dataHolder.Save_RegionList();
            EventOnPoint();
            isExplorerOnMe = true;
            if (canGoUp)
                explorer.canGoUp = true;
            if (canGoDown)
                explorer.canGoDown = true;
            if (canGoLeft)
                explorer.canGoLeft = true;
            if (canGoRight)
                explorer.canGoRight = true;

            explorer.Save_Position(transform.position);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isExplorerOnMe = false;
        }
    }

    public void WhereExplorerCanGo()
    {
        if (isVisitedPoint && isExplorerOnMe)
        {
            explorer.needToMove = false;
        }
    }
    private void GetTypeOfPoint(float Xpos, float Ypos, out PointType pointType)
    {
        pointType = PointType.Battle;
        if (Xpos == -0.5 && Ypos == -0.5)
        {
            pointType = PointType.Start;
        }
        if (Xpos == 4.5 && Ypos == 2.5)
        {
            pointType = PointType.Final;
        }
        for (int i = 0; i < explorer.dataHolder.regionList.regionS[explorer.thisRegionID].points.Count; i++)
        {
            if (explorer.dataHolder.regionList.regionS[explorer.thisRegionID].points[i].Xpos == Xpos && explorer.dataHolder.regionList.regionS[explorer.thisRegionID].points[i].Ypos == Ypos && explorer.dataHolder.regionList.regionS[explorer.thisRegionID].points[i].isVisitedPoint)
                isVisitedPoint = true;
        }
        if (Xpos == -0.5 || Xpos == 0.5)
        {
            levelOfPoint = 0;
        }
        if (Xpos == 1.5 || Xpos == 2.5)
        {
            levelOfPoint = 1;
        }
        if (Xpos == 3.5 || Xpos == 4.5)
        {
            levelOfPoint = 2;
        }
    }
    private void EventOnPoint()
    {
        if (!isVisitedPoint)
        {
            isVisitedPoint = true;
            if (pointType == PointType.Battle)
            {
                Debug.Log(explorer.thisRegionID + "/" + levelOfPoint);
                enemyTeam.enemyTeam.enemyArmyWeight = enemyTeam.weight[explorer.thisRegionID, levelOfPoint];
                File.WriteAllText(Application.dataPath + "/Battle/enemyTeam.json", JsonUtility.ToJson(enemyTeam));
                SwitchScene("BattleScene");
            }
        }
    }
    public void SwitchScene(string nextscene)
    {
        SceneManager.LoadScene(nextscene);
    }


















}

enum PointType
{
    Start,
    Battle,
    Treasure,
    Lore,
    Final
}

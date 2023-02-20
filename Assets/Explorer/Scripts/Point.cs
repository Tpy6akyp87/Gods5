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
    public ResourseHolder resourseHolder;
    public Animator animator;

    public Point pointScript;
    public bool explmoveToMe;
    [SerializeField]
    PointType pointType;
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        enemyTeam = FindObjectOfType<EnemyTeamHolder>();
        explorer = FindObjectOfType<Explorer>();
        explorer.dataHolder.Load_RegionList();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.color = Color.red;
        GetTypeOfPoint(transform.position.x, transform.position.y, out pointType);
        if (pointType == PointType.Treasure)
        {
            animator.SetInteger("State",1);
            //spriteRenderer.sprite = Resources.Load("Assets/Explorer/Images/treasure.png") as Sprite;
        }
        if (pointType == PointType.Lore)
        {
            animator.SetInteger("State", 2);
            //spriteRenderer.sprite = Resources.Load("Assets/Explorer/Images/treasure.png") as Sprite;
        }
        if (pointType == PointType.Exp)
        {
            animator.SetInteger("State", 3);
            //spriteRenderer.sprite = Resources.Load("Assets/Explorer/Images/treasure.png") as Sprite;
        }
        //spriteRenderer.sprite = Resources.Load("Assets/Resources/Sprites/battlePoint/battlePoint1.png") as Sprite;
        WhereExplorerCanGo();
    }
    private void Start()
    {
        Check_PointPosition();
        resourseHolder = FindObjectOfType<ResourseHolder>();
    }
    void OnMouseDown()
    {
        if (isPossibleToMove)
        {
            explmoveToMe = true;
            explorer.nextPoint = transform.position;
            if (explorer.transform.position.x != transform.position.x || explorer.transform.position.y != transform.position.y) explorer.needToMove = true;
        }
    }
    void Update()
    {
        //spriteRenderer.sprite = Resources.Load("Assets/Resources/Sprites/battlePoint/battlePoint1.png") as Sprite;
        if (explmoveToMe)
        {
            if (explorer.transform.position == transform.position)
            {
                explmoveToMe = false;
                explorer.needToMove = false;
            }     
        }

        if (canGoDown && explorer.canGoUp && (transform.position.y - 1) == explorer.transform.position.y && transform.position.x == explorer.transform.position.x) isPossibleToMove = true;
        else if (canGoUp && explorer.canGoDown && (transform.position.y + 1) == explorer.transform.position.y && transform.position.x == explorer.transform.position.x) isPossibleToMove = true;
        else if (canGoLeft && explorer.canGoRight && transform.position.y == explorer.transform.position.y && (transform.position.x - 1) == explorer.transform.position.x) isPossibleToMove = true;
        else if (canGoRight && explorer.canGoLeft && transform.position.y == explorer.transform.position.y && (transform.position.x + 1) == explorer.transform.position.x) isPossibleToMove = true;
        else isPossibleToMove = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            explorer.textLog.text += "collision";
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
            //explorer.Save_Position(transform.position);
            if (canGoUp)
                explorer.canGoUp = true;
            else explorer.canGoUp = false;
            if (canGoDown)
                explorer.canGoDown = true;
            else explorer.canGoDown = false;
            if (canGoLeft)
                explorer.canGoLeft = true;
            else explorer.canGoLeft = false;
            if (canGoRight)
                explorer.canGoRight = true;
            else explorer.canGoRight = false;

            explorer.textLog.text += canGoUp.ToString() + canGoDown.ToString() + canGoLeft.ToString() + canGoRight.ToString();
            explorer.textLog.text += " / ";
            explorer.textLog.text += explorer.canGoUp.ToString() + explorer.canGoDown.ToString() + explorer.canGoLeft.ToString() + explorer.canGoRight.ToString();

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
        //Debug.Log(" GetTypeOfPoint ");
        pointType = PointType.Battle;
        int rnd = Random.Range(0, 100);
        if (rnd <15)
        {
            pointType = PointType.Treasure;
        }
        if (rnd >= 15 && rnd < 30)
        {
            pointType = PointType.Lore;
        }
        if (rnd >= 30 && rnd < 50)
        {
            pointType = PointType.Exp;
        }
        if (rnd >= 50)
        {
            pointType = PointType.Battle;
        }
        if (Xpos == -0.5 && Ypos == -0.5)
        {
            pointType = PointType.Start;
        }
        if (Xpos == 4.5 && Ypos == 2.5)
        {
            pointType = PointType.Final;
        }

        //Debug.Log("points count  " + explorer.dataHolder.regionList.regionS[explorer.thisRegionID].points.Count);
        for (int i = 0; i < explorer.dataHolder.regionList.regionS[explorer.thisRegionID].points.Count; i++)
        {
            if (explorer.dataHolder.regionList.regionS[explorer.thisRegionID].points[i].Xpos == Xpos && explorer.dataHolder.regionList.regionS[explorer.thisRegionID].points[i].Ypos == Ypos && explorer.dataHolder.regionList.regionS[explorer.thisRegionID].points[i].isVisitedPoint)
            {
                isVisitedPoint = true; 
            }
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
        explorer.textLog.text += " EventOnPoint ";
        Debug.Log(" EventOnPoint " + isVisitedPoint);
        int healMinWeight = 11;
        int damagerMinWeight = 11;
        int defenderMinWeight = 7;
        //GetTypeOfPoint(transform.position.x, transform.position.y, out pointType);
        if (!isVisitedPoint)
        {
            explorer.textLog.text += " isVisitedPoint " + isVisitedPoint.ToString();
            isVisitedPoint = true;
            explorer.textLog.text += " if " + pointType.ToString() + PointType.Battle.ToString();
            if (pointType == PointType.Battle)
            {
                explorer.textLog.text += "1 SwSc";
                enemyTeam.enemyArmyWeight = enemyTeam.weight[explorer.thisRegionID, levelOfPoint];
                explorer.textLog.text += "2 SwSc";
                enemyTeam.healers = Random.Range(2, 5);
                explorer.textLog.text += "3 SwSc";
                enemyTeam.damagers = Random.Range(2, Mathf.FloorToInt((100 - enemyTeam.healers * healMinWeight) / damagerMinWeight));
                explorer.textLog.text += "4 SwSc";
                enemyTeam.defenders = Mathf.FloorToInt((100 - enemyTeam.healers * healMinWeight - enemyTeam.damagers * damagerMinWeight) / defenderMinWeight); 
                explorer.textLog.text += "5 SwSc";
                enemyTeam.Save_EnemyTeam();
                explorer.textLog.text += "6 SwSc";
                SwitchScene("BattleScene");
            }
            if (pointType == PointType.Treasure)
            {
                resourseHolder.Get_Resourses(Random.Range(100, 300));
                Debug.Log("gain Random Res ");
            }
            if (pointType == PointType.Lore)
            {
                Debug.Log(" упил мужик шл€пу, а она ему как раз");
            }
            if (pointType == PointType.Exp)
            {
                int exp = Random.Range(30, 70);
                Debug.Log("gain exp = " + exp);
                resourseHolder.resources.exp += exp;
            }
            if (pointType == PointType.Final)
            {
                SwitchScene("World");
            }
        }
    }
    public void SwitchScene(string nextscene)
    {
        explorer.textLog.text += " SwitchScene " + nextscene;
        SceneManager.LoadScene(nextscene);
    }
    public void Check_PointPosition()
    {
        if (canGoDown && explorer.canGoUp && (transform.position.y - 1) == explorer.transform.position.y && transform.position.x == explorer.transform.position.x) isPossibleToMove = true;
        else if (canGoUp && explorer.canGoDown && (transform.position.y + 1) == explorer.transform.position.y && transform.position.x == explorer.transform.position.x) isPossibleToMove = true;
        else if (canGoLeft && explorer.canGoRight && transform.position.y == explorer.transform.position.y && (transform.position.x - 1) == explorer.transform.position.x) isPossibleToMove = true;
        else if (canGoRight && explorer.canGoLeft && transform.position.y == explorer.transform.position.y && (transform.position.x + 1) == explorer.transform.position.x) isPossibleToMove = true;
        else isPossibleToMove = false;
        if (isExplorerOnMe) spriteRenderer.color = Color.blue;
        else if (!isExplorerOnMe && isPossibleToMove) spriteRenderer.color = Color.green;
        else if (!isExplorerOnMe && !isPossibleToMove) spriteRenderer.color = Color.white;
    }

    
}


enum PointType
{
    Start,
    Battle,
    Treasure,
    Exp,
    Lore,
    Final
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Point : MonoBehaviour
{
    public float Xpos;
    public float Ypos;
    public bool isVisitedPoint;
    public bool isPossibleToMove;
    public bool isExplorerOnMe;
    public bool canGoUp;
    public bool canGoDown;
    public bool canGoRight;
    public bool canGoLeft;
    public int levelOfPoint;

    public Explorer explorer;
    PointType pointType;


    void Start()
    {
        explorer = FindObjectOfType<Explorer>();
        pointType = PointType.Battle;//временно, потом заполнить через рандомное распределение
        if (Xpos == -0.5 && Ypos == -0.5)
        {
            pointType = PointType.Start;
        }
        if (Xpos == 4.5 && Ypos == 2.5)
        {
            pointType = PointType.Final;
        }
    }
    void OnMouseDown()
    {
        if (isPossibleToMove)
        {
            explorer.nextPoint = transform.position;
            if (explorer.transform.position.x != transform.position.x || explorer.transform.position.y != transform.position.y) explorer.needToMove = true;
            else explorer.needToMove = false;
        }
    }
    void Update()
    {
        if (explorer.transform.position.x == transform.position.x && explorer.transform.position.y == transform.position.y)
        {
            isExplorerOnMe = true;
            if (canGoUp)
                explorer.canGoUp = true;
            if (canGoDown)
                explorer.canGoDown = true;
            if (canGoLeft)
                explorer.canGoLeft = true;
            if (canGoRight)
                explorer.canGoRight = true;
        }
        else
        {
            isExplorerOnMe = false;
        }
    }
















    //public StartEnemyTeam enemyTeam;

    //public Text text;
    //public GameObject toBattle;

    //public bool isVisited;
    //public bool started;

    //[SerializeField]
    //private string nextscene = null;
    //public Explorer explorer;

    //public int healCount;
    //public int damagerCount;
    //public int defenderCount;

    //void OnMouseDown()
    //{
    //    Debug.Log("клик");
    //    explorer.needToMove = true;
    //    explorer.poointToMove = transform.position;
    //}
    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player" && !isVisited && started)
    //    {
    //        //explorer.needToMove = false;
    //        Debug.Log("Вашол");
    //        isVisited = true;
    //        Debug.Log(transform.position + "  вот тут был  " + isVisited);
    //        Debug.Log("battle loading");
    //        explorer.SaveField();
    //        //toBattle.SetActive(true);
    //        SaveField();
    //        SceneManager.LoadScene(nextscene);
    //    }
    //}
    //void Start()
    //{
    //    //toBattle.SetActive(false);
    //    explorer = FindObjectOfType<Explorer>();

    //    healCount = (int)Random.Range(2, 5);
    //    damagerCount = (int)Random.Range(2, 5);
    //    defenderCount = (int)Random.Range(2, 5);
    //}

    //public void LoadPoint()
    //{
    //    Debug.Log("Стартуем");
    //    explorer = FindObjectOfType<Explorer>();
    //    for (int i = 0; i < explorer.pointToSave.points.Count; i++)
    //    {
    //        //text.text += "*";
    //        Debug.Log("ТУТ  " + transform.position + "ТУТ  " + explorer.pointToSave.points[i]);
    //        if ((explorer.pointToSave.points[i] - transform.position).magnitude < 0.1)
    //        {
    //            isVisited = true;
    //        }
    //    }
    //    started = true;
    //}
    //public void SwitchScene(string nextscene)
    //{
    //    SceneManager.LoadScene(nextscene);
    //}
    //[System.Serializable]
    //public class StartEnemyTeam
    //{
    //    public int healers;
    //    public int damagers;
    //    public int defenders;
    //}
    //public void SaveField()
    //{
    //    enemyTeam.healers = healCount;
    //    enemyTeam.damagers = damagerCount;
    //    enemyTeam.defenders = defenderCount;
    //    File.WriteAllText(Application.dataPath + "/Battle/enemyTeam.json", JsonUtility.ToJson(enemyTeam));
    //}
}

enum PointType
{
    Start,
    Battle,
    Treasure,
    Lore,
    Final
}

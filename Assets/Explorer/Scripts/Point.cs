using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Point : MonoBehaviour
{
    public StartEnemyTeam enemyTeam;

    public Text text;
    public GameObject toBattle;

    public bool isVisited;
    public bool started;

    [SerializeField]
    private string nextscene = null;
    public Explorer explorer;

    public int healCount;
    public int damagerCount;
    public int defenderCount;

    void OnMouseDown()
    {
        Debug.Log("клик");
        explorer.needToMove = true;
        explorer.poointToMove = transform.position;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isVisited && started)
        {
            //explorer.needToMove = false;
            Debug.Log("Вашол");
            isVisited = true;
            Debug.Log(transform.position + "  вот тут был  " + isVisited);
            Debug.Log("battle loading");
            explorer.SaveField();
            //toBattle.SetActive(true);
            SaveField();
            SceneManager.LoadScene(nextscene);
        }
    }
    void Start()
    {
        //toBattle.SetActive(false);
        explorer = FindObjectOfType<Explorer>();

        healCount = (int)Random.Range(2, 5);
        damagerCount = (int)Random.Range(2, 5);
        defenderCount = (int)Random.Range(2, 5);
    }

    public void LoadPoint()
    {
        Debug.Log("Стартуем");
        explorer = FindObjectOfType<Explorer>();
        for (int i = 0; i < explorer.pointToSave.points.Count; i++)
        {
            //text.text += "*";
            Debug.Log("ТУТ  " + transform.position + "ТУТ  " + explorer.pointToSave.points[i]);
            if ((explorer.pointToSave.points[i] - transform.position).magnitude < 0.1)
            {
                isVisited = true;
            }
        }
        started = true;
    }
    public void SwitchScene(string nextscene)
    {
        SceneManager.LoadScene(nextscene);
    }
    [System.Serializable]
    public class StartEnemyTeam
    {
        public int healers;
        public int damagers;
        public int defenders;
    }
    public void SaveField()
    {
        enemyTeam.healers = healCount;
        enemyTeam.damagers = damagerCount;
        enemyTeam.defenders = defenderCount;
        File.WriteAllText(Application.dataPath + "/Battle/enemyTeam.json", JsonUtility.ToJson(enemyTeam));
    }
}

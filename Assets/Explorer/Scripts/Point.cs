using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Point : MonoBehaviour
{
    public Text text;
    public GameObject toBattle;

    public bool isVisited;
    public bool started;

    [SerializeField]
    private string nextscene = null;
    public Explorer explorer;

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
            toBattle.SetActive(true);
            SceneManager.LoadScene(nextscene);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        toBattle.SetActive(false);
        explorer = FindObjectOfType<Explorer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        //explorer = FindObjectOfType<Explorer>();
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
}

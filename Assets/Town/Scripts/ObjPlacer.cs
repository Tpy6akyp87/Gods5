using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjPlacer : MonoBehaviour
{
    public bool isDraging = false;
    public Vector3 startPos;
    public bool canBeBuilded;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (isDraging)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition);
        }
    }
    void OnMouseDown()
    {
        isDraging = true;
    }
    void OnMouseUp()
    {
        isDraging = false;
        if (!isDraging && canBeBuilded)
        {
            CheckPlace();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Field")
        {
            canBeBuilded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Field")
        {
            canBeBuilded = false;
        }
    }
    public void CheckPlace()
    {
        ObjPlacer[] buildings;
        buildings = FindObjectsOfType<ObjPlacer>();
        for (int i = 0; i < buildings.Length; i++)
        {
            if ((transform.position - buildings[i].transform.position).magnitude < 0.1 && buildings[i] != this)
            {
                transform.position = startPos;
                break;
            }
            else
            {
                transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 10.0f);
            }
        }
    }
    
}

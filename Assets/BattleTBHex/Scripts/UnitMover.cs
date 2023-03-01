using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitMover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool myTurn;
    public float moveDistance;
    public float speed;
    public int initative;
    public SpriteRenderer sprite;
    public Queue queue;

    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        queue = FindObjectOfType<Queue>();
    }

    public void MyTurn()
    {
        Debug.Log("MyTurn");
        HexTile[] hexTiles = FindObjectsOfType<HexTile>();
        Debug.Log(hexTiles.Length);
        for (int i = 0; i < hexTiles.Length; i++)
        {
            //hexTiles[i].sprite.color = Color.white;
            hexTiles[i].Check_OnMe();
        }

        for (int i = 0; i < hexTiles.Length; i++)
        {
            if ((transform.position - hexTiles[i].transform.position).magnitude > 0.5f && (transform.position - hexTiles[i].transform.position).magnitude < moveDistance && hexTiles[i].empty)
            {
                //hexTiles[i].sprite.color = Color.gray;
                hexTiles[i].canMoveOnMe = true;
            }
        }
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
            hexTiles[i].canMoveOnMe = false;
        queue.Next_Turn();
    }
    void Update()
    {
        if (myTurn) sprite.color = Color.green;
        //else sprite.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        sprite.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
        sprite.color = Color.blue;
    }
}

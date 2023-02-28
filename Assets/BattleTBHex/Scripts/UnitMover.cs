using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMover : MonoBehaviour
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

    [ContextMenu("MyTurn_Test")]
    public void MyTurn_Test()
    {
        Debug.Log("MyTurn_Test");
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
        else sprite.color = Color.white;
    }

}

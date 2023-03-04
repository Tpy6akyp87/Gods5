using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexUnit : MonoBehaviour
{
    public bool myTurn;
    public float moveDistance;
    public float speed;
    public int initative;
    public bool endMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Receive_Damage()
    {
        Debug.Log(name + " Receive_Damage ");
    }
    public void MyTurn()
    {
        HexTile[] hexTiles = FindObjectsOfType<HexTile>();
        for (int i = 0; i < hexTiles.Length; i++)
            hexTiles[i].Check_OnMe();

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
            hexTiles[i].canMoveOnMe = false;
        endMove = true;
    }
}

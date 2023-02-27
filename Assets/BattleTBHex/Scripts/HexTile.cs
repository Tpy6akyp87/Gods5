using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{
    public bool empty;
    public bool unitOnMe;
    public bool canMoveOnMe;
    public SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
    }
}

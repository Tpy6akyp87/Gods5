using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitMover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool myTurn;
    public float moveDistance;
    public float speed;
    public int initative;
    public SpriteRenderer sprite;
    public Queue queue;
    public CharStateIs switcher;
    public Vector3 moveTo;

    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        queue = FindObjectOfType<Queue>();
        switcher = CharStateIs.Start;
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
        switcher = CharStateIs.Ability;
        //queue.Next_Turn();
    }
    void Update()
    {
        if (myTurn)
            switch (switcher)
            {
                case CharStateIs.Start:
                    {
                        sprite.color = Color.green;
                        MyTurn();
                        switcher = CharStateIs.Move;
                    }
                    break;
                case CharStateIs.Move:
                    {
                        if (Input.GetMouseButton(0))
                        {
                            Move_To(moveTo);
                        }
                    }
                    break;
                case CharStateIs.Ability:
                    {
                        if (Input.GetMouseButton(0))
                        {
                            switcher = CharStateIs.Next;
                        }
                    }
                    break;
                case CharStateIs.Next:
                    {
                        if (Input.GetMouseButton(1))
                        {
                            switcher = CharStateIs.Start;
                            queue.Next_Turn();
                        }
                    }
                    break;
            }
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (myTurn)
        {
            Debug.Log("Healed");
        }
        else
        {
            Debug.Log("Damaged");
        }
    }

    public enum CharStateIs
    {
        Start,
        Move,
        Ability,
        Next
    }
}

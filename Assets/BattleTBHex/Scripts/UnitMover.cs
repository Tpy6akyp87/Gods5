using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitMover : HexUnit, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    
    public SpriteRenderer sprite;
    public Queue queue;
    public CharStateIs switcher;
    public Vector3 moveTo;

    void Start()
    {
        queue = FindObjectOfType<Queue>();
        switcher = CharStateIs.Start;
    }

    
    
    void Update()
    {
        if (myTurn)
            switch (switcher)
            {
                case CharStateIs.Start:
                    {
                        //sprite.color = Color.green;
                        MyTurn();
                        switcher = CharStateIs.Move;
                    }
                    break;
                case CharStateIs.Move:
                    {
                        Check_MeeleeAtack();
                        if (Input.GetMouseButton(0) && moveTo != new Vector3(100,100,100))
                        {
                            Move_To(moveTo);
                        }
                        if (endMove)
                        {
                            switcher = CharStateIs.Ability;
                        }
                    }
                    break;
                case CharStateIs.Ability:
                    {
                        endMove = false;
                        Check_MeeleeAtack();
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
                            sprite.color = Color.white;
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

    
}

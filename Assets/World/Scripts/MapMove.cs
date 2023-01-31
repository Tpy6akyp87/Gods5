using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapMove : MonoBehaviour
{
    public Vector3 Origin;
    public Vector3 Difference;
    public Vector3 ResetCamera;

    public bool drag = false;



    private void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }

    private void Update()
    {
       
    }
    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (drag == false)
            {
                drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

        }
        else
        {
            drag = false;
        }

        if (drag)
        {
            Camera.main.transform.position = Origin - Difference * 0.5f;
        }

        if (Input.GetMouseButton(1))
            Camera.main.transform.position = ResetCamera;

    }
}

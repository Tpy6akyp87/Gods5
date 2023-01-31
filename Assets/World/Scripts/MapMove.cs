using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapMove : MonoBehaviour
{
    public bool isDraging;
    public Vector3 usePosition;
    public Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(2.54f, 1.7f, 0.0f);
        newPosition = transform.position;
    }

    // Update is called once per frame
   
    void Update()
    {
        Vector3 myMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        usePosition = new Vector3(Camera.main.ScreenToWorldPoint(myMousePosition).x, Camera.main.ScreenToWorldPoint(myMousePosition).y, 0.0f);
        if (isDraging)
        {
            //Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            
            
            newPosition = new Vector3(transform.position.x, transform.position.y, 0.0f);
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(myMousePosition).x + newPosition.x, Camera.main.ScreenToWorldPoint(myMousePosition).y + newPosition.y, 0.0f) ;
        }
    }
    void OnMouseDown()
    {
        isDraging = true;
    }
    void OnMouseUp()
    {
        isDraging = false;        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScr : MonoBehaviour
{
    public float xUP;
    public float xDOWN;
    public float yUP;
    public float yDOWN;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < xDOWN) transform.position = new Vector3(xDOWN, transform.position.y, transform.position.z);
        if (transform.position.x > xUP) transform.position = new Vector3(xUP, transform.position.y, transform.position.z);
        if (transform.position.y < yDOWN) transform.position = new Vector3(transform.position.x, yDOWN, transform.position.z);
        if (transform.position.y > yUP) transform.position = new Vector3(transform.position.x, yUP, transform.position.z);
    }
}

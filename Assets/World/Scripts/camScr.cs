using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 1.478423f) transform.position = new Vector3(1.478423f, transform.position.y, transform.position.z);
        if (transform.position.x > 7.074637) transform.position = new Vector3(7.074637f, transform.position.y, transform.position.z);
        if (transform.position.y < -0.8268458f) transform.position = new Vector3(transform.position.x, -0.8268458f, transform.position.z);
        if (transform.position.y > 2.573785f) transform.position = new Vector3(transform.position.x, 2.573785f, transform.position.z);
    }
}

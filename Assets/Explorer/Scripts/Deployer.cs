using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deployer : MonoBehaviour
{
    public Point point;
    public Explorer explorer;
    private bool timeToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeToLoad)
        {
            Point newePoint0 = Instantiate(point, new Vector3(1.3f, 0.8f, 0), point.transform.rotation) as Point;
            Point newePoint1 = Instantiate(point, new Vector3(5.2f, 2.3f, 0), point.transform.rotation) as Point;
            Point newePoint2 = Instantiate(point, new Vector3(-3.5f, 2.8f, 0), point.transform.rotation) as Point;
            Point newePoint3 = Instantiate(point, new Vector3(-1.9f, -2.8f, 0), point.transform.rotation) as Point;
            Explorer newePoint = Instantiate(explorer, new Vector3(-7.0f, -3.0f, 0), explorer.transform.rotation) as Explorer;
            timeToLoad = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGen : MonoBehaviour
{
    public GameObject playerStart;
    public GameObject chunk1;
    public GameObject chunk2;
    public GameObject EnemyStart;
    public Queue queue;
    // Start is called before the first frame update
    void Start()
    {
        playerStart = Resources.Load<GameObject>("PlayerStart");
        chunk1 = Resources.Load<GameObject>("1Chunk");
        chunk2 = Resources.Load<GameObject>("2Chunk");
        EnemyStart = Resources.Load<GameObject>("EnemyStart");

        GameObject newPlayerStart = Instantiate(playerStart, new Vector3(0f, 0f, 0f), playerStart.transform.rotation) as GameObject;
        GameObject newchunk1 = Instantiate(chunk1, new Vector3(0f, 0f, 0f), chunk1.transform.rotation) as GameObject;
        GameObject newchunk2 = Instantiate(chunk2, new Vector3(0f, 0f, 0f), chunk2.transform.rotation) as GameObject;
        GameObject newEnemyStart = Instantiate(EnemyStart, new Vector3(0f, 0f, 0f), EnemyStart.transform.rotation) as GameObject;
        queue = FindObjectOfType<Queue>();
        queue.MyStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

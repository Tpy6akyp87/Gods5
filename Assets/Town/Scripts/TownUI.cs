using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownUI : MonoBehaviour
{
    public TownDataHolder townData;
    // Start is called before the first frame update
    void Start()
    {
        townData = FindObjectOfType<TownDataHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchScene(string nextscene)
    {
        townData.Save_Town();
        SceneManager.LoadScene(nextscene);
    }
}

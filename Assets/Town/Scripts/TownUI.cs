using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TownUI : MonoBehaviour
{
    public TownDataHolder townData;

    public Text tname;
    public Text tisBiulded;
    public Text tlevel;
    public Text tcoastStone;
    public Text tcoastWood;
    public Text tcoastClay;
    public Text tcoastFiber;
    public Text tcoastIron;
    public Text tcoastCharcoal;
    public Text tcoastCloth;
    public Text tcoastSkystone;
    public Text tcoastFirestone;
    void Start()
    {
        townData = FindObjectOfType<TownDataHolder>();
    }

    public void Get_TownInfo(string name, bool isBuilded, int level, int coastStone, int coastWood, int coastClay, int coastFiber, int coastIron, int coastCharcoal, int coastCloth, int coastSkystone, int coastFirestone)
    {
        tname.text = name.ToString();
        if (isBuilded) tisBiulded.text = "Builded";
        else tisBiulded.text = "Not Builded";
        tlevel.text = level.ToString();
        tcoastStone.text = coastStone.ToString();
        tcoastWood.text = coastWood.ToString();
        tcoastClay.text = coastClay.ToString();
        tcoastFiber.text = coastFiber.ToString();
        tcoastIron.text = coastIron.ToString();
        tcoastCharcoal.text = coastCharcoal.ToString();
        tcoastCloth.text = coastCloth.ToString();
        tcoastSkystone.text = coastSkystone.ToString();
        tcoastFirestone.text = coastFirestone.ToString();
    }

    public void SwitchScene(string nextscene)
    {
        townData.Save_Town();
        SceneManager.LoadScene(nextscene);
    }
}

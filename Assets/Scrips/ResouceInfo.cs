using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResouceInfo : MonoBehaviour
{
    public Text tstone;
    public Text twood;
    public Text tclay;
    public Text tfiber;
    public Text tiron;
    public Text tcharcoal;
    public Text tcloth;
    public Text tskystone;
    public Text twfirestoneood;
    // Start is called before the first frame update
    
    public void GetResouces_Info(int stone,int wood, int clay, int fiber, int iron, int charcoal, int cloth, int skystone,int firestone)
    {
        tstone.text = "Stone = " + stone.ToString();
        twood.text = "Wood = " + wood.ToString();
        tclay.text = "Clay = " + clay.ToString();
        tfiber.text = "Fiber = " + fiber.ToString();
        tiron.text = "Iron = " + iron.ToString();
        tcharcoal.text = "Charcoal = " + charcoal.ToString();
        tcloth.text = "Cloth = " + cloth.ToString();
        tskystone.text = "Skystone = " + skystone.ToString();
        twfirestoneood.text = "Firestone = " + firestone.ToString();
}
}

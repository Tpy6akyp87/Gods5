using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class EnemyTeamHolder : MonoBehaviour
{
    public int[,] weight = new int[10, 3] { { 100, 110, 121 },{ 110, 121, 133 }, { 121, 133, 146 }, { 133, 146, 161 }, { 146, 161, 177 }, { 161, 177, 195 }, { 177, 195, 214 }, { 195, 214, 236 }, { 214, 236, 259 }, { 236, 259, 285 } };
    public StartEnemyTeam enemyTeam;
    [System.Serializable]
    public class StartEnemyTeam
    {
        public int enemyArmyWeight;
        public int healers;
        public int damagers;
        public int defenders;
    }

    public void LoadField()
    {
        enemyTeam = JsonUtility.FromJson<StartEnemyTeam>(File.ReadAllText(Application.dataPath + "/Battle/enemyTeam.json"));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

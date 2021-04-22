using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplystats : MonoBehaviour
{
    public stats enemyStats;
    // Start is called before the first frame update
    void Start()
    {
        


        enemyStats.hp = enemyStats.hp * PlayerPrefs.GetInt("globallvl");
        enemyStats.maxhp = enemyStats.maxhp * PlayerPrefs.GetInt("globallvl");
        enemyStats.att = enemyStats.att * PlayerPrefs.GetInt("globallvl");
        enemyStats.armor = enemyStats.armor * PlayerPrefs.GetInt("globallvl");
        enemyStats.critmod = enemyStats.critmod * PlayerPrefs.GetInt("globallvl");
        enemyStats.agi = enemyStats.agi * PlayerPrefs.GetInt("globallvl");
        enemyStats.maxap = enemyStats.maxap * PlayerPrefs.GetInt("globallvl");

    }

   
}

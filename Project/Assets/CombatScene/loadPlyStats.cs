using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadPlyStats : MonoBehaviour
{
    public stats plyStats;
    public plyAttacks plyAtt;
    // Start is called before the first frame update
    void Start()
    {
        plyStats.acc = PlayerPrefs.GetInt("plyacc");
        plyStats.hp = PlayerPrefs.GetInt("plyhp");
        plyStats.maxhp = PlayerPrefs.GetInt("plymaxhp");
        plyStats.att = PlayerPrefs.GetInt("plyatt");
        plyStats.armor = PlayerPrefs.GetInt("plydef");
        plyStats.critmod = PlayerPrefs.GetInt("plycrit");
        plyStats.agi = PlayerPrefs.GetInt("plyacc");
        plyStats.maxap = PlayerPrefs.GetInt("plyagi");
        plyStats.currentap = plyStats.maxap;
        plyStats.coin = PlayerPrefs.GetInt("plycoin");
        plyAtt.ammo = PlayerPrefs.GetInt("plyammo");
     

    }

   
}

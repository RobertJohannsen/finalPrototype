using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyButton : MonoBehaviour
{
    public shopGUICore sgc;
    // Start is called before the first frame update

    public void Buy1()
    {
       
        PlayerPrefs.SetInt("plycoin", PlayerPrefs.GetInt("plycoin") - sgc.cost[0]);
        applyStats(0);
        Debug.Log("boughtstuff");

        
    }

    public void Buy2()
    {
        PlayerPrefs.SetInt("plycoin", PlayerPrefs.GetInt("plycoin") - sgc.cost[0]);
        applyStats(1);
        Debug.Log("boughtstuff");
    }

    public void Buy3()
    {
        PlayerPrefs.SetInt("plycoin", PlayerPrefs.GetInt("plycoin") - sgc.cost[0]);
        applyStats(2);
        Debug.Log("boughtstuff");
    }

    void applyStats(int index)
    {
       

        PlayerPrefs.SetInt("plyhp", PlayerPrefs.GetInt("plyhp") + sgc.lv[index].hp);
        PlayerPrefs.SetInt("plyammo", PlayerPrefs.GetInt("plyammo") + sgc.lv[index].ammo);
        PlayerPrefs.SetInt("plymaxhp", PlayerPrefs.GetInt("plymaxhp") + sgc.lv[index].maxhp);
        PlayerPrefs.SetInt("plyatt", PlayerPrefs.GetInt("plyatt") + sgc.lv[index].att);
        PlayerPrefs.SetInt("plydef", PlayerPrefs.GetInt("plydef") + sgc.lv[index].def);
        PlayerPrefs.SetInt("plycrit", PlayerPrefs.GetInt("plycrit") + sgc.lv[index].critmod);
        PlayerPrefs.SetInt("plyacc", PlayerPrefs.GetInt("plyhpacc") + sgc.lv[index].acc);
        PlayerPrefs.SetInt("plyagi", PlayerPrefs.GetInt("plyagi") + sgc.lv[index].agi);
        


    }

    public void closeShop()
    {
      //  sgc.lvlcore.fakeDone = true;
        sgc.shopDone = true;

    }
}

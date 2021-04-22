using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeButton : MonoBehaviour
{
    public freeGUICore fgc;
    // Start is called before the first frame update

    public void free1()
    {

     
        applyStats(0);
        Debug.Log("mrbeast");
        fgc.freeDone = true;


    }

    public void free2()
    {
       
        applyStats(1);
        Debug.Log("mrbeast");
        fgc.freeDone = true;
    }

    public void free3()
    {
       
        applyStats(2);
        Debug.Log("mrbeast");
        fgc.freeDone = true;
    }

    void applyStats(int index)
    {


        PlayerPrefs.SetInt("plyhp", PlayerPrefs.GetInt("plyhp") + fgc.lv[index].hp);
        PlayerPrefs.SetInt("plyammo", PlayerPrefs.GetInt("plyammo") + fgc.lv[index].ammo);
        PlayerPrefs.SetInt("plymaxhp", PlayerPrefs.GetInt("plymaxhp") + fgc.lv[index].maxhp);
        PlayerPrefs.SetInt("plyatt", PlayerPrefs.GetInt("plyatt") + fgc.lv[index].att);
        PlayerPrefs.SetInt("plydef", PlayerPrefs.GetInt("plydef") + fgc.lv[index].def);
        PlayerPrefs.SetInt("plycrit", PlayerPrefs.GetInt("plycrit") + fgc.lv[index].critmod);
        PlayerPrefs.SetInt("plyacc", PlayerPrefs.GetInt("plyhpacc") + fgc.lv[index].acc);
        PlayerPrefs.SetInt("plyagi", PlayerPrefs.GetInt("plyagi") + fgc.lv[index].agi);



    }

    public void closefree()
    {
      //  fgc.lvlcore.fakeDone = true;
        fgc.freeDone = true;

    }
}

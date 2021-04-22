using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class KeepTrashScript : MonoBehaviour
{
    public combatLoop cLoop;
    public GameObject lootSpw;

    public List<GameObject> drops = new List<GameObject>();
    public bool DebounceLootLoad;
    public Canvas lootCanv;
    public TextMeshProUGUI lootGUI;
    public int lootIndex;
    public string lootStrg;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cLoop.lvlDone)
        {
            if(!DebounceLootLoad)
            {
                
                DebounceLootLoad = true;
                lootIndex = 0;
                
            }

            lootIndex = Mathf.Clamp(lootIndex, 0, lootSpw.transform.childCount-1);

            LoadLootGUI();

            
        }

       


    }

    void LoadLootGUI()
    {
        lootValues lv = lootSpw.transform.GetChild(lootIndex).GetComponent<lootValues>();

        lootStrg = "You got:"
            + "\n" + " " + "\n";
        if(lv.ammo != 0)
        {

            if(lv.ammo < 0)
            {
                lootStrg += "" + lv.ammo + " Ammo" + "\n";
            }
            else
            {
                lootStrg += "+" + lv.ammo + " Ammo" + "\n";
            }
           
        }

        if (lv.hp != 0)
        {

            if (lv.hp < 0)
            {
                lootStrg += "" + lv.hp + " HP" + "\n";
            }
            else
            {
                lootStrg += "+" + lv.hp + " HP" + "\n";
            }

        }

        if (lv.maxhp != 0)
        {

            if (lv.maxhp < 0)
            {
                lootStrg += "" + lv.maxhp + " MAXHP" + "\n";
            }
            else
            {
                lootStrg += "+" + lv.maxhp + " MAXHP" + "\n";
            }

        }

        if (lv.att != 0)
        {

            if (lv.att < 0)
            {
                lootStrg += "" + lv.att + " ATT" + "\n";
            }
            else
            {
                lootStrg += "+" + lv.att + " ATT" + "\n";
            }

        }

        if (lv.def != 0)
        {

            if (lv.def < 0)
            {
                lootStrg += "" + lv.def + " DEF" + "\n";
            }
            else
            {
                lootStrg += "+" + lv.def + " DEF" + "\n";
            }

        }

        if (lv.critmod != 0)
        {

            if (lv.critmod < 0)
            {
                lootStrg += "" + lv.critmod + " CRIT" + "\n";
            }
            else
            {
                lootStrg += "+" + lv.critmod + " CRIT" + "\n";
            }

        }

        if (lv.acc != 0)
        {

            if (lv.acc < 0)
            {
                lootStrg += "" + lv.acc + " ACC" + "\n";
            }
            else
            {
                lootStrg += "+" + lv.acc + " ACC" + "\n";
            }

        }

        if (lv.agi != 0)
        {

            if (lv.agi < 0)
            {
                lootStrg += "" + lv.agi + " AGI" + "\n";
            }
            else
            {
                lootStrg += "+" + lv.agi + " AGI" + "\n";
            }

        }

        if (lv.coin != 0)
        {

            if (lv.coin < 0)
            {
                lootStrg += "\n"+"" + lv.coin + " COIN" + "\n";
            }
            else
            {
                lootStrg += "\n" + "+" + lv.coin + " COIN" + "\n";
            }

        }


        //literally hate my life right now

        lootGUI.text = lootStrg;
        lootStrg = "";


    }


}

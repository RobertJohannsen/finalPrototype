using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class freeGUICore : MonoBehaviour
{
    public levelcore lvlcore;
    public bool freeDone;
    public freeLootTable flt;
    public int[] cost;
    public bool freeLoadDebounce;
    public TextMeshProUGUI[] itemText;

    public string[] lootStrg;
    public lootValues[] lv;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flt.freeLoadDone)
        {
            if (!freeLoadDebounce)
            {



                LoadLootGUI();

                freeLoadDebounce = true;
            }
        }


        
    }



    void LoadLootGUI()
    {



        for (int i = 0; i < flt.spawn.transform.childCount; i++)
        {
            lv[i] = flt.spawn.transform.GetChild(i).GetComponent<lootValues>();
            lootStrg[i] = "";



            lootStrg[i] += "Free! : " + "\n" + "\n";

            if (lv[i].ammo != 0)
            {

                if (lv[i].ammo < 0)
                {
                    lootStrg[i] += "" + lv[i].ammo + " Ammo" + "\n";
                }
                else
                {
                    lootStrg[i] += "+" + lv[i].ammo + " Ammo" + "\n";
                }

            }

            if (lv[i].hp != 0)
            {

                if (lv[i].hp < 0)
                {
                    lootStrg[i] += "" + lv[i].hp + " HP" + "\n";
                }
                else
                {
                    lootStrg[i] += "+" + lv[i].hp + " HP" + "\n";
                }

            }

            if (lv[i].maxhp != 0)
            {

                if (lv[i].maxhp < 0)
                {
                    lootStrg[i] += "" + lv[i].maxhp + " MAXHP" + "\n";
                }
                else
                {
                    lootStrg[i] += "+" + lv[i].maxhp + " MAXHP" + "\n";
                }

            }

            if (lv[i].att != 0)
            {

                if (lv[i].att < 0)
                {
                    lootStrg[i] += "" + lv[i].att + " ATT" + "\n";
                }
                else
                {
                    lootStrg[i] += "+" + lv[i].att + " ATT" + "\n";
                }

            }

            if (lv[i].def != 0)
            {

                if (lv[i].def < 0)
                {
                    lootStrg[i] += "" + lv[i].def + " DEF" + "\n";
                }
                else
                {
                    lootStrg[i] += "+" + lv[i].def + " DEF" + "\n";
                }

            }

            if (lv[i].critmod != 0)
            {

                if (lv[i].critmod < 0)
                {
                    lootStrg[i] += "" + lv[i].critmod + " CRIT" + "\n";
                }
                else
                {
                    lootStrg[i] += "+" + lv[i].critmod + " CRIT" + "\n";
                }

            }

            if (lv[i].acc != 0)
            {

                if (lv[i].acc < 0)
                {
                    lootStrg[i] += "" + lv[i].acc + " ACC" + "\n";
                }
                else
                {
                    lootStrg[i] += "+" + lv[i].acc + " ACC" + "\n";
                }

            }

            if (lv[i].agi != 0)
            {

                if (lv[i].agi < 0)
                {
                    lootStrg[i] += "" + lv[i].agi + " AGI" + "\n";
                }
                else
                {
                    lootStrg[i] += "+" + lv[i].agi + " AGI" + "\n";
                }

            }



            //literally hate my life right now

            itemText[i].text = lootStrg[i];




        }

        Debug.Log("loot load done");




    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shopGUICore : MonoBehaviour
{
    public levelcore lvlcore;
    public bool shopDone;
    public shopLootTable slt;
    public int[] cost;
    public bool shopLoadDebounce;
    public TextMeshProUGUI[] itemText;
    public TextMeshProUGUI coinText;
    public string[] lootStrg;
    public lootValues[] lv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(slt.shopLoadDone)
        {
            if(!shopLoadDebounce)
            {
               
            

                LoadLootGUI();

                shopLoadDebounce = true;
            }
        }

        coinText.text = "Coins : " + PlayerPrefs.GetInt("plycoin");

        for(int b = 0; b < 3;b++)
        {

           
            if((PlayerPrefs.GetInt("plycoin") - cost[b]) < 0)
            {
                itemText[b].GetComponentInParent<Button>().interactable = false;
                itemText[b].GetComponent<TextMeshProUGUI>().color = new Color32(50, 50 , 50 , 100);
            }
            else
            {
                itemText[b].GetComponentInParent<Button>().interactable = true;
                itemText[b].GetComponent<TextMeshProUGUI>().color = new Color32(50, 50, 50, 255);
            }

          
        }
    }



    void LoadLootGUI()
    {

      

        for(int i = 0; i < slt.spawn.transform.childCount; i++)
        {
            cost[i] = Random.Range(2, 6) * slt.globalLvl;
            lv[i] = slt.spawn.transform.GetChild(i).GetComponent<lootValues>();
            lootStrg[i] = "";
  
              

                lootStrg[i] += "Buy : " + "\n" + "\n";

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


            lootStrg[i] += ""
              + "\n" + "For : "+cost[i] + " Coins \n";

            //literally hate my life right now

            itemText[i].text = lootStrg[i];
                


           
        }

        Debug.Log("loot load done");

     


    }
}

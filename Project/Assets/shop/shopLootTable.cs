using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopLootTable : MonoBehaviour
{
    public List<GameObject> drops = new List<GameObject>();
    public shopCanvCore core;
    public GameObject self , spawn;
    public int globalLvl, lootroll;
    public Color colorR;
    public bool shopLoadDone;
    // Start is called before the first frame update
    void Start()
    {
        
        globalLvl = PlayerPrefs.GetInt("globallvl");
        self = this.gameObject;
 
        



    }

    // Update is called once per frame
    void Update()
    {
        globalLvl = PlayerPrefs.GetInt("globallvl");
        
    }

    public void makeitrain()
    {
        Debug.Log(globalLvl);
        for (int i = 0; i < drops.Count; i++)
        {
            GameObject temploot = Instantiate(drops[0], spawn.transform.position , Quaternion.identity);
            temploot.transform.SetParent(spawn.transform);


           

            lootroll = Random.Range(1, 5);
            int coinRoll = Random.Range(1, 10);

            switch (lootroll)
            {
                case 1:
                    //ammo
                    colorR = Color.yellow;

                    temploot.GetComponent<TrailRenderer>().startColor = colorR;
                    temploot.GetComponent<TrailRenderer>().endColor = colorR;
                    temploot.GetComponent<SpriteRenderer>().color = colorR;
                    temploot.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = colorR;

                    temploot.GetComponent<lootValues>().ammo = 3 * globalLvl;
                    Debug.Log("work");
                    break;
                case 2:
                    //health
                    colorR = Color.red;

                    temploot.GetComponent<lootValues>().hp += 5 * globalLvl;

                    temploot.GetComponent<TrailRenderer>().startColor = colorR;
                    temploot.GetComponent<TrailRenderer>().endColor = colorR;
                    temploot.GetComponent<SpriteRenderer>().color = colorR;
                    temploot.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = colorR;

                    break;
                case 3:
                    //fancy
                    int rollstat1 = Random.Range(1, 7);
                    int rollstat2 = Random.Range(1, 7);

                    colorR = Color.cyan;

                    temploot.GetComponent<TrailRenderer>().startColor = colorR;
                    temploot.GetComponent<TrailRenderer>().endColor = colorR;
                    temploot.GetComponent<SpriteRenderer>().color = colorR;
                    temploot.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = colorR;



                    switch (rollstat1)
                    {
                        case 1:
                            //hp 
                            temploot.GetComponent<lootValues>().hp += Random.Range(1, 4) * globalLvl;
                            break;
                        case 2:
                            //maxhp
                            temploot.GetComponent<lootValues>().maxhp += Random.Range(2, 4) * globalLvl;
                            break;
                        case 3:
                            temploot.GetComponent<lootValues>().att += Random.Range(2, 4) * globalLvl;
                            //att
                            break;
                        case 4:
                            //def
                            temploot.GetComponent<lootValues>().def += 2 * globalLvl;
                            break;
                        case 5:
                            //critmod
                            temploot.GetComponent<lootValues>().critmod += Random.Range(2, 4) * globalLvl;
                            break;
                        case 6:
                            //acc
                            temploot.GetComponent<lootValues>().acc += Random.Range(2, 5) * globalLvl;
                            break;
                        case 7:
                            //agi
                            temploot.GetComponent<lootValues>().agi += Random.Range(2, 4) * globalLvl;
                            break;
                    }


                    switch (rollstat2)
                    {
                        case 1:
                            //hp 
                            temploot.GetComponent<lootValues>().hp += Random.Range(2, 4) * globalLvl;
                            break;
                        case 2:
                            //maxhp
                            temploot.GetComponent<lootValues>().maxhp += Random.Range(2, 4) * globalLvl;
                            break;
                        case 3:
                            temploot.GetComponent<lootValues>().att += Random.Range(2, 4) * globalLvl;
                            //att
                            break;
                        case 4:
                            //def
                            temploot.GetComponent<lootValues>().def += 2 * globalLvl;
                            break;
                        case 5:
                            //critmod
                            temploot.GetComponent<lootValues>().critmod += Random.Range(2, 4) * globalLvl;
                            break;
                        case 6:
                            //acc
                            temploot.GetComponent<lootValues>().acc += Random.Range(2, 5) * globalLvl;
                            break;
                        case 7:
                            //agi
                            temploot.GetComponent<lootValues>().agi += Random.Range(2, 4) * globalLvl;
                            break;
                    }

                    break;
                case 4:
                    //fancy 2

                    int rollstat12 = Random.Range(1, 8);
                    int rollstat22 = Random.Range(1, 8);
                    int negativeStat = Random.Range(1, 2);

                    colorR = Color.magenta;

                    temploot.GetComponent<TrailRenderer>().startColor = colorR;
                    temploot.GetComponent<TrailRenderer>().endColor = colorR;
                    temploot.GetComponent<SpriteRenderer>().color = colorR;
                    temploot.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = colorR;
                    //top is pos , bot is neg

                    if (negativeStat == 1)
                    {
                        switch (rollstat12)
                        {
                            case 1:
                                //hp 
                                temploot.GetComponent<lootValues>().hp += Random.Range(2, 5) * globalLvl;
                                break;
                            case 2:
                                //maxhp
                                temploot.GetComponent<lootValues>().maxhp += Random.Range(2, 5) * globalLvl;
                                break;
                            case 3:
                                temploot.GetComponent<lootValues>().att += Random.Range(2, 5) * globalLvl;
                                //att
                                break;
                            case 4:
                                //def
                                temploot.GetComponent<lootValues>().def += Random.Range(2, 5) * globalLvl;
                                break;
                            case 5:
                                //critmod
                                temploot.GetComponent<lootValues>().critmod += Random.Range(2, 5) * globalLvl;
                                break;
                            case 6:
                                //acc
                                temploot.GetComponent<lootValues>().acc += Random.Range(2, 6) * globalLvl;
                                break;
                            case 7:
                                //agi
                                temploot.GetComponent<lootValues>().agi += Random.Range(2, 5) * globalLvl;
                                break;
                      

                        }


                        switch (rollstat22)
                        {
                            case 1:
                                //hp 
                                temploot.GetComponent<lootValues>().hp -= Random.Range(2, 4) * globalLvl;
                                break;
                            case 2:
                                //maxhp
                                temploot.GetComponent<lootValues>().maxhp -= Random.Range(2, 4) * globalLvl;
                                break;
                            case 3:
                                temploot.GetComponent<lootValues>().att -= Random.Range(2, 4) * globalLvl;
                                //att
                                break;
                            case 4:
                                //def
                                temploot.GetComponent<lootValues>().def -= Random.Range(2, 4) * globalLvl;
                                break;
                            case 5:
                                //critmod
                                temploot.GetComponent<lootValues>().critmod -= Random.Range(2, 4) * globalLvl;
                                break;
                            case 6:
                                //acc
                                temploot.GetComponent<lootValues>().acc -= Random.Range(2, 6) * globalLvl;
                                break;
                            case 7:
                                //agi
                                temploot.GetComponent<lootValues>().agi -= Random.Range(2, 4) * globalLvl;
                                break;
                         
                        }

                    }
                    else
                    {
                        //top is neg , bot is pos

                        switch (rollstat22)
                        {
                            case 1:
                                //hp 
                                temploot.GetComponent<lootValues>().hp += Random.Range(2, 5) * globalLvl;
                                break;
                            case 2:
                                //maxhp
                                temploot.GetComponent<lootValues>().maxhp += Random.Range(2, 5) * globalLvl;
                                break;
                            case 3:
                                temploot.GetComponent<lootValues>().att += Random.Range(2, 5) * globalLvl;
                                //att
                                break;
                            case 4:
                                //def
                                temploot.GetComponent<lootValues>().def += Random.Range(2, 5) * globalLvl;
                                break;
                            case 5:
                                //critmod
                                temploot.GetComponent<lootValues>().critmod += Random.Range(2, 5) * globalLvl;
                                break;
                            case 6:
                                //acc
                                temploot.GetComponent<lootValues>().acc += Random.Range(2, 6) * globalLvl;
                                break;
                            case 7:
                                //agi
                                temploot.GetComponent<lootValues>().agi += Random.Range(2, 5) * globalLvl;
                                break;
                        

                        }


                        switch (rollstat12)
                        {
                            case 1:
                                //hp 
                                temploot.GetComponent<lootValues>().hp -= Random.Range(2, 4) * globalLvl;
                                break;
                            case 2:
                                //maxhp
                                temploot.GetComponent<lootValues>().maxhp -= Random.Range(2, 4) * globalLvl;
                                break;
                            case 3:
                                temploot.GetComponent<lootValues>().att -= Random.Range(2, 4) * globalLvl;
                                //att
                                break;
                            case 4:
                                //def
                                temploot.GetComponent<lootValues>().def -= Random.Range(2, 4) * globalLvl;
                                break;
                            case 5:
                                //critmod
                                temploot.GetComponent<lootValues>().critmod -= Random.Range(2, 4) * globalLvl;
                                break;
                            case 6:
                                //acc
                                temploot.GetComponent<lootValues>().acc -= Random.Range(2, 6) * globalLvl;
                                break;
                            case 7:
                                //agi
                                temploot.GetComponent<lootValues>().agi -= Random.Range(2, 4) * globalLvl;
                                break;
                           
                        }



                    }


                    break;


            }

          


        }

        shopLoadDone = true;
    }


    public void DestroyShopLoot()
    {
        for(int k = 0; k < spawn.transform.childCount; k++)
        {
            Destroy(spawn.transform.GetChild(k).gameObject);
        }

        shopLoadDone = false;
    }
}

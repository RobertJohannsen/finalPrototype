using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateLvl : MonoBehaviour
{
    public levelcore core;
    public bool lvlDone;
    public int shopNo,freeNo ,shopThres , freeThres , globalDiff;
    // Start is called before the first frame update
    void Start()
    {

        lvlDone = false;

        for(int k = 0; k <= 15; k++)
        {
            int rollforType = Random.Range(1, 100);
            switch (k)
            {

                //branch 1

                case 0:
                    core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.battle;
                    break;
                case 1:
                    

                    if(rollforType < 50)
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.battle;
                    }
                    else
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.free;
                    }
                   
                    break;
                case 2:
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.battle;
                    break;


                //branch 2

                case 3:
                    

                    if(rollforType < 50)
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.battle;
                    }
                    else
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.shop;
                        shopNo++;
                    }
                    break;

                case 4:
                   

                    if (rollforType < 50)
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.free;
                        freeNo++;
                    }
                    else
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.shop;
                        shopNo++;
                    }
                    break;

                case 5:
                
                    if (rollforType < 60)
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.ezboss;
                    }
                    else
                    {
                        if(rollforType < 66)
                        {
                            core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.free;
                            freeNo++;
                        }
                        else
                        {
                            core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.battle;
                        }
                      
                    }
                    break;


                //branch 3


                case 6:
                    

                    if (rollforType < 50)
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.battle;
                    }
                    else
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.shop;
                        shopNo++;
                    }
                    break;

                case 7:
                   

                    if (rollforType < 50)
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.battle;
                    }
                    else
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.shop;
                        shopNo++;
                    }
                    break;

                case 8:

                    if (rollforType < 60)
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.ezboss;
                    }
                    else
                    {
                        if (rollforType < 66)
                        {
                            core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.free;
                            freeNo++;
                        }
                        else
                        {
                            core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.shop;
                            shopNo++;
                        }

                    }
                    break;


                //branch 4

                case 9:
                    if(rollforType < 50)
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.battle;
                    }
                    else
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.free;
                    }
                    break;

                case 10:
                    if (rollforType < 50)
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.battle;
                    }
                    else
                    {
                        if(freeNo < 1)
                        {
                            core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.free;
                        }
                        else
                        {
                            core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.battle;
                        }
                        
                    }
                    break;

                //branch 5

                case 11:
                    if (rollforType < 50)
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.battle;
                    }
                    else
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.free;
                    }
                    break;

                case 12:
                    if (rollforType < 50)
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.battle;
                    }
                    else
                    {
                        if (shopNo < 1)
                        {
                            core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.free;
                        }
                        else
                        {
                            core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.battle;
                        }

                    }
                    break;

                //branch 6

                case 13:
                    if (rollforType < 50)
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.battle;
                    }
                    else
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.free;
                    }
                    break;

                case 14:
                    if (rollforType < 50)
                    {
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.battle;
                    }
                    else
                    {
                        if (freeNo > 1)
                        {
                            core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.ezboss;
                        }
                        else
                        {
                            core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.battle;
                        }

                    }
                    break;

                //branch 7

                case 15:
                        core.levelObj[k].GetComponent<lvlSetup>().type = lvlSetup.lvlType.boss;
                    Debug.Log("boss spawned");
                    break;

           








            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class levelcore : MonoBehaviour
{
    public List<GameObject> levelObj = new List<GameObject>();
    public int x, branch ;
    public levelcore lvlcore;
    public GameObject sltLevel,brackets,dispEnemy,shopLootSpawn,freeLootSpawn;
    public int lvl;
    public Canvas battleCanv ,shopCanv , freeCanv, bossCanv, ezbossCanv;
    public bool shopDebounce, freeDebounce;
    public shopCanvCore shopCore;
    public freeCanvCore freeCore;
    public Sprite[] enemyDecal;
    public GameObject saveCont;
    public int saveindex;
    public bool fakeDone;
    public int ghostareyouhere;

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        sltLevel = levelObj[0];
        x = 1;
        branch = 1;
        PlayerPrefs.SetString("enemyType", "none");

        if(PlayerPrefs.GetInt("prevDone") == 2)
        {
            fakeDone = true;
            PlayerPrefs.SetInt("prevDone",1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        saveCont = GameObject.FindGameObjectWithTag("storage");

        if(Input.GetKeyDown(KeyCode.Y))
        {
            PlayerPrefs.SetInt("x",1);
            PlayerPrefs.SetInt("branch",1);
            PlayerPrefs.SetInt("plycoin", 69);
        }

       x = PlayerPrefs.GetInt("x");
       branch = PlayerPrefs.GetInt("branch");

     



        if (branch < 4)
        {
            
              
            
           if(x == 4)
            {
                brackets.transform.GetChild(0).gameObject.transform.position = brackets.transform.position ;
                JumpBranch();
               
            }
           else
            {
                brackets.transform.GetChild(0).gameObject.transform.position = new Vector3(69, 1337, 69);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    
                       
                        x++;
                        ResetDebounce();
                    
                    Debug.Log(sltLevel);




                }
            }
              
            
        }
        else
        {
            if (x == 3)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {

                    branch = 7;
                    ResetDebounce();
            


                }
            }
            else
            {
                brackets.transform.GetChild(0).gameObject.transform.position = new Vector3(9999, 1111, 9999);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                  
                       
                        x++;
                        ResetDebounce();
                    
                    Debug.Log(sltLevel);


                }
            }
            
              
            
        }







        WorkOutBranches();

        PlayerPrefs.SetInt("x", x);
        PlayerPrefs.SetInt("branch", branch);

        handleUICanv();
        
    





        brackets.transform.position = sltLevel.transform.position;

        switch (branch)
        {
            case 1:
                PlayerPrefs.SetInt("globallvl", 1);
                break;
            case 2:
                PlayerPrefs.SetInt("globallvl", 2);
                break;
            case 3:
                PlayerPrefs.SetInt("globallvl", 2);
                break;
            case 4:
                PlayerPrefs.SetInt("globallvl", 3);
                break;
            case 5:
                PlayerPrefs.SetInt("globallvl", 3);
                break;
            case 6:
                PlayerPrefs.SetInt("globallvl", 3);
                break;
            case 7:
                PlayerPrefs.SetInt("globallvl", 4);
                break;
        }

        if (Input.GetKeyDown(KeyCode.E))
            {
            //loads level
            setLvlDone();
            PlayerPrefs.SetString("enemyType", sltLevel.GetComponent<lvlSetup>().enemyType);
            
            SceneManager.LoadScene(2);
            }


    }

    public void ResetDebounce()
    {
        shopCanv.GetComponent<shopGUICore>().shopDone = false;
        shopDebounce = false;
        shopCanv.GetComponent<shopGUICore>().shopLoadDebounce = false;

        if (shopLootSpawn.GetComponent<shopLootTable>().drops.Count != 0)
        {
            shopLootSpawn.GetComponent<shopLootTable>().drops = new List<GameObject>(); //in theory clears the list
            for (int z = 0; z < shopLootSpawn.transform.childCount; z++)
            {
                Destroy(shopLootSpawn.transform.GetChild(z).gameObject);
            }

            Debug.Log("cleared shop inventory");

        }


        freeDebounce = false;
        freeCanv.GetComponent<freeGUICore>().freeLoadDebounce = false;

        if (freeLootSpawn.GetComponent<freeLootTable>().drops.Count != 0)
        {
            freeLootSpawn.GetComponent<freeLootTable>().drops = new List<GameObject>(); //in theory clears the list
            for (int z = 0; z < freeLootSpawn.transform.childCount; z++)
            {
                Destroy(freeLootSpawn.transform.GetChild(z).gameObject);
            }

            Debug.Log("cleared free inventory");

        }
    }

    public void setLvlDone()
    {
        sltLevel.GetComponent<lvlSetup>().isDone = true;

        PlayerPrefs.SetInt("prevDone",2);
    }

    void handleUICanv()
    {
        if (sltLevel.GetComponent<lvlSetup>().type == lvlSetup.lvlType.battle)
        {
            battleCanv.enabled = true;
            dispEnemy.GetComponent<SpriteRenderer>().enabled = true;

            switch (sltLevel.GetComponent<lvlSetup>().enemyType)
            {
                case "bloc-man":
                    dispEnemy.GetComponent<SpriteRenderer>().sprite = enemyDecal[0];
                    break;
                case "speed-man":
                    dispEnemy.GetComponent<SpriteRenderer>().sprite = enemyDecal[1];
                    break;
                case "tank-man":
                    dispEnemy.GetComponent<SpriteRenderer>().sprite = enemyDecal[2];
                    break;
                
                    
                   
            }
           
            dispEnemy.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            dispEnemy.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = fakeDone;
            
           
        }
        else
        {
            battleCanv.enabled = false;
            dispEnemy.GetComponent<SpriteRenderer>().enabled = false;
            dispEnemy.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        //shop stuff
        if (sltLevel.GetComponent<lvlSetup>().type == lvlSetup.lvlType.shop)
        {

            if(!shopDebounce)
            {
              
                shopCore.popShopLoot(shopLootSpawn); //puts prefabs into shop
                shopLootSpawn.GetComponent<shopLootTable>().makeitrain(); //adds the value of stats to the prefabs
                shopDebounce = true;
                shopCanv.GetComponent<shopGUICore>().shopDone = false;

            }
            if(!shopCanv.GetComponent<shopGUICore>().shopDone)
            {
                shopCanv.enabled = true;
            }
            else
            {
                setLvlDone();
                shopCanv.enabled = false;
            }
            
            dispEnemy.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            shopCanv.GetComponent<shopGUICore>().shopDone = false;
            shopDebounce = false;
            shopCanv.enabled = false;
        }

        //end of shop stuff

        if (sltLevel.GetComponent<lvlSetup>().type == lvlSetup.lvlType.free)
        {
            if (!freeDebounce)
            {

                freeCore.popFreeLoot(freeLootSpawn); //puts prefabs into shop
                freeLootSpawn.GetComponent<freeLootTable>().makeitrain(); //adds the value of stats to the prefabs
                freeDebounce = true;
                freeCanv.GetComponent<freeGUICore>().freeDone = false;

            }
            if (!freeCanv.GetComponent<freeGUICore>().freeDone)
            {
                freeCanv.enabled = true;
            }
            else
            {
                setLvlDone();
                freeCanv.enabled = false;
            }


            dispEnemy.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            freeCanv.GetComponent<freeGUICore>().freeDone = false;
            freeDebounce = false;
            freeCanv.enabled = false;
        }

        if (sltLevel.GetComponent<lvlSetup>().type == lvlSetup.lvlType.boss)
        {
            bossCanv.enabled = true;
            dispEnemy.GetComponent<SpriteRenderer>().enabled = true;
            dispEnemy.GetComponent<SpriteRenderer>().sprite = enemyDecal[3];
            dispEnemy.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            bossCanv.enabled = false;
        }

        if (sltLevel.GetComponent<lvlSetup>().type == lvlSetup.lvlType.ezboss)
        {
            ezbossCanv.enabled = true;
            dispEnemy.GetComponent<SpriteRenderer>().enabled = true;

            switch (sltLevel.GetComponent<lvlSetup>().enemyType)
            {
                case "bloc-man":
                    dispEnemy.GetComponent<SpriteRenderer>().sprite = enemyDecal[0];
                    break;
                case "speed-man":
                    dispEnemy.GetComponent<SpriteRenderer>().sprite = enemyDecal[1];
                    break;
                case "tank-man":
                    dispEnemy.GetComponent<SpriteRenderer>().sprite = enemyDecal[2];
                    break;



            }


            dispEnemy.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            ezbossCanv.enabled = false;
        }

    }

    void JumpBranch()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {

            switch (branch)
            {
                case 1:

                    branch = 2;
                    x = 1;
                    break;
                case 2:

                    branch = 4;
                    x = 1;

                    break;
                case 3:

                    branch = 5;
                    x = 1;

                    break;



            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            switch (branch)
            {
                case 1:
                    if (x == 4)
                    {
                        branch = 3;
                        x = 1;
                    }
                    break;
                case 2:
                    if (x == 4)
                    {
                        branch = 5;
                        x = 1;
                    }
                    break;
                case 3:
                    if (x == 4)
                    {
                        branch = 6;
                        x = 1;
                    }
                    break;



            }
        }
    }

    void WorkOutBranches()
    {

        if(branch <4)
        {

            if (levelObj[((branch - 1) * 3) + (x - 1)] != null)
            {
                if(x != 4)
                {
                    sltLevel = levelObj[((branch - 1) * 3) + (x - 1)];
                }
              
            }
        }
        else
        {
            if(branch < 7)
            {
                if (levelObj[8 + (x + ((branch-4)*2))] != null)
                {
                    if(x != 3)
                    {
                        sltLevel = levelObj[8 + (x + ((branch - 4) * 2))];
                    }
                 
                }
            }
            else
            {
                sltLevel = levelObj[15];
            }
           
        }
       
               
    }
}

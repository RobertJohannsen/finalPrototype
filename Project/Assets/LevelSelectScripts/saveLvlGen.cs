using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveLvlGen : MonoBehaviour
{
    public List<lvlSetup> lvlLoad = new List<lvlSetup>();
    public levelcore lvcore;
    public int loadTimer ,loadThres;
    public GameObject storagePrefab;


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

      
    }
    // Start is called before the first frame update
    void Start()
    {
        loadThres = 3;
    }

    // Update is called once per frame
    void Update()
    {
        loadTimer++;

        if(loadTimer > loadThres)
        {
            loadTimer = 0;

            if (PlayerPrefs.GetInt("lvlLoad") == 1)
            {
                for (int v = 0; v < lvcore.levelObj.Count - 1; v++)
                {
                    lvlLoad.Add(lvcore.levelObj[v].GetComponent<lvlSetup>());
                }

                for (int f = 0; f < lvcore.levelObj.Count - 1; f++)
                {
                    GameObject tempStorageNode = Instantiate(storagePrefab, this.gameObject.transform.position, Quaternion.identity);
                    tempStorageNode.transform.parent = this.gameObject.transform;
                    tempStorageNode.name = "lvlStorageNode";


                    tempStorageNode.GetComponent<lvlSetup>().type = lvlLoad[f].type;
                    tempStorageNode.GetComponent<lvlSetup>().enemyroll = lvlLoad[f].enemyroll;
                    tempStorageNode.GetComponent<lvlSetup>().isDone = lvlLoad[f].isDone;
                    tempStorageNode.GetComponent<lvlSetup>().enemyType = lvlLoad[f].enemyType;

                    //creates and clones the thing to a persistent lvlsetup

                    lvlLoad[f] = tempStorageNode.GetComponent<lvlSetup>();

                    

                }

              
                Debug.Log("Persistence please work");

                PlayerPrefs.SetInt("lvlLoad", 2);
            }
            else
            {

                if(SceneManager.GetActiveScene().buildIndex == 1)
                {
                    if (lvlLoad.Count == 0)
                    {
                        Debug.Log(PlayerPrefs.GetInt("lvlLoad"));
                        Debug.Log("Destroyed fake");
                        Destroy(this.gameObject);

                    }



                    if (PlayerPrefs.GetInt("lvlLoad") == 2)
                    {

                        lvcore = Camera.main.GetComponent<levelcore>();

                        Debug.Log(lvcore.levelObj.Count + " " +lvlLoad.Count);


                        for (int g = 0; g < this.gameObject.transform.childCount - 1; g++)
                        {
                            lvcore.levelObj[g].GetComponent<lvlSetup>().type = this.gameObject.transform.GetChild(g).GetComponent<lvlSetup>().type;
                            lvcore.levelObj[g].GetComponent<lvlSetup>().enemyroll = this.gameObject.transform.GetChild(g).GetComponent<lvlSetup>().enemyroll;
                            lvcore.levelObj[g].GetComponent<lvlSetup>().enemyType = this.gameObject.transform.GetChild(g).GetComponent<lvlSetup>().enemyType;


                        }

                        Debug.Log("loadDone");

                    }

                }
            }
             
        }

    
    }
}

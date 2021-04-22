using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootGenCore : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] lootObjs; //inside this is all the possible drop classes
    public GameObject target, actualTarget;
    public int items;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void PopulateLoot(GameObject popTarg)
    {
        switch (popTarg.GetComponent<lootTable>().enemyClass)
        {
            case "bloc-man":
                items = 2 + PlayerPrefs.GetInt("globallvl");

             
                break;
            case "speed-man":
                items = 3 + PlayerPrefs.GetInt("globallvl");


                break;
            case "tank-man":
                items = 3 + PlayerPrefs.GetInt("globallvl");


                break;
            case "ez-man":
                items = 5 + PlayerPrefs.GetInt("globallvl");


                break;
            case "boss-man":
                items = 10 + PlayerPrefs.GetInt("globallvl");


                break;
        }
        for (int k = 0; k < items; k++)
        {
            popTarg.GetComponent<lootTable>().drops.Add(lootObjs[0]);
        }
    }

    
}

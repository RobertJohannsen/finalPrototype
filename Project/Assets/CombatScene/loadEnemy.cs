using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadEnemy : MonoBehaviour
{
    public GameObject[] enemyContainer;
    public GameObject target,tempEnemy;
    public bool enemyLoaded;
    // Start is called before the first frame update
    void Start()
    {
        switch(PlayerPrefs.GetString("enemyType"))
        {
            case "bloc-man":
                tempEnemy = Instantiate(enemyContainer[0], target.transform.position, Quaternion.identity);
                tempEnemy.transform.position = new Vector3(-3.9f, 21.9f, -7);
                tempEnemy.transform.SetParent(target.transform);
                tempEnemy.transform.localScale = new Vector3(0.8f,0.8f,0.8f);
               

                break;
            case "speed-man":
                tempEnemy = Instantiate(enemyContainer[1], target.transform.position, Quaternion.identity);
                tempEnemy.transform.position = new Vector3(-3.9f, 21.9f, -7);
                tempEnemy.transform.SetParent(target.transform);
                tempEnemy.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                
                break;
            case "tank-man":
                tempEnemy = Instantiate(enemyContainer[2], target.transform.position, Quaternion.identity);
                tempEnemy.transform.position = new Vector3(-3.9f, 21.9f, -7);
                tempEnemy.transform.SetParent(target.transform);
                tempEnemy.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
          
                break;
            case "boss-man":
                tempEnemy = Instantiate(enemyContainer[3], target.transform.position, Quaternion.identity);
                tempEnemy.transform.position = new Vector3(-3.9f, 21.9f, -7);
                tempEnemy.transform.SetParent(target.transform);
                tempEnemy.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
              
                break;
        }


        enemyLoaded = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

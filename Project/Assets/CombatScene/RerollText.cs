using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RerollText : MonoBehaviour
{
    public TextMeshProUGUI rerollText;

    public Canvas startcanv;
    int acc, crit, hp, ap, ar , att ,agi ,ammo;
    public bool showText;
    // Start is called before the first frame update
    void Start()
    {
        showText = true;
        ammo = (int)Random.Range(3,7);
        acc = (int)Random.Range(20, 50);
        ar = (int)Random.Range(1, 10);
        crit = (int)Random.Range(1, 25);
        ap = (int)Random.Range(10, 21);
        att = (int)Random.Range(1, 20);
        hp = (int)Random.Range(20, 50);
        agi = (int)Random.Range(5, 20);

    }

    // Update is called once per frame
    void Update()
    {
       
           
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetInt("plyhp", hp);
                PlayerPrefs.SetInt("plyammo", ammo);
                PlayerPrefs.SetInt("plymaxhp", hp);
                PlayerPrefs.SetInt("plyatt", att);
                PlayerPrefs.SetInt("plydef", ar);
                PlayerPrefs.SetInt("plycrit", crit);
                PlayerPrefs.SetInt("plyacc", acc);
                PlayerPrefs.SetInt("plyagi", agi);
                PlayerPrefs.SetInt("plycoin", 0);
                PlayerPrefs.SetInt("plyap", ap);
                PlayerPrefs.SetInt("plymaxap", ap);
                

                showText = false;

            PlayerPrefs.SetInt("x", 1);
            PlayerPrefs.SetInt("branch", 1);
            PlayerPrefs.SetInt("globallvl", 1);
            PlayerPrefs.SetInt("lvlLoad", 1);
            Debug.Log("initailising Prefs");

            SceneManager.LoadScene(1);


            }
            if (Input.GetMouseButtonDown(1))
            {
                ammo = (int)Random.Range(3, 7);
                acc = (int)Random.Range(15,25);
                ar = (int)Random.Range(1, 10);
                crit = (int)Random.Range(1, 25);
                ap = 15;
                att = (int)Random.Range(1, 20);
                hp = (int)Random.Range(20, 50);
                agi = (int)Random.Range(5, 20);

            }

            rerollText.text = "NotJo stats \n"
                + "HP : " + hp + " (Increases HP by a flat amount)\n"
                + "AP : " + ap + " (effects your AP pool)\n"
                + "Armor : " + ar + " (reduces the damage you take by a flat amount)\n"
              
                + "Acc : " + acc + " (effects your hit rate)\n"
              
                + "Crit : " + crit + " (effects your crit rate)\n"
               
                + "Att : " + att + " (increases the damage you do)\n"
                + "AGI : " + agi + " (Increase your chance to get attack first in combat)\n"
                + "\nStarting Ammo : " + ammo + " (amount of times you can shoot)\n"



                + "\n" + "Left click to finalize stats and start run, right click to reroll stats" + "\n"
                + "\n"
                + "\n" + "Font used : Quicksand by Andrew Paglinawan"
                 ;
       
       

    }
}

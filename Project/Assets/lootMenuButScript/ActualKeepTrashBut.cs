using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActualKeepTrashBut : MonoBehaviour
{
    public GameObject ply;
    public GameObject lootSpw;
    public KeepTrashScript kts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Keep()
    {
        if(kts.lootIndex == lootSpw.transform.childCount-1)
        {
            applyStats();
            SceneManager.LoadScene(1);
            Debug.Log("end stage");
        }

        applyStats();
        kts.lootIndex++;
    }

    public void Trash()
    {
        if (kts.lootIndex == lootSpw.transform.childCount-1)
        {
            Debug.Log("end stage");
            SceneManager.LoadScene(1);
        }

        kts.lootIndex++;
    }

    void applyStats()
    {
       stats plystats = ply.GetComponent<stats>();
        plyAttacks plyatt = ply.GetComponent<plyAttacks>();

        PlayerPrefs.SetInt("plyhp", plystats.hp + lootSpw.transform.GetChild(kts.lootIndex).GetComponent<lootValues>().hp);
        PlayerPrefs.SetInt("plyammo", plyatt.ammo + lootSpw.transform.GetChild(kts.lootIndex).GetComponent<lootValues>().ammo);
        PlayerPrefs.SetInt("plymaxhp", plystats.maxhp + lootSpw.transform.GetChild(kts.lootIndex).GetComponent<lootValues>().maxhp);
        PlayerPrefs.SetInt("plyatt", plystats.att + lootSpw.transform.GetChild(kts.lootIndex).GetComponent<lootValues>().att);
        PlayerPrefs.SetInt("plydef", plystats.armor + lootSpw.transform.GetChild(kts.lootIndex).GetComponent<lootValues>().def);
        PlayerPrefs.SetInt("plycrit", plystats.critmod + lootSpw.transform.GetChild(kts.lootIndex).GetComponent<lootValues>().critmod);
        PlayerPrefs.SetInt("plyacc", plystats.acc + lootSpw.transform.GetChild(kts.lootIndex).GetComponent<lootValues>().acc);
        PlayerPrefs.SetInt("plyagi", plystats.agi + lootSpw.transform.GetChild(kts.lootIndex).GetComponent<lootValues>().agi);
        PlayerPrefs.SetInt("plycoin", plystats.coin + lootSpw.transform.GetChild(kts.lootIndex).GetComponent<lootValues>().coin);


    }
}

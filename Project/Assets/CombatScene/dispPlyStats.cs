using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dispPlyStats : MonoBehaviour
{
    public GameObject ply;
    public GameObject StatBar;
    public stats objStats;
    public int ammoCount;
    public string angerStrg ;

    void Start()
    {
        objStats = ply.GetComponent<stats>();
        

    }

    // Update is called once per frame
    void Update()
    {

        StatBar.GetComponent<TextMeshPro>().text = "HP : " + objStats.hp + "/" + objStats.maxhp + "" + "\n"
        + "AP : " + objStats.currentap + "/" + objStats.maxap + angerStrg + "\n"
        + "Ammo : " + ply.GetComponent<plyAttacks>().ammo ;

        if (GetComponentInParent<plyAttacks>())
        {
            if (GetComponentInParent<plyAttacks>().apCostTotal != 0)
            {
                angerStrg = " -(" + GetComponentInParent<plyAttacks>().apCostTotal + ")";
            }
            else
            {
                angerStrg = "";
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class detailBTNBHV : MonoBehaviour
{
    public bool showDetail;
    public Canvas plyStatsCanv;
    public stats plyStats;
    public string cumdisptemp, name;
    public int hp, acc, def, crit, ap, att, agi, maxap, maxhp;
    public TextMeshProUGUI plyStatsDispText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        hp = plyStats.hp;
        acc = plyStats.acc;
        def = plyStats.armor;
        crit = plyStats.critmod;
        ap = plyStats.currentap;
        att = plyStats.att;
        agi = plyStats.agi;
        maxap = plyStats.maxap;
        maxhp = plyStats.maxhp;


        name = plyStats.name;


        cumdisptemp = name + " stats \n"
                + "\n"
                + "HP : " + hp + "/" + maxhp + "\n"
                + "AP : " + ap + "/" + maxap + "\n"
                + "ACC : " + acc + "\n"
                + "DEF : " + def + "\n"
                + "Crit : " + crit + "\n"
                + "ATT : " + att + "\n"
                + "AGI : " + agi + "\n"
                + "\n"
                 ;


        plyStatsDispText.text = cumdisptemp;


        plyStatsCanv.enabled = showDetail;


    }

    public void ShowDetails()
    {
        showDetail = !showDetail;
    }
}

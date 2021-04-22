using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class camRollAnimCont : MonoBehaviour
{
    public plyAttacks cum;
    public Canvas combatCanv ,enemyStatsCanv , contol , contol2;
    public TextMeshProUGUI cumdisp ,enemystatsdisp;
    public stats enemyStats;
    public string cumdisptemp ,  name ;
    public int hp, acc, def, crit, ap, att, agi, maxap , maxhp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cum.cLoop.debounceEnemyLoad)
        {
            enemyStats = cum.cLoop.attackObj2.GetComponent<stats>();


            hp = enemyStats.hp;
            acc = enemyStats.acc;
            def = enemyStats.armor;
            crit = enemyStats.critmod;
            ap = enemyStats.currentap;
            att = enemyStats.att;
            agi = enemyStats.agi;
            maxap = enemyStats.maxap;
            maxhp = enemyStats.maxhp;


            name = enemyStats.name;


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


            switch (enemyStats.bodyPart[cum.whatPart].tag)
            {
                case "head":
                    cumdisptemp += "Crippling the head will reduce " + name + "'s accuracy to 0"
                        + "\n the head has " + enemyStats.bodyPart[cum.whatPart].GetComponent<headBehaviour>().partHP + " HP left";
                    break;
                case "torso":
                    cumdisptemp += "Crippling the torso will half " + name + "'s armor"
                          + "\n torso has " + enemyStats.bodyPart[cum.whatPart].GetComponent<chestBehaviour>().partHP + " HP left";
                    break;
                case "arm":
                    cumdisptemp += "Crippling an arm will half" + name + "'s maximum AP"
                          + "\n this arm has " + enemyStats.bodyPart[cum.whatPart].GetComponent<armBehaviour>().partHP + " HP left";
                    break;
                case "leg":
                    cumdisptemp += "Crippling the leg will half " + name + "'s AGI"
                          + "\n this leg has " + enemyStats.bodyPart[cum.whatPart].GetComponent<legBehaviour>().partHP + " HP left";
                    break;
                case "hat":
                    cumdisptemp += "Shooting of " + name + "'s hat will reduce the current AP to 0"
                          + "\n \n- all you have to do is hit it ^w^";
                    break;
                case "weapon":
                    cumdisptemp += "Shooting the weapon out of " + name + "'s hand will reduce the attack to 0"
                         + "\n \n- all you have to do is hit it ^w^";
                    break;
            }


            enemystatsdisp.text = cumdisptemp;

            if (cum.beginAtt)
            {
                combatCanv.enabled = true;

            }
            else
            {
                combatCanv.enabled = false;
            }

            switch (cum.plyAttState)
            {
                case plyAttacks.AttState.none:
                    cumdisp.text = "(default)";
                    break;
                case plyAttacks.AttState.selectPart:
                    cumdisp.text = "(where)";
                    break;
                case plyAttacks.AttState.selectAtt:
                    cumdisp.text = "(what)";
                    break;
            }

            if (cum.plyAttState == plyAttacks.AttState.none)
            {
                contol2.enabled = true;
            }
            else
            {
                contol2.enabled = false;
            }

            if (cum.plyAttState == plyAttacks.AttState.selectPart)
            {
                enemyStatsCanv.enabled = true;
            }
            else
            {
                enemyStatsCanv.enabled = false;
            }

            if (cum.plyAttState == plyAttacks.AttState.selectAtt)
            {
                contol.enabled = true;
            }
            else
            {
                contol.enabled = false;
            }
        }
    }
       
}

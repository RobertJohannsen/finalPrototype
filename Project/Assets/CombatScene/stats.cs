using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{

    public int maxhp ,hp, maxap, currentap, agi , att, armor,acc , critmod ,coin;
    public bool hasInitiative , isDead;
    public GameObject[] bodyPart;
    public string name;

    void Start()
    {
        hp = maxhp;
        currentap = maxap;
    }

    void Update()
    {
        if(hp <= 0)
        {
            isDead = true;
        }
        else
        {
            isDead = false;
        }
    }


}

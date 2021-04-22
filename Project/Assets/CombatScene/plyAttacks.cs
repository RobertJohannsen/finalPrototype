using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class plyAttacks : MonoBehaviour
{
    public GameObject target, pointerUI, pointerUItext, attDisp, desDisp;
    public GameObject attQDisp, attQDispAd1, attQDispAd2;


    public enum attacks { none, attShoot, attMelee, attReload, attHeal };
    public enum attType { direct, heal, rest };
    public List<GameObject> where = new List<GameObject>();
    public List<attacks> attQ = new List<attacks>();
    public List<int> whereInd = new List<int>();

    public attType atType;

    public int ammo, apCost, baseDmg, index, basecrit, baseacc, attIndex, apCostTotal ,ammocost;
    public bool aimMode, selectAtt, beginAtt;
    public int whatPart, _apCost;
    public string _attDispText, _attDesText;
    public int _dmg, _ap;
    public float _critChance;
    public GameObject partDisp; //the object with the part display
    public string basedString, basedStringAd1, basedStringAd2;
    public enum AttState { none, selectPart, selectAtt };
    public AttState plyAttState;

    public combatLoop cLoop;

    public bool debounceAnger;


    public int attQLast, attQMax; //attQlast is the last index where an attack was submitted , attQMax is the maximum length of attQ based on MAXAP
    // Start is called before the first frame update
    public bool hasAmmo,triedToShoot;

    void Awake()
    {
        
    }
    void Start()
    {
        
        beginAtt = false;
        selectAtt = false;
        aimMode = false;
        attQMax = (int)this.GetComponentInParent<stats>().maxap / 4;

     
      





    }

    // Update is called once per frame
    void Update()
    {

        if(!debounceAnger)
        {
            if (cLoop.le.enemyLoaded)
            {
                target = cLoop.attackObj2;
                debounceAnger = true;
            }
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                beginAtt = !beginAtt;
            }

            UpdateAttQDisp();
            if (beginAtt)
            {

                AssignAttacks();
                unassignAttacks();
                UpdateDisp();
            }
            else
            {
                pointerUI.transform.position = new Vector3(99999, 9999, 99999); //aka fuck off

                //  attDisp.GetComponent<TextMeshPro>().text = _attDispText;
                //  desDisp.GetComponent<TextMeshPro>().text = _attDesText;

                _attDispText = "";
                _attDesText = "";
            }

            if (cLoop.combatPhase > 1)
            {
                pointerUI.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                pointerUItext.GetComponent<MeshRenderer>().enabled = false;
                partDisp.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                pointerUI.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                pointerUItext.GetComponent<MeshRenderer>().enabled = true;
                partDisp.GetComponent<MeshRenderer>().enabled = true;
            }

            if (cLoop.attackObj2.GetComponent<stats>().hp <= 0)
            {
                pointerUI.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                pointerUItext.GetComponent<MeshRenderer>().enabled = false;
                partDisp.GetComponent<MeshRenderer>().enabled = false;
            }

        }


    }

    void attShoot()
    {
        atType = attType.direct;
        baseDmg = 10;
        apCost = 2;
        baseacc = 20;
        basecrit = 80;

    }

    void attMelee()
    {
        atType = attType.direct;
        baseDmg = 5;
        apCost = 1;
        basecrit = 40;
    }


    void attReload()
    {
        apCost = 2;
        atType = attType.rest;
        // GetComponentInParent<stats>().currentap += 2;

    }

    void attHeal()
    {
        apCost = 5;
        atType = attType.heal;
    }

    public void loadAtt(int i)
    {
        //this need fixing
        switch (attQ[i])
        {
            case attacks.attShoot:
                attShoot();
                break;
            case attacks.attMelee:
                attMelee();
                break;
            case attacks.attReload:
                attReload();
                break;
            case attacks.attHeal:
                attHeal();
                break;

        }
    }

    void unassignAttacks()
    {
        if (attQLast > 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                switch (attQ[attQLast - 1])
                {
                    case attacks.attShoot:
                        attShoot();
                        break;
                    case attacks.attMelee:
                        attMelee();
                        break;
                    case attacks.attReload:
                        attReload();
                        break;

                }

                apCostTotal = Mathf.Clamp(apCostTotal - apCost, 0, 10000);

                attQ.RemoveAt(attQLast - 1);
                where.RemoveAt(attQLast - 1);
                whereInd.RemoveAt(attQLast - 1);

                attQLast = Mathf.Clamp(attQLast - 1, 0, 1000);




            }
        }
    }

    void AssignAttacks()
    {
        switch (plyAttState)
        {
            case AttState.selectAtt:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    submitAtt();
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    plyAttState = AttState.selectPart;
                }
                //submit attacks
                break;
            case AttState.selectPart:

                AimMode();
                //goto attmode press space to back to aim press esc

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    plyAttState = AttState.selectAtt;
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    plyAttState = AttState.none;
                }
                break;
            case AttState.none:
                //goto aimmode
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    plyAttState = AttState.selectPart;
                }

             

                break;

        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            if (plyAttState == AttState.selectAtt)
            {
                attIndex += 1;
            }

            if (plyAttState == AttState.selectPart)
            {
                whatPart += 1;
            }

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            if (plyAttState == AttState.selectAtt)
            {
                attIndex -= 1;
            }

            if (plyAttState == AttState.selectPart)
            {
                whatPart -= 1;
            }

        }

        attIndex = Mathf.Clamp(attIndex, 1, 4);
        whatPart = Mathf.Clamp(whatPart, 0, 7);





    }


    void submitAtt()
    {
        triedToShoot = false;
        //attacks are submitted here

     

        if (apCostTotal <= this.GetComponent<stats>().currentap)
        {

            if (attQLast != attQMax)
            {
                switch (attIndex)
                {

                    case 1:
                    
                        
                      
                            

                        if (ammo <= 0)
                        {
                            hasAmmo = false;
                        }
                        else
                        {
                            hasAmmo = true;

                            attQ.Add(attacks.attShoot);
                            attShoot();
                            _apCost = apCost; //I promise this will make sense
                            apCostTotal += apCost;
                            ammo--;
                        }

                        triedToShoot = true;

                        //   attQDisp[attQueueLength].GetComponent<TextMeshPro>().text = ">shoot";
                        break;
                    case 2:
                        attQ.Add(attacks.attMelee);
                        attMelee();
                        _apCost = apCost; //I promise this will make sense
                        apCostTotal += apCost;
                        //   attQDisp[attQueueLength].GetComponent<TextMeshPro>().text = ">melee";
                        break;
                    case 3:
                        attQ.Add(attacks.attReload);
                        attReload();
                        this.GetComponent<stats>().currentap = Mathf.Clamp(this.GetComponent<stats>().currentap + 5, 0, this.GetComponent<stats>().maxap + 4); //allow for a certain amount of overflow
                        _apCost = apCost; //I promise this will make sense
                        apCostTotal += apCost;
                        //   attQDisp[attQueueLength].GetComponent<TextMeshPro>().text = ">rest";
                        break;



                }

                if (!triedToShoot)
                {
                    where.Add(cLoop.attackObj2.GetComponent<stats>().bodyPart[whatPart]);
                    whereInd.Add(whatPart);
                    attQLast++;
                }
                else
                {
                    if(hasAmmo)
                    {
                        where.Add(cLoop.attackObj2.GetComponent<stats>().bodyPart[whatPart]);
                        whereInd.Add(whatPart);
                        attQLast++;
                    }
                }
             
            }


     


            if (apCostTotal >= this.GetComponent<stats>().currentap)
            {
                attQLast -= 1;
                attQ[attQLast] = attacks.none;
                apCostTotal -= _apCost;

                //reduce apcost back to thing because attack cant register

            }
        }
        else
        {
            //cant submit attacks
        }

        attQLast = Mathf.Clamp(attQLast, 0, attQMax); //remove this if there is a problem

    }
     

    void UpdateDisp()
    {

        switch (attIndex)
        {
            case 1:
                attShoot();
                _dmg = baseDmg;
                _ap = apCost;
                _critChance = Mathf.Clamp(((basecrit / 100) + 1) * (GetComponentInParent<stats>().critmod + 25), 0, 100);


                _attDispText = ">Shoot<";
                _attDesText = 
                    "Shoot the target \n"
                    +"AP cost : " + _ap+ "\n"
                    +"Damage : "+_dmg+"\n"
                    +"Crit Chance : "+_critChance+"%" ;
                break;   
            case 2:

                attMelee();
                _dmg = baseDmg;
                _ap = apCost;
                _critChance = Mathf.Clamp(((basecrit / 100) + 1) * (GetComponentInParent<stats>().critmod + 25), 0, 100);

                _attDispText = ">Melee<";
                _attDesText =
                   "Stab the target \n"
                   + "AP cost : " + _ap + "\n"
                   + "Damage : " + _dmg + "\n"
                   + "Crit Chance : " + _critChance + "%";
                break;
            case 3:

                attReload();
                _ap = apCost;
                _attDispText = ">Rest<";
                _attDesText =
                   "Rest to gain 2 AP\n"
                   + "AP cost : " + _ap
                  ;
                break;
            case 4:
                attHeal();
                _ap = apCost;
                _attDispText = ">Heal<";
                _attDesText =
                   "pop a pill and heal 5 HP\n"
                   + "AP cost : " + _ap
                  ;
                break;




        }
        attDisp.GetComponent<TextMeshPro>().text = _attDispText;
        desDisp.GetComponent<TextMeshPro>().text = _attDesText;


      
    }

    void AimMode()
    {
        int _accMod = GetComponentInParent<stats>().acc;


        pointerUI.transform.position = new Vector3(cLoop.attackObj2.GetComponent<stats>().bodyPart[whatPart].transform.position.x, cLoop.attackObj2.GetComponent<stats>().bodyPart[whatPart].transform.position.y, cLoop.attackObj2.GetComponent<stats>().bodyPart[whatPart].transform.position.z - 1);

        switch (cLoop.attackObj2.GetComponent<stats>().bodyPart[whatPart].tag)
        {
            case "head":
                baseacc = cLoop.attackObj2.GetComponent<stats>().bodyPart[whatPart].GetComponent<headBehaviour>().baseAcc;
                break;
            case "torso":
                baseacc = cLoop.attackObj2.GetComponent<stats>().bodyPart[whatPart].GetComponent<chestBehaviour>().baseAcc;
                break;
            case "arm":
                baseacc = cLoop.attackObj2.GetComponent<stats>().bodyPart[whatPart].GetComponent<armBehaviour>().baseAcc;
                break;
            case "leg":
                baseacc = cLoop.attackObj2.GetComponent<stats>().bodyPart[whatPart].GetComponent<legBehaviour>().baseAcc;
                break;
            case "hat":
                baseacc = cLoop.attackObj2.GetComponent<stats>().bodyPart[whatPart].GetComponent<hatBehaviour>().baseAcc;
                break;
            case "weapon":
                baseacc = cLoop.attackObj2.GetComponent<stats>().bodyPart[whatPart].GetComponent<weaponBehaviour>().baseAcc;
                break;
        }



        int _finalAcc = Mathf.Clamp((baseacc + (_accMod * 2)), 0, 100);
        partDisp.GetComponent<TextMeshPro>().text = "(" + cLoop.attackObj2.GetComponent<stats>().bodyPart[whatPart].name + ")";
        pointerUItext.GetComponent<TextMeshPro>().text = _finalAcc + "%";
    }


   void UpdateAttQDisp()
    {
 
        if(attQLast > 0)
        {
            if (attQLast < 4)
            {
                attQDisp.GetComponent<MeshRenderer>().enabled = true;
                attQDispAd1.GetComponent<MeshRenderer>().enabled = false;
                attQDispAd2.GetComponent<MeshRenderer>().enabled = false;

                for (int i = 0; i < attQLast; i++)
                {
                    switch (attQ[i])
                    {
                        case attacks.attShoot:
                            basedString = basedString + ">shoot (" + where[i].name + ")\n";
                            break;
                        case attacks.attMelee:
                            basedString = basedString + ">melee (" + where[i].name + ")\n";
                            break;
                        case attacks.attReload:
                            basedString = basedString + ">rest \n";
                            break;
                        case attacks.none:
                            break;
                    }
                }

                attQDisp.GetComponent<TextMeshPro>().text = basedString;
                basedString = "";

               
            }
            else
            {
                attQDispAd1.GetComponent<MeshRenderer>().enabled = true;
                attQDispAd2.GetComponent<MeshRenderer>().enabled = true;
                attQDisp.GetComponent<MeshRenderer>().enabled = false;

                for (int i = Mathf.Clamp(attQMax-5,0 ,100); i < attQLast; i++)
                    {
                    if(i <= 1)
                    {
                        switch (attQ[i])
                        {
                            case attacks.attShoot:
                                basedStringAd1 = basedStringAd1 + ">shoot (" + where[i].name + ")\n";
                                break;
                            case attacks.attMelee:
                                basedStringAd1 = basedStringAd1 + ">melee (" + where[i].name + ")\n";
                                break;
                            case attacks.attReload:
                                basedStringAd1 = basedStringAd1 + ">rest \n";
                                break;
                            case attacks.none:
                                break;
                        }
                    }
                    else
                    {
                        switch (attQ[i])
                        {
                            case attacks.attShoot:
                                basedStringAd2 = basedStringAd2 + ">shoot (" + where[i].name + ")\n";
                                break;
                            case attacks.attMelee:
                                basedStringAd2 = basedStringAd2 + ">melee (" + where[i].name + ")\n";
                                break;
                            case attacks.attReload:
                                basedStringAd2 = basedStringAd2 + ">rest \n";
                                break;
                            case attacks.none:
                                break;
                        }
                    }
                     
                    }

                    attQDispAd1.GetComponent<TextMeshPro>().text = basedStringAd1;
                    attQDispAd2.GetComponent<TextMeshPro>().text = basedStringAd2;

                    basedStringAd1 = "";
                    basedStringAd2 = "";

                  
                }
        }
        else
        {
            attQDispAd1.GetComponent<MeshRenderer>().enabled = false;
            attQDispAd2.GetComponent<MeshRenderer>().enabled = false;
            attQDisp.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeCanvCore : MonoBehaviour
{
    public GameObject[] lootObjs; //inside this is all the possible drop classes
    public int items;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void popFreeLoot(GameObject popTarg)
    {
        for (int k = 0; k < 3; k++)
        {
            popTarg.GetComponent<freeLootTable>().drops.Add(lootObjs[0]);
        }
    }
}

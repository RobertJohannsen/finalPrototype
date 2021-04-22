using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class arrowAnim : MonoBehaviour
{
    public int arrowStep, arrowCount, arrowThres;
    public TextMeshPro arrowText;
    // Start is called before the first frame update
    void Start()
    {
        arrowCount = 0;
        arrowThres = 10;
        arrowStep = 1;
    }

    // Update is called once per frame
    void Update()
    {
        arrowCount++;

        if(arrowCount > arrowThres)
        {
            arrowStep++;
                arrowCount = 0;
                if(arrowStep > 5)
            {
                arrowStep = 0;
            }
        }

        switch (arrowStep)
        {
            case 1:
                arrowText.text = ">";
                break;
            case 2:
                arrowText.text = ">>";
                break;
            case 3:
                arrowText.text = " >>";
                break;
            case 4:
                arrowText.text = "   >";
                break;
            case 5:
                arrowText.text = "   ";
                break;



        }
    }
}

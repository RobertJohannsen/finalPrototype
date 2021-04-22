using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlSetup : MonoBehaviour
{
    public enum lvlType { battle , shop , free , boss ,ezboss};
    public lvlType type;
    public int lvlDif , enemyroll;
    public SpriteRenderer sr;
    public Sprite[] decal;
    public bool isDone;
    public string enemyType;
    // Start is called before the first frame update
    void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        enemyroll = Random.Range(1, 4);
       
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case lvlType.battle:
                sr.sprite = decal[0];


                switch (enemyroll)
                {
                    case 1:
                        enemyType = "bloc-man";
                        break;
                    case 2:
                        enemyType = "speed-man";
                        break;
                    case 3:
                        enemyType = "tank-man";
                        break;


                }
                break;
            case lvlType.shop:
                sr.sprite = decal[3];
                sr.color = Color.green;
                break;
            case lvlType.free:
                sr.sprite = decal[1];
                sr.color = Color.cyan;
                break;
            case lvlType.boss:
                sr.sprite = decal[4];
                enemyType = "boss-man";
                sr.color = Color.red;
                break;
            case lvlType.ezboss:
                sr.sprite = decal[2];
                sr.color = Color.red;

                switch (enemyroll)
                {
                    case 1:
                        enemyType = "bloc-man";
                        break;
                    case 2:
                        enemyType = "speed-man";
                        break;
                    case 3:
                        enemyType = "tank-man";
                        break;


                }
                this.gameObject.transform.localScale = new Vector3(1.3f, 1.3f, 1);
                break;
        }
    }
}

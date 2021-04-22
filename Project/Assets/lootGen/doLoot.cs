using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doLoot : MonoBehaviour
{
    Rigidbody rb;
    Vector3 origin;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        origin = new Vector3(this.transform.position.x + Random.Range(-5f, 5f), this.transform.position.y, this.transform.position.z);
        rb = this.gameObject.GetComponent<Rigidbody>();

        rb.AddExplosionForce(350, origin, 10f , 20f);
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y == 0)
        {
            this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewShipSection : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.gameObject.tag);
        if (collision.transform.tag == "ShipHitBox")
        {
     
            //create a new shipsection, attach to nearest module
        }
    }
}

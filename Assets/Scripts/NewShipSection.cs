using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewShipSection : MonoBehaviour
{
    public TextMeshProUGUI text;

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
        text.text = collision.gameObject.tag;
        if (collision.transform.tag == "ShipHitBox")
        {
     
            text.text = "Collided2";
            //create a new shipsection, attach to nearest module
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pilot : MonoBehaviour 
{
    public float moveSpeed = 20f;
    public Rigidbody2D _shipRigidBody;
    private TextMeshProUGUI tooltiptext;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        
        _rigidBody = GetComponent<Rigidbody2D>();
        _shipRigidBody = GameObject.FindWithTag("Ship").GetComponent<Rigidbody2D>(); // this was necessary because GetComponentInParent was not working
    }
    // Start is called before the first frame update
    void Start()
    {
        tooltiptext = GetComponentInParent<TextMeshProUGUI>(); // attach the text component in the ship to the pilot, for game over usage
    }

    // Update is called once per frame
    void Update()
    {

    }

    // do rigidbody stuff
    private void LateUpdate()
    {

    }


    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal_Pilot");
        float verticalInput = Input.GetAxis("Vertical_Pilot");
        Vector2 force = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
        _rigidBody.velocity = force + _shipRigidBody.velocity; // drag pilot around with ship

        //transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
    }

    /* not working reliably at this time, will fix later (kill pilot if they leave ship)
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "ShipHitBox")
        {
            // tell the game manager
            Destroy(this.gameObject);
        }
        
    }
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if(collision.transform.tag != "Ship" || collision.transform.tag != "ShipHitBox")
        {
            //gameover, pilot has been hit by something
        }
        */
        if(collision.transform.tag == "Enemy1")
        {
            SceneManager.LoadScene(1); 
        }
    }


}

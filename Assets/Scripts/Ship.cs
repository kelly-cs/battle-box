using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float moveSpeed = 20f;
    private Rigidbody2D _rigidBody;
    //public GameObject[,] _shipSections = new GameObject[5, 5]; // Initialize a 2D array to keep track of ship sections. initialize center component.
    public GameObject shipSectionMainPrefab; // prefab for ship section
    public GameObject pilotPrefab; // prefab for pilot
    private BoxCollider2D _collider; 
    public TextMeshProUGUI text;
    public float toolTipTimerMax = 5f;
    public float turnspeed = 50f;
    private GameObject _shipSection;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        //_shipSections[2, 2] = Instantiate(shipSectionMainPrefab, new Vector3(0, 0, 0), Quaternion.identity); // create an initial ships section
        //_shipSections[2, 2].transform.parent = transform;
        _shipSection = Instantiate(shipSectionMainPrefab, new Vector3(0, 0, 0), Quaternion.identity); // create the shipsection and make Ship its parent.
        _shipSection.transform.parent = transform;
        //var main_section = _shipSections[2, 2].GetComponent<ShipSection>(); // get the main section created
        //main_section._xposition = 2;
        //main_section._yposition = 2;

        var pilot = Instantiate(pilotPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        pilot.transform.parent = transform;

        _collider = GetComponent<BoxCollider2D>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        float horizontalInput = Input.GetAxis("Horizontal_Ship");
        float verticalInput = Input.GetAxis("Vertical_Ship");
        float rotationInput = Input.GetAxis("Rotation_Ship");
        Vector2 force = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
        _rigidBody.velocity = force;
        transform.Rotate(0, 0, rotationInput * turnspeed * Time.deltaTime);

        transform.position = ClampPosition(transform.position);
        //transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
    }

    private Vector3 ClampPosition(Vector3 position)
    {
        float halfWidth = Camera.main.orthographicSize * Camera.main.aspect; 
        float halfHeight = Camera.main.orthographicSize;
        float halfShipSize = 1.2f; // this is half of the size of the ship, in unity units. if the ship is resized this will die
        Vector3 result = new Vector3();

        if (position.x - halfShipSize < -halfWidth)
        {
            result.x = -halfWidth + halfShipSize;
        }
        else if (position.x + halfShipSize > halfWidth)
        {
            result.x = halfWidth - halfShipSize;
        }
        else
        {
            result.x = position.x;
        }

        if (position.y - halfShipSize < -halfHeight)
        {
            result.y = -halfHeight + halfShipSize;
        }
        else if (position.y + halfShipSize > halfHeight)
        {
            result.y = halfHeight - halfShipSize;
        }
        else
        {
            result.y = position.y;
        }

        return result;
    }
    /*
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pilot")
            _shipSection.GetComponent<ShipSection>().regenWalls();   
    }
    */
}

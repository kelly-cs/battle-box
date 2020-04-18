using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float moveSpeed = 20f;
    private Rigidbody2D _rigidBody;
    public ShipSection[,] _shipSections; // Initialize a 2D array to keep track of ship sections. initialize center component.

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _shipSections[0, 0] = new ShipSection(0, 0); // create an initial ships section
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal_Ship");
        float verticalInput = Input.GetAxis("Vertical_Ship");
        Vector2 force = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
        _rigidBody.velocity = force;

        //transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
    }
}

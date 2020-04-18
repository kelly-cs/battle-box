using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float moveSpeed = 20f;
    private Rigidbody2D _rigidBody;
    public GameObject[,] _shipSections = new GameObject[5,5]; // Initialize a 2D array to keep track of ship sections. initialize center component.
    public GameObject shipSectionMainPrefab; // prefab for ship section
    public GameObject pilotPrefab; // prefab for pilot

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _shipSections[2, 2] = Instantiate(shipSectionMainPrefab, new Vector3(0,0,0), Quaternion.identity); // create an initial ships section
        _shipSections[2, 2].transform.parent = transform;
        var main_section = _shipSections[2, 2].GetComponent<ShipSection>(); // get the main section created
        main_section._xposition = 2;
        main_section._yposition = 2;

        var pilot = Instantiate(pilotPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        pilot.transform.parent = transform;
        var _pilotRigidBody = GetComponent<Rigidbody2D>();
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

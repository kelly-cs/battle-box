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
    public TextMeshProUGUI text;
    public float toolTipTimerMax = 5f;
    public float timer = 0f;
    public float turnspeed = 50f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        //_shipSections[2, 2] = Instantiate(shipSectionMainPrefab, new Vector3(0, 0, 0), Quaternion.identity); // create an initial ships section
        //_shipSections[2, 2].transform.parent = transform;
        Instantiate(shipSectionMainPrefab, new Vector3(0, 0, 0), Quaternion.identity).transform.parent = transform; // create the shipsection and make Ship its parent.

        //var main_section = _shipSections[2, 2].GetComponent<ShipSection>(); // get the main section created
        //main_section._xposition = 2;
        //main_section._yposition = 2;

        var pilot = Instantiate(pilotPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        pilot.transform.parent = transform;
        StartCoroutine(ShowToolTips());

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
        float rotationInput = Input.GetAxis("Rotation_Ship");
        Vector2 force = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
        _rigidBody.velocity = force;
        transform.Rotate(0, 0, rotationInput * turnspeed * Time.deltaTime);
        

        //transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
    }


    IEnumerator ShowToolTips()
    {
        
        yield return new WaitForSeconds(4);
        text.text = "WASDQE to Move Ship";
        yield return new WaitForSeconds(4);
        text.text = "";
        yield return new WaitForSeconds(4);
        text.text = "Arrow Keys to Move Pilot";
        yield return new WaitForSeconds(4);
        text.text = "";
        yield return new WaitForSeconds(4);
        text.text = "Move Pilot to Turrets to Activate";
        yield return new WaitForSeconds(4);
        text.text = "";
        yield return new WaitForSeconds(4);
        text.text = "Protect Your Pilot!";
        yield return new WaitForSeconds(4);
        text.text = "";
        yield break;
    }

}

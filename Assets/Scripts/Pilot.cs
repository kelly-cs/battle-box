using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : MonoBehaviour 
{
    public float moveSpeed = 200f;
    public Rigidbody2D _shipRigidBody;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    // do rigidbody stuff
    private void LateUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal_Pilot");
        float verticalInput = Input.GetAxis("Vertical_Pilot");
        Vector2 force = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
        _rigidBody.velocity = force + _shipRigidBody.velocity;

        //transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
    }
}

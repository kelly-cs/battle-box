using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float _force = 0.5f;
    public float _moveSpeed = 0.5f;
    private Rigidbody2D _rigidBody;
    private float health = 10f;
    private GameObject _pilot;
    // Start is called before the first frame update
    void Start()
    {
        _pilot = FindObjectOfType<Pilot>().gameObject;
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(this);
        }
        Vector3 direction = _pilot.transform.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        
        _rigidBody.AddForce(direction * _force);
        //transform.position = Vector3.MoveTowards(transform.position, _pilot.transform.position, _moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ShipHitBox")
        {
            health -= 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Colors color;
    private Color _unityColor;
    public float _force = 2f;
    public float _moveSpeed = 1f;
    private Rigidbody2D _rigidBody;
    private float health = 2f;
    private GameObject _pilot;
    // Start is called before the first frame update
    void Start()
    {
        var renderer = GetComponent<Renderer>();
        switch (color)
        {
            case Colors.red:
                _unityColor = Color.red;
                renderer.material.color = _unityColor;
                break;
            case Colors.blue:
                _unityColor = Color.blue;
                renderer.material.color = _unityColor;
                break;
            case Colors.green:
                _unityColor = Color.green;
                renderer.material.color = _unityColor;
                break;
            case Colors.yellow:
                _unityColor = Color.yellow;
                renderer.material.color = _unityColor;
                break;
        }
        _pilot = FindObjectOfType<Pilot>().gameObject;
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            // add animation later?
            GameManager.enemyDestroyed?.Invoke();
            Destroy(this.gameObject);
        }

    }

    private void FixedUpdate()
    {
        Vector3 direction = _pilot.transform.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward); // rotates the sprite appropriately so it's looking straight on

        _rigidBody.AddForce(direction * _force);
        //transform.position = Vector3.MoveTowards(transform.position, _pilot.transform.position, _moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* make enemy take damage as it rams into ship
        if (collision.transform.tag == "ShipHitBox")
        {
            health -= 1;
        } 
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "FriendlyBullet")
        {
            var bullet = collision.gameObject.GetComponent<FriendlyBullet>();
            
                if (bullet.color == _unityColor) // if the colors match 
                {
                    health -= bullet.damage;
                    Destroy(bullet.gameObject);
                }
                else
                {
                    Destroy(bullet.gameObject);
                }
            

        }
    }
}

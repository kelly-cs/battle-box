using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Colors { red,blue,green,yellow}

public class redturret : MonoBehaviour
{
    public Colors color;
    private int _numProjectiles = 1;
    private float _bulletForce = 350f;
    private float _damage = 1f;
    private float timer = 0.4f;
    private float _fireRate = 0.1f; // delay between shots, in seconds.
    private float _turnSpeed = 40f; // it'd be nicer to match this with speed of the ship, so it can be canceled out by the player
    public GameObject _bulletPrefab; // bullet to use by default

    // Start is called before the first frame update
    void Start()
    {
        var renderer = GetComponent<Renderer>();

        switch (color)
        {
            case Colors.red:
                renderer.material.color = Color.red;
                break;
            case Colors.blue:
                renderer.material.color = Color.blue;
                break;
            case Colors.green:
                renderer.material.color = Color.green;
                break;
            case Colors.yellow:
                renderer.material.color = Color.yellow;
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Rotate(0, 0, _turnSpeed * Time.deltaTime);
    }


    private void OnTriggerStay2D(Collider2D collider)
    {
        //Debug.Log(collider.transform.tag.ToString());
        if (collider.transform.tag == "Pilot")
        {
            if(timer > _fireRate)
            {
                Shoot();
                timer = 0;
            }
            //activate the turret
        }
    }

    private void Shoot()
    {
        //Debug.Log("Shooting!");
        var bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        // update the bullet's stats
        var bulletInfo = bullet.GetComponent<FriendlyBullet>();
        bulletInfo.damage = _damage; // set damage of bullet to damage of turret

        switch (color)
        {
            case Colors.red:
                bulletInfo.color = Color.red;
                break;
            case Colors.blue:
                bulletInfo.color = Color.blue;
                break;
            case Colors.green:
                bulletInfo.color = Color.green;
                break;
            case Colors.yellow:
                bulletInfo.color = Color.yellow;
                break;
        }
        

        // add force to the bullet
        var bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
        Vector2 force = transform.right * _bulletForce * Time.deltaTime;
        bulletRigidBody.velocity = force;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBullet : MonoBehaviour
{
    public float damage = 1f;
    public Color color;
    private float timer = 0f;
    private float bulletLiveTime = 2f;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        var renderer = GetComponent<Renderer>();
        renderer.material.color = color; // hopefully it is set by this point in the code.
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= bulletLiveTime)
        {
            Destroy(this.gameObject);
        }
    }
}

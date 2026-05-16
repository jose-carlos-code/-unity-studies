using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedFire = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speedFire, 0f); 
    }

    void Update()
    {
        Destroy(gameObject, 3.5f);
    }
}

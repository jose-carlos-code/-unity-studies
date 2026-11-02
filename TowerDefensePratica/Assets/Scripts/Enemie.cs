using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position += new Vector3(0f, -speed * Time.deltaTime, 0f);
    }

    void FixedUpdate()
    {
        
    }
}

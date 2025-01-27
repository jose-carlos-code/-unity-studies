using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeepController : MonoBehaviour
{
    private Rigidbody2D myRb;
    [SerializeField] private float speed = 5f;
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);
        move.Normalize();
        myRb.velocity = move * speed;
    }
}

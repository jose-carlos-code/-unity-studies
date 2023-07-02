using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeepController : MonoBehaviour
{
    private Rigidbody2D myRb;
    [SerializeField] private float speed = 5f;
    //limites do eixo y
    [SerializeField] private float limitYPositive = 1.77f;
    [SerializeField] private float limityNegative = -2.29f;
    //limites do eixto x
    [SerializeField] private float limitX = 6.77f;

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
        if (transform.position.y >= limitYPositive)
        {
            transform.position = new Vector3(transform.position.x, limitYPositive, 0f);
        }

        if (transform.position.y < limityNegative)
        {
            transform.position = new Vector3(transform.position.x, limityNegative, 0f);
        }

        if (transform.position.x > limitX)
        {
            transform.position = new Vector3(limitX, transform.position.y, 0f);
        }

        if (transform.position.x < -limitX)
        {
            transform.position = new Vector3(-limitX, transform.position.y, 0f);
        }
    }

}

   

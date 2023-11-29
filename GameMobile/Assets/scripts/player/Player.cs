using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    /*[SerializeField] private Rigidbody2D myRb;
    [SerializeField] private float speed = 5f;*/

    [SerializeField] private float xLimit = 1.62f;
    void Start()
    {
     /*   myRb = GetComponent<Rigidbody2D>();*/
    }

    void Update()
    {
        move();
    }

    private void move()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -4.23f);
        if(transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit, -4.23f, 0f);
        }

        if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit, -4.23f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")    
        {
            Destroy(gameObject);
        }
    }
}

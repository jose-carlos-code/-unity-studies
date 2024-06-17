using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRB;
    [SerializeField] private float speed = 2f;
    [SerializeField] private int amountJump = 2;
    [SerializeField] private int speedY = 6;
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();

    }

   
    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move, 0f, 0f) * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
       
    }

    private void Jump()
    {
        var jump = Input.GetKeyDown(KeyCode.Space);
        if(jump && amountJump > 0)
        {
            myRB.velocity = new Vector2(myRB.velocity.x, speedY);
            amountJump--;
        }
    }
}
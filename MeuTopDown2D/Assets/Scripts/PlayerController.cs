using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRB;
    [SerializeField] private float speed = 15f;
    [SerializeField] private Vector2 move;
    [SerializeField] private Animator playerAnimator;
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        myRB.MovePosition(myRB.position + move * speed * Time.fixedDeltaTime);
        if(move.x != 0 || move.y != 0)
        {
            playerAnimator.SetBool("walk", true);
        }
        if(move.x == 0)
        {
            playerAnimator.SetBool("walk", false);
        }
        
        Flip();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertial = Input.GetAxis("Vertical");
        move = new Vector2(horizontal, vertial); 
           
    }

    private void Flip()
    {
        if(move.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
            if(move.x < 0)
            {
                transform.eulerAngles = new Vector2(0f, 180f);
            }
    }
}

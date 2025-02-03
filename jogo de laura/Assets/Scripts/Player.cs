using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speedJump = 5f;
    private bool onGround = true;
    [SerializeField]
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    void Update()
    {
        if (onGround)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.up * speedJump;
                anim.SetBool("isJump", true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
            anim.SetBool("isJump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemie")
        {
            Destroy(gameObject);
        }
    }
}

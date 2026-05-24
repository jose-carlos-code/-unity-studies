using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedFire = 10f;
    public float projectileDamage = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speedFire, 0f); 
    }

    void Update()
    {
        //Destroy(gameObject, 3.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemie") || (collision.CompareTag("Player") && collision.GetComponent<PlayerMovement>().isPlayer == true))
        {
            collision.GetComponent<EntityStaps>().RemoveHp(projectileDamage);
             Destroy(gameObject);           
        }
    }

   
}


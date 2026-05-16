using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieBehavior : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    EntityStaps EnemieStaps;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        EnemieStaps = GetComponent<EntityStaps>();
         
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Fire1"))
        {
            EnemieStaps.hp -= 20;
            //Destroy(gameObject); 
        }
    }
}

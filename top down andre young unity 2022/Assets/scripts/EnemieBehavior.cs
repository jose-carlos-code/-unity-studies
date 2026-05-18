using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieBehavior : MonoBehaviour
{
    public float move_speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject player_object;
    EntityStaps EnemieStaps;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        EnemieStaps = GetComponent<EntityStaps>();
        player_object = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
      
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire1"))
        {
            EnemieStaps.hp -= 20;
            
        }

        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player_object.transform.position, move_speed
            * Time.deltaTime);
    }
}

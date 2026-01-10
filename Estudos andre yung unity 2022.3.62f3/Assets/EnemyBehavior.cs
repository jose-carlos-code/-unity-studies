using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    GameObject player_object;

    EntityStats entityStats;

    public float moveSpeed = 2.0f;

    void Start()
    {
        entityStats = gameObject.GetComponent<EntityStats>();
        player_object = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player_object)
        {
            // funcão para o objeto inimigo seguir o jogador
            transform.position = Vector3.MoveTowards(transform.position, 
            player_object.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<EntityStats>().hp -= entityStats.attack_damage;
            entityStats.hp -= entityStats.max_hp + 1;
        }
    }
}

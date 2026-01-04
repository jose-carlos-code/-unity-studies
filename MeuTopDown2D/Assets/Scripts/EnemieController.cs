using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemieController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] protected float chaseSpeed = 3f; // Velocidade de perseguição do inimigo

    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float speed = 15f;
    [SerializeField] private float attackRange = 1f; // Distância para parar e atacar (unidades)

    private Animator animator;

    [Header("Detection")]
    [SerializeField] private float detectionRange = 5f; // Raio de detecção (radius do collider * escala)

    private Transform player;  // Referência ao player
    private bool isChasing = false; // Indica se o inimigo está perseguindo o player
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Ajusta o radius do DetectionCollider para o detectionRange (assumindo escala 1 unit = 1m)
        GetComponentInChildren<CircleCollider2D>().radius = detectionRange;
    }

    void Update()
    {
        if(player != null && isChasing)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            float distance = Vector2.Distance(transform.position, player.position);

            if(distance <= attackRange)
            {
                rb.velocity = Vector2.zero;
                Attack();
            }
            else
            {
                //rb.velocity = direction * chaseSpeed;
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
            isChasing = false;
            rb.velocity = Vector2.zero;

        }
    }

    private void Attack()
    {
        animator.SetBool("attack", true);
    }
}

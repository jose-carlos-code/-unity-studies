using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] protected float chaseSpeed = 3f; // Velocidade de perseguição do inimigo
    [SerializeField] private float patrolSpeed = 2f; // Velocidade de patrulha do inimigo

    [SerializeField] private Transform[] patrolPoints; // Ponto de patrulha para o inimigo
    private int currenPatrolIndex = 0; // Índice do ponto de patrulha atual

    private Vector2 move; 

    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    [SerializeField] private float attackRange = 3f; // Distância para parar e atacar (unidades)

    [SerializeField] private Animator animator;

    [Header("Detection")]
    [SerializeField] private float detectionRange = 10f; // Raio de detecção (radius do collider * escala)

    [SerializeField] private Transform player;  // Referência ao player
    private bool isChasing = false; // Indica se o inimigo está perseguindo o player
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Ajusta o radius do DetectionCollider para o detectionRange (assumindo escala 1 unit = 1m)
        GetComponent<CircleCollider2D>().radius = detectionRange;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(player != null && isChasing)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            float distance = Vector2.Distance(transform.position, player.position);

            if(distance - attackRange <= 0)
            {
                rb.velocity = Vector2.zero;
                Attack();
            }
            else
            {
                rb.velocity = direction * chaseSpeed;
                Flip(direction);//kkdd
            }
        }
        else
        {

            Patrol();
        }

    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform target = patrolPoints[currenPatrolIndex];
        //float distance = Vector2.Distance(transform.position, target.position);
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * patrolSpeed;
        animator.SetBool("move", true);
        Flip(direction);

        if(Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            currenPatrolIndex = (currenPatrolIndex + 1) % patrolPoints.Length; // Move para o próximo ponto de patrulha
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
            //rb.velocity = Vector2.zero;

        }
    }

    private void Attack()
    {
        animator.SetTrigger("attack");
    }

    private void Flip(Vector2 direction)
    {
        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        else if (direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }
}

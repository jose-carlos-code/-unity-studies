using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// essa parte abaixo diz: casao não exista um animator, a unity adiciona pra mim
[RequireComponent(typeof(Animator))]
public class EnemieController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] protected float chaseSpeed = 3f; // Velocidade de perseguição do inimigo
    [SerializeField] private float patrolSpeed = 2f; // Velocidade de patrulha do inimigo

    [SerializeField] private Transform[] patrolPoints; // Ponto de patrulha para o inimigo
    private int currenPatrolIndex = 0; // índice do ponto de patrulha atual

    private Vector2 move; 

    [SerializeField] protected Rigidbody2D rb;
    [Header("Attributes")]
    [SerializeField] protected float speed;
    private float attackCooldown = 0.17f;
    [SerializeField] private int hp = 10;
    [SerializeField] private float attackRange = 1f; // Distância para parar e atacar (unidades)

    [SerializeField] private Animator animator;

    [Header("Detection")]
    [SerializeField] private float detectionRange = 30f; // Raio de detecção (radius do collider * escala)

    [SerializeField] private Transform player;  // Referência ao player
    private bool isChasing = false; // Indica se o inimigo esta perseguindo o player

    private bool isAttacking; // indica se o inimigo está atacando

    GameController gameController;
    void Start()
    {
        gameController = GameObject.FindFirstObjectByType<GameController>();
        rb = GetComponent<Rigidbody2D>();
        // Ajusta o radius do DetectionCollider para o detectionRange (assumindo escala 1 unit = 1m)
        GetComponent<CircleCollider2D>().radius = detectionRange;
        animator = GetComponent<Animator>();
    }


    void Update()
    {
       

    }

    void FixedUpdate()
    {
        if(gameController.level < 2)
        {
            if(player != null && isChasing)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                float distance = Vector2.Distance(transform.position, player.position);

                if(distance - attackRange <= 0)
                {
                    rb.velocity = Vector2.zero;
                    isAttacking = true;
                    if (isAttacking)
                    {
                        StartCoroutine(AttackRoutine());
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 
                    patrolSpeed * Time.deltaTime);
                    Flip(direction);
                }
            }
            else
            {

                Patrol();
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, patrolSpeed * Time.deltaTime);
        }
    }

    IEnumerator AttackRoutine()
    {
        Debug.Log("Disparou trigger attack");
        animator.SetTrigger("attack");
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }


    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform target = patrolPoints[currenPatrolIndex];
        //float distance = Vector2.Distance(transform.position, target.position);
        Vector2 direction = (target.position - transform.position).normalized;
        Flip(direction);
        animator.SetBool("move", true);
        // rb.velocity = direction * patrolSpeed;
        transform.position = Vector3.MoveTowards(transform.position, target.position, patrolSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            currenPatrolIndex = (currenPatrolIndex + 1) % patrolPoints.Length; // Move para o proximo ponto de patrulha
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

    public void TaskDamage(int damage)
    {
        hp -= damage;
        Death();
    }

    private void Death()
    {
        if(this.hp <= 0)
        {
            gameController.AddExp(15);
            Destroy(gameObject);
        }
    }
}
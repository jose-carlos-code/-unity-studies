using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// essa parte abaixo diz: casao não exista um animator, a unity adiciona pra mim
[RequireComponent(typeof(Animator))]
public class EnemieController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] protected float chaseSpeed = 3f; // Velocidade de perseguição do inimigo
    // [SerializeField] private float patrolSpeed = 2f; // Velocidade de patrulha do inimigo

    // [SerializeField] private Transform[] patrolPoints; // Ponto de patrulha para o inimigo
    // private int currenPatrolIndex = 0; // índice do ponto de patrulha atual

    private Vector2 move; 

    [SerializeField] protected Rigidbody2D rb;
    [Header("Attributes")]
    [SerializeField] protected float speed;
    private float attackCooldown = 0.17f;
    [SerializeField] private int hp = 10;
    [SerializeField] private float attackRange = 1f; // Distância para parar e atacar (unidades)

    [SerializeField] private Animator animator;

    [Header("Detection")]
    // [SerializeField] private float avoidRayDistance  = 20f; // Raio de detecção (radius do collider * escala)
    // [SerializeField] private float fieldOfViewAngle = 90f; // graus, total (45 pra cada lado)
    [SerializeField] private LayerMask obstacleMask; // Layer do obstáculo

    [SerializeField] private Transform player;  // Referência ao player
    private bool isChasing = true; // Indica se o inimigo esta perseguindo o player

    RaycastHit2D hit;

    private bool isAttacking; // indica se o inimigo está atacando

    GameController gameController;
    void Start()
    {
        gameController = GameObject.FindFirstObjectByType<GameController>();
        rb = GetComponent<Rigidbody2D>();
        // Ajusta o radius do DetectionCollider para o detectionRange (assumindo escala 1 unit = 1m)
        //GetComponent<CircleCollider2D>().radius = detectionRange;
        animator = GetComponent<Animator>();
    }


    void Update()
    {
       
      
    }

    void FixedUpdate()
    {
        GameObject playerReference = GameObject.FindGameObjectWithTag("Player");
        if(gameController.level < 2)
        {
            if(playerReference != null && isChasing)
            {   
                // Vector2 direction = GetMoveDirection();
                Vector2 direction = (playerReference.transform.position - transform.position).normalized;
                transform.position = Vector3.MoveTowards(transform.position, playerReference.transform.position, speed * Time.deltaTime);
                animator.SetBool("move", true);
                Flip(direction);
                float distance = Vector2.Distance(transform.position, playerReference.transform.position);
                // float distance = direction.magnitude;
                // hit = Physics2D.Raycast(transform.position, direction, distance, obstacleMask);
                if (distance - attackRange <= 0)
                {
                    rb.velocity = Vector2.zero;
                if (!isAttacking)
                {
                    isAttacking = true;
                    StartCoroutine(AttackRoutine());
                }
                }
            }

        }
    }

    IEnumerator AttackRoutine()
    {
        animator.SetTrigger("attack");
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
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
        StartCoroutine(DeathCouroine());
    }

    private void Death()
    {
        if(this.hp <= 0)
        {
            gameController.AddExp(15);
            GenearteEnemiesController generator = GetComponent<GenearteEnemiesController>();
            GenearteEnemiesController.Instance.DecreaseMonsters();
            Destroy(gameObject);
        }
    }

    IEnumerator DeathCouroine()
    {
        animator.SetBool("death", true);
        yield return new WaitForSeconds(0.5f);
        Death();
    }

    private Vector2 RotateVector(Vector2 vector, float degrees)
    {
        float rad = degrees * Mathf.Deg2Rad;
        float cos = Mathf.Cos(rad);
        float sin = Mathf.Sin(rad);
        return new Vector2(
            vector.x * cos - vector.y * sin,
            vector.x * sin + vector.y * cos
        );
    }
}
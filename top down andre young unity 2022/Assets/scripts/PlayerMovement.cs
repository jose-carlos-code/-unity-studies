using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject fire1;
    //[SerializeField] private float baseSpeed = 5f;
 
    public Transform postionFire1;
    public EntityStaps entity_stats;
    public float coolDown_;
    bool canAttack;

    void Start()
    {
        entity_stats = gameObject.GetComponent<EntityStaps>();
    }
    void Update()
    {
        Fire();
        Cooldown();
    }

    private void FixedUpdate()
    {
        MoveWASD();
        if(Input.GetKeyDown(KeyCode.G))
        {
            InvontoryManager.instance.DiscardWeapon();
        }
    }

    void MoveWASD()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(horizontal, vertical, 0f).normalized;
        transform.position += move * entity_stats.speed * Time.fixedDeltaTime;
    }

    void Fire()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && canAttack) 
        {
            Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject fireInstance = Instantiate(fire1, postionFire1.position, Quaternion.identity);
            fireInstance.GetComponent<FireController>().speedFire = entity_stats.attack_range;
            // aumentando em porcentagem (5%)
            fireInstance.GetComponent<FireController>().projectileDamage = entity_stats.attack_damage * ((entity_stats.bonus_attack + 100) / 100) ;
            fireInstance.GetComponent<FireController>().projectTileLifeSpan = entity_stats.attack_life;

            Rigidbody2D fireInstanceRb = fireInstance.GetComponent<Rigidbody2D>();
            fireInstance.GetComponent<FireController>().isPlayerProjectile = true; // ← marca que foi o player que atirou
            Vector2 mouseDirection = MouseDirection();
            fireInstanceRb.GetComponent<Rigidbody2D>().velocity = mouseDirection * entity_stats.attack_range;
            canAttack = false;
            coolDown_ = 0;
        }
    }

    private Vector2 MouseDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        direction.Normalize();
        return direction;
    }

    private void Cooldown()
    {
        if (coolDown_ > (entity_stats.attack_speed * ((100 - entity_stats.bonus_atkspeed) / 100)) && canAttack == false)
        {
            canAttack = true;
        }
        else
        {
            coolDown_ += Time.deltaTime;
        }
    }
}

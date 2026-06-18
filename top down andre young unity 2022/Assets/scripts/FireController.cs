using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedFire = 2f;
    public float projectileDamage = 5f;
    public bool isPlayerProjectile = false; 
    public float projectTileLifeSpan = 3.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (isPlayerProjectile)
        {
            rb.velocity = new Vector2((isPlayerProjectile ? -speedFire : speedFire), 0f); 

        }
    }

    void Update()
    {
        Destroy(gameObject, projectTileLifeSpan);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlayerProjectile && collision.CompareTag("Enemie"))
        {
            collision.GetComponent<EntityStaps>()?.RemoveHp(projectileDamage);
            Destroy(gameObject);
        }
        else if (!isPlayerProjectile && collision.CompareTag("Player"))
        {
            collision.GetComponent<EntityStaps>()?.RemoveHp(projectileDamage);
            Destroy(gameObject);
        }else if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }


}


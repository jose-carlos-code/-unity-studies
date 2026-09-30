using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : MonoBehaviour
{
    public float projectTileDamage;
    public Transform target_;
    [SerializeField] private bool is_canon = false;
    [SerializeField] private float project_radius = 0;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(target_ == null)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, target_.position, 4 * Time.deltaTime);
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyMovement>().TakeDamage(projectTileDamage);
            if(is_canon == true)
            {
                // Cria um array que recebe um circulo que vai colidir numa certa área
                Collider2D[] explosion_objects = Physics2D.OverlapCircleAll(transform.position, project_radius);
                foreach (Collider2D exp_obj in explosion_objects)
                {
                    if(exp_obj.gameObject.tag == "Enemy")
                    {
                        exp_obj.gameObject.GetComponent<EnemyMovement>().TakeDamage(projectTileDamage);
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}

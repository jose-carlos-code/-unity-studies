using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : MonoBehaviour
{
    public float projectTileDamage;
    public Transform target_;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target_.position, 4 * Time.deltaTime);
        if(target_ == null)
        {
            Destroy(gameObject);
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyMovement>().TakeDamage(projectTileDamage);
            Destroy(gameObject);
        }
    }
}

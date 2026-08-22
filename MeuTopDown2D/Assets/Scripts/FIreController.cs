using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIreController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public int gunDamage;
    void Start()
    {
       
    }

    void Update()
    {
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemieController>().TaskDamage(gunDamage);
        }
    }
}

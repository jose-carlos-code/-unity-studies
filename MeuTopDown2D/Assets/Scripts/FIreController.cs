using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIreController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
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
    }
}

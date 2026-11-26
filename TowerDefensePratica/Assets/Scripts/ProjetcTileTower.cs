using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjetcTileTower : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    public Transform target;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!target)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}

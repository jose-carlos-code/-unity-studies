using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float speed = 15f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void Move()
    {
        
    }
}

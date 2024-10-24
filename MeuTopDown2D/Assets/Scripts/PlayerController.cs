using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRB;
    [SerializeField] private float speed = 13f;
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertial = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertial); 
        myRB.MovePosition(myRB.position + move * speed * Time.deltaTime);   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    /*[SerializeField] private Rigidbody2D myRb;
    [SerializeField] private float speed = 5f;*/
    void Start()
    {
     /*   myRb = GetComponent<Rigidbody2D>();*/
    }

    void Update()
    {
        move();
    }

    private void move()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -4.23f);
  
    }
}

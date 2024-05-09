using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRB;
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        
    }

    private void Move()
    {
      
    }
}

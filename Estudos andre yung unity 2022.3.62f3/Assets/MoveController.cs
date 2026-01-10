using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public EntityStats entityStats;

    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;


    void Start()
    {
        entityStats = gameObject.GetComponent<EntityStats>();

        moveSpeed = entityStats.base_speed;


    }

   
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(moveX * baseSpeed, moveY * baseSpeed));
        gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(moveX * entityStats.base_speed, 
            moveY * entityStats.base_speed));
        if ((moveX > 0 || moveX < 0 ) && (moveY > 0 || moveY < 0))
        {
            moveSpeed = entityStats.base_speed * 0.66f;
        }
        else
        {
            moveSpeed = entityStats.base_speed;
        }
    }
}

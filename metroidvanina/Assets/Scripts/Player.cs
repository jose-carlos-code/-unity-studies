using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float maxSpeed;
    [SerializeField] float speed;
    private Rigidbody2D rb;

    [SerializeField] bool facingRight = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = maxSpeed;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //GetAxisRaw não pega a acelaração, já vai logo para o valor máximo
        float h = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(h * speed, rb.velocity.y);
        if(h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        // pegando o atributo scale do meu component Player
        Vector3 scale = transform.localScale;
        // invertendo a escala(scale) do meu component Player
        scale.x *= -1;
        transform.localScale = scale;
    }
}

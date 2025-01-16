using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float maxSpeed;
    [SerializeField] Transform groundCheck;
    [SerializeField] float jumpForce;
    [SerializeField] float speed;
    private Rigidbody2D rb;
    private bool onGround;
    private bool doubleJump;
    private bool jump = false;

    [SerializeField] bool facingRight = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = maxSpeed;
    }

    void Update()
    {
        onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (onGround)
        {
            doubleJump = false;
        }

        if(Input.GetButtonDown("Jump") && (onGround || !doubleJump))
        {
            jump = true;
            if(!onGround && !doubleJump)
            {
                doubleJump = true;
            }

        }
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

        if (jump)
        {
            //zerando a velocidade do player antes pulo
            // porque segundo o professo, assim fica melhor
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
            jump = false;
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

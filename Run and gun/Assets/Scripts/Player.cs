using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    public float jumpForce = 600;

    private Animator anim;
    private bool crouched;
    private bool lookingUp;
    private bool reloading;
    private Rigidbody2D rb2d;
    private bool facinRight = true;
    private bool jump;
    private bool onGround = false;
    private Transform groundCheck;
    private float hForce = 0f;
    /*[SerializeField] private Animator myAnim;*/

    private bool isDead = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //encontrando o transform do objeto filho groundcheck
        groundCheck = gameObject.transform.Find("GroundCheck");
        /* myAnim = GetComponent<Animator>();*/
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead)
        {
            //criando uma linha que vai do player até o GroundCheck, na layer ground
            onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
            //se o player colidir com o chão, o parâmetro Jump será falso
            if (onGround)
            {
                anim.SetBool("Jump", false);
            }
            if (Input.GetButtonDown("Jump") && onGround && !reloading)
            {
                jump = true;
            }
        
            else if (Input.GetButtonUp("Jump"))
            {
                //fazendo que quando eu solte a barra de espaço, o pulo perca a intensidade
                if(rb2d.velocity.y > 0)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
                }
            }
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("Shoot");
            }

            lookingUp = Input.GetButton("Up");
            crouched = Input.GetButton("Down");
            anim.SetBool("LookingUp", lookingUp);
            anim.SetBool("Crounched", crouched);
            if(Input.GetButtonDown("Reloading"))
            {
                anim.SetBool("Reloading", true);
            }

        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            if(rb2d.velocity.x == 0)
            {
               
            }
            hForce = Input.GetAxisRaw("Horizontal");
            rb2d.velocity = new Vector2(hForce * speed, rb2d.velocity.y);
            if (hForce > 0 && !facinRight)
            {
                Flip();
            }
            else if (hForce < 0 && facinRight)
            {
                Flip();
            }
            if (jump)
            {
                anim.SetBool("Jump", false);
                jump = false;
                //adicionando uma força no ridbody2d
                rb2d.AddForce(Vector2.up * jumpForce);
            }
            if(hForce != 0)
            {
               
            }
        }
    }

    void Flip()
    {
        facinRight = !facinRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        
    }
}

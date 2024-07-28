using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float initialSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private Rigidbody2D myRB;
    private Animator playerAnimator;
    private float horizontal;
    private float vertical;
    private Vector2 move;
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        initialSpeed = speed;
    }

    // comentário de teste
    void Update()
    {
        this.horizontal = Input.GetAxis("Horizontal");
        this.vertical = Input.GetAxis("Vertical");
        // uma forma de se fazer o personagem andar
        /* transform.position += new Vector3(horizontal, vertical, 0f) * speed * Time.deltaTime;*/
        PlayerRun();
    }

    void FixedUpdate()
    {
        move = new Vector2 (horizontal, vertical);
        if(move.sqrMagnitude  > 0)
        {
            playerAnimator.SetInteger("Movimento", 1);
        }
        else
        {
            playerAnimator.SetInteger("Movimento", 0);
        }
        /*   move.Normalize();*/
        //mais outra forma de se fazer o personagem andar
        /*myRB.velocity = move * speed;*/
        // a forma a seguir foi a utilizada pelo professor
        //fixedDeltaTime -> valor fixo
        myRB.MovePosition(myRB.position + move * speed * Time.fixedDeltaTime);
        Flip();
    }

    void Flip()
    {
        if (move.x > 0) 
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        if(move.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }

    private void PlayerRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
        }
    }
}

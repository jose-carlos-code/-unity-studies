using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] Rigidbody2D myRb;
    private Animator myAnim;
    private bool isJump = true;
    [SerializeField] private int amountJump = 1;
    /*[SerializeField] private int totalJump = 1;*/
    [SerializeField] private float speedY = 6f; 
    void Start()
    {
        //pegando o meu Rigidboy2D
        myRb = GetComponent<Rigidbody2D>();

        //pegando o meu Animator
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        /*Fazendo com que o player olhe para a direita ou para a esquerda*/
        if (moveX < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (moveX > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        transform.position += new Vector3(moveX, 0f, 0f) * speed * Time.deltaTime;

        /*jeito do none de fazer o player olhar para esquerda ou para a direita*/

        //retorna 1 se o valor for positivo, ou retorna 0 e -1 se o valor for negativo
        /*transform.localScale = new Vector3(Mathf.Sign(moveX), 1f ,1f); */

        //EU ESTOU ME MOVENDO, ENTÃO EU POSSO MUDAR A ANIMAÇÃO
      /*  myAnim.SetBool("Movement", true);*/
        myAnim.SetBool("Fall", false);

        //TEM ESSE JEITO DE FAZER

        /* if(moveX == 0)
         {
             myAnim.SetBool("Movement", false);
         }*/

        //MAS TEM TAMBÉM TEM ESSE OUTRO JEITO

        myAnim.SetBool("Movement", moveX != 0);
    }

    private void Jump()
    {
        if (isJump && amountJump > 0)
        {
             if (Input.GetKeyDown(KeyCode.Space))
             {
                myRb.velocity = new Vector2(myRb.velocity.x, speedY);
                myAnim.SetBool("Jumping", true);
                amountJump--;
             }
        }  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            myAnim.SetBool("Jumping", false);
            myAnim.SetBool("Fall", true);
            isJump = true;
            this.amountJump = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] Rigidbody2D myRb;
    private Animator myAnim;
    [SerializeField] private int amountJump;
    private BoxCollider2D boxCol;
    /*[SerializeField] private int totalJump = 1;*/
    [SerializeField] private float speedY = 6f; 

    //elementos do raycast
    [SerializeField] private LayerMask layerLevel;
    void Start()
    {
        //pegando o meu Rigidboy2D
        myRb = GetComponent<Rigidbody2D>();

        //pegando o meu Animator
        myAnim = GetComponent<Animator>();

        //pegando meu BoxCollider2D
        boxCol = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void FixedUpdate()
    {
        myAnim.SetBool("Fall", IsGrounded());

        //se eu toquei no chão, eu reseto os pulos
        if (IsGrounded())
        {
            amountJump = 1;
        }
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

        //EU ESTOU ME MOVENDO, ENT�O EU POSSO MUDAR A ANIMA��O
      /*  myAnim.SetBool("Movement", true);*/

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
        var jump = Input.GetKeyDown(KeyCode.Space);

        //definindo o par�metro do Speedv com base na velocidade y do myRb 
        myAnim.SetFloat("SpeedV", myRb.velocity.y);
        if (jump && amountJump > 0)
        {
            myRb.velocity = new Vector2(myRb.velocity.x, speedY);
            amountJump--;

            //avisando que eu não estou no chão
            myAnim.SetBool("Fall", false);
        }  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            /*this.amountJump = 1;*/
           /* myAnim.SetBool("Fall", true);*/
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            /*myAnim.SetBool("Fall", false);*/
        }
    }

    //JEITO IDEAL DE FAZER COLISÃO
    //RAYCAST -> linha que aponta para algum lugar 
    //quando ela colide com alguma coisa, ela nos dá uma informação

    //Raycast de colisão no chão
    private bool IsGrounded()
    {
        //criar o meu raycast       //pegando os limites do meu colisor partindo do centro, direção da linha, distância, layer que o raycast vai colidir
        bool ground = Physics2D.Raycast(boxCol.bounds.center, Vector2.down, .6f, layerLevel);

        /*Color cor;*/

        return ground;
            /* cor = Color.red;*/
     

        //fazer o debug da linha na proxima aula
        /*Debug.DrawRay(boxCol.bounds.center, Vector2.down * 0.5f, cor);
        return false;*/
    }
}

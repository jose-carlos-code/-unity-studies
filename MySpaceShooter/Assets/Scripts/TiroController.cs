using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    private Rigidbody2D meuRB;
    //[SerializeField] private float velocidade = 10f;
    [SerializeField] private GameObject impacto;

    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
        //meuRB.velocity = new Vector2(0f, velocidade);
        /*teste*/
        //teste do commit
   
    }
    
    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.CompareTag("Inimigo") || collision.CompareTag("Boss"))
            {
                /*pegando o elemento script da classe inimigoController e 
                 * o método perdeVida*/
                collision.GetComponent<InimigoPai>().perdeVida(1);

            }
        
            if (collision.CompareTag("Player"))
            {
            /*pegando o elemento script da classe inimigoController e 
             * o método perdeVida*/
            collision.GetComponent<PlayerController>().perdeVida(1);
            }
            Destroy(gameObject);

            //criando o impacto
            Instantiate(impacto, transform.position,transform.rotation);

    }
        
}

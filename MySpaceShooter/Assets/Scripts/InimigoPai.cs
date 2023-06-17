using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    //atributos que todo inimigo tem que ter
    [SerializeField] protected float velocidade;//a classe pai e os filhos têm acesso a esse atributo
    [SerializeField] protected int vidaInimigo; 
    [SerializeField] protected GameObject explosao;
    [SerializeField] protected int pontos = 10;
    [SerializeField] protected GameObject powerUp;
    [SerializeField] protected int tipoInimigo;
    [SerializeField] protected float itemRate;
    [SerializeField] protected float esperaTiro = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //criando o método perdeVida

    public void perdeVida(int dano)
    {
        if(transform.position.y < 5)
        {
            vidaInimigo -= dano;
            if (vidaInimigo <= 0)
            {
                Destroy(gameObject);
                Instantiate(explosao, transform.position, transform.rotation);
                if (this.powerUp)
                {
                    dropaPowerUp(this.tipoInimigo);
                }
                //ganhando pontos
                var gerador = FindObjectOfType<GeradorInimigos>();
                //gerador.DiminuiQuantidade();
                if (gerador)
                {
                    gerador.GanhandoPontos(this.pontos);
                }
            }

        }
    }

    //quando o gameObject for destruído
    private void OnDestroy()
    {
        var gerador = FindObjectOfType<GeradorInimigos>();
        //só executa se o gerador existe
        if (gerador)
        {
            gerador.DiminuiQuantidade();

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destruidor"))
        {
            Destroy(gameObject);
            Instantiate(explosao, transform.position, transform.rotation);
            /*var gerador = FindObjectOfType<GeradorInimigos>();
            gerador.DiminuiQuantidade();*/
        }
    }   

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(explosao, transform.position, transform.rotation);
            Destroy(gameObject);
            dropaPowerUp(this.tipoInimigo);

           /* var gerador = FindObjectOfType<GeradorInimigos>();
            gerador.DiminuiQuantidade();*/

            //fazendo o player perder vida
            other.gameObject.GetComponent<PlayerController>().perdeVida(1);
        }
    }

    private void dropaPowerUp(int tipoInimigo)
    {
        float chance = Random.Range(0f, 1f);
        if(chance > itemRate)
        {
            //instanciando o powerUp e destruindo ele depois de 3 segundos
            GameObject Pu = Instantiate(powerUp, transform.position, transform.rotation);
            Destroy(Pu, 3f);

            //dando direção para o powerUp
            Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

            //pegando o rigidbody do powerUp e dando uma velocidade pra ele
            Pu.GetComponent<Rigidbody2D>().velocity = dir;
        }
    }

}

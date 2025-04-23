using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo02Controller : InimigoPai
{

    public bool possoMover;
    private Rigidbody2D meuRB;
    [SerializeField] private float yMax;

    [SerializeField] private Transform transformTiro;

    [SerializeField] private GameObject TiroGrande;

    [SerializeField] private float velocidadeTiro = 5f;

    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
        //meuRB.velocity = new Vector2(0f, velocidade);
        //pode se utilizar dessa forma
        //meuRB.velocity = Vector2.down * velocidade;
        meuRB.velocity = Vector2.up * velocidade;/*para dar uma velocidade 
        positiva e depois multiplicar por um valor negativo*/

        esperaTiro = Random.Range(0.5f, 1.5f);
        possoMover = true;
    }

    void Update()
    {
        Atirar();
        //chcando se cheguei no meio da tela e se posso me mover
        if(transform.position.y < yMax && possoMover)
        {
            //checando se eu estou na esquerda 
            if(transform.position.x < 0f)
            {
                //movendo o inimigo para a direita
                meuRB.velocity = new Vector2(velocidade * -1, velocidade);
                //agora não vou poder me mover mais
                possoMover = false;
            }
            else
            {
                //movendo o inimigo para a esquerda
                meuRB.velocity = new Vector2(velocidade, velocidade);
                //agora não vou poder me mover mais
                possoMover = false;
            }
        }
    }

private void Atirar()
{
    bool visibilidade = GetComponentInChildren<SpriteRenderer>().isVisible;
    if(visibilidade)
    {
        var player = FindObjectOfType<PlayerController>();/*ele está encontrando
        o player, tendo como referência o script dele*/
        if(player)//ele só vai atirar se o player estiver na cena
        {
            esperaTiro-=Time.deltaTime;
            if(esperaTiro <= 0)
            {
                var tiro = Instantiate(TiroGrande, transformTiro.position, transform.rotation);
                AudioSource.PlayClipAtPoint(somTiro, Vector3.zero);
                Vector2 direcao = player.transform.position - tiro.transform.position;
                //normalizando a velocidade do tiro.todos os eixos serão números inteiros
                direcao.Normalize();
                //dando direção ao tiro
                tiro.GetComponent<Rigidbody2D>().velocity = direcao * velocidadeTiro;

                //dando o ângulo que o tiro tem que estar
                float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;/*esse código
                pega o ângulo através da direção do tiro. E depois converte o valor em graus*/
                tiro.transform.rotation = Quaternion.Euler(0f,0f,angulo + 90);/*coloca-se o 
                + 90 porque o angulo é atrasado em 90 graus*/
                esperaTiro = Random.Range(2f, 4f);
                }
            }
       
        }

    }

}

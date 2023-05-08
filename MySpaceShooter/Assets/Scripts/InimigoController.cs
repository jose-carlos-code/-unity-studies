using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : InimigoPai // é dessa forma que se coloca a herança
{

    [SerializeField] private Rigidbody2D meuRB;
    //meu tiro
    [SerializeField] private GameObject meuTiro;
    //pegando o transform  da posição do meu tiro
    [SerializeField] private Transform posicaoTiro;

    //dando velocidade ao meu tiro
    [SerializeField] private float velocidadeTiro = -5f;

    private float esperaTiro = 1f;
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
        //dando a velocidade pro inimigo
        meuRB.velocity = new Vector2(0f, velocidade);
        //deixando a espera aleatória para dar o primeiro tiro
        esperaTiro = Random.Range(0.5f, 2f); 
        
    }

   
    void Update()
    {
        Atirando();
    }

    private void Atirando()
    {
        //checando se o sprite renderer do objeto está visível

        //pegando informações dos meus "filhos"
        bool visibilidade = GetComponentInChildren<SpriteRenderer>().isVisible;

        /*só vou poder atirar se o inimigo estiver aparecendo na tela.
        ou seja, se a variável 'visibilidade' for igual a true*/
        if (visibilidade)
        {
            //vou diminuir a minha espera e se ela for menor ou igual a zero eu atiro
            esperaTiro -= Time.deltaTime;
            if (esperaTiro <= 0)
            {
                //instanciando meu tiro
                GameObject tiro = Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
                tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,velocidadeTiro);
                //reinicar o tempo
                esperaTiro = Random.Range(1.5f, 2f);
                
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private Rigidbody2D meuRb;
    //pegando o GameObject do tiro
    [SerializeField] private GameObject meuTiro;
    //pegando o GameObject do tiro2
    [SerializeField] private GameObject meuTiro2;
    //pegando a posição do meu tiro
    [SerializeField] private Transform posicaoTiro;
    //dando uma vida para o player
    [SerializeField] private int vidaPlayer = 10;
    [SerializeField] private GameObject explosao;
    [SerializeField] private float velocidadeTiro = 10f;
    [SerializeField] private float xLimite;
    [SerializeField] private float yLimite;
    [SerializeField] private int levelTiro = 1;
    [SerializeField] private int pontosPlayer = 0;
    [SerializeField] private GameObject escudo;
    private GameObject escudoAtual;
    [SerializeField] private int qtdEscudos = 3;

    [SerializeField] private Text textLife;
    [SerializeField] private Text textShield;
    [SerializeField] private Text pointsUI;
    void Start()
    {
      meuRb = GetComponent<Rigidbody2D>();

        //informando o quanto de vida que eu tenho

        textLife.text = vidaPlayer.ToString();
        textShield.text = qtdEscudos.ToString();
    }

   
    void Update()
    {
        move();
        Fire();
        criaEscudo();
    }

    public void move()
    {
       //var horizontal = Input.GetAxis("Horizontal"); -> tipagem dinâmica
       float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");
       Vector2 minhaVelociade = new Vector2(horizontal, vertical);
       minhaVelociade.Normalize();//garante a soma do horizontal com o vertical atinja no máximo 1
       meuRb.velocity = minhaVelociade * velocidade;

        //limitando minha posição na tela
        //Clamp -> checa a posição a atual e vê se não ultrapassou as posições limites
        float meuX = Mathf.Clamp(transform.position.x, -xLimite, xLimite);
        float meuY = Mathf.Clamp(transform.position.y, -yLimite, yLimite);

        transform.position = new Vector3(meuX, meuY, transform.position.z);
    }

    void Fire(){


        if (Input.GetButtonDown("Fire1"))
        {
            //GameObject tiro;

            switch (levelTiro){
            case 1:
                if (Input.GetButtonDown("Fire1"))
                {
                        criaTiro(meuTiro, posicaoTiro.position);
                }
                break;

            case 2:
                    var tiro = new Vector3(posicaoTiro.position.x - 0.39f, posicaoTiro.position.y + 0.09f, 0f);
                    //tiro da esquerda
                    criaTiro(meuTiro2, tiro);
                    //tiro da direita
                    tiro = new Vector3(posicaoTiro.position.x + 0.39f, posicaoTiro.position.y + 0.09f, 0f);
                    criaTiro(meuTiro2, tiro);
                    break;

            case 3:
                    //tiro do meio
                    criaTiro(meuTiro, posicaoTiro.position);
                    tiro = new Vector3(posicaoTiro.position.x - 0.39f, posicaoTiro.position.y + 0.09f, 0f);
                    //tiro da esquerda
                    criaTiro(meuTiro2, tiro);
                    //tiro da direita
                    tiro = new Vector3(posicaoTiro.position.x + 0.39f, posicaoTiro.position.y + 0.09f, 0f);
                    criaTiro(meuTiro2, tiro);
                    break;
            }

        }

    }
    

    private void criaTiro(GameObject meuTiro, Vector3 posicao)
    {
        //temos que dara a direção do tiro
        var tiro = Instantiate(meuTiro, posicao, transform.rotation);
        //var -> atribui valor de forma dinâmica 
        //dar velocidade e direção ao Rigidbody do tiro
        tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velocidadeTiro);
        //estou pegando o componente Rigidbody do GameObject TiroController
    }

    void criaEscudo()
    {
        if (!escudoAtual && qtdEscudos > 0)
        {
            if (Input.GetButtonDown("Shield"))
            {   //instanciando o escudo
                escudoAtual = Instantiate(escudo, transform.position, transform.rotation);
               //deminuindo a quantidade de escudos
                qtdEscudos--;
                textShield.text = qtdEscudos.ToString();
            }

        }
        if (escudoAtual)
        {
            //fazendo o escudo seguir o player
            escudoAtual.transform.position = transform.position;
            Destroy(escudoAtual, 6.2f);
        }
    }


    public void perdeVida(int dano)
    {
        vidaPlayer -= dano;
        //atualizando a vida no UI(user interface)
        textLife.text = vidaPlayer.ToString();
        if (vidaPlayer <=0)
        {
            Instantiate(explosao, transform.position, transform.rotation);
            Destroy(gameObject);

            //carregando a cena inicial do jogo quando o player morrer
            //achando o game manager
            var gameManager = FindObjectOfType<GameManagerController>();
            //rodando o método de inciar se o game manager existe
            if (gameManager)
            {
                gameManager.Inicio();
            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            //destruindo o powerUp
            Destroy(collision.gameObject);
            if(levelTiro < 3)
            {

                levelTiro++;
            }
        }
    }

    public void addPoints(int points)
    {
        this.pontosPlayer += points;
        this.pointsUI.text = pontosPlayer.ToString();
    }

}

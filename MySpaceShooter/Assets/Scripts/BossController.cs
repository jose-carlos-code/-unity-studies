using UnityEngine;
using UnityEngine.UI;

public class BossController : InimigoPai
{
    [Header("Informações Básicas")]
    private string estado = "estado1";
    [SerializeField] private Rigidbody2D meuRg;
    private bool isRight = true;
    [SerializeField] private float limiteHorizontal = 3.84f;

    [Header("Informações dos Tiros")]
    [SerializeField] private Transform posicaoTiro1;
    [SerializeField] private Transform posicaoTiro2;
    [SerializeField] private Transform posicaoTiro3;
    [SerializeField] private GameObject tiro1;
    [SerializeField] private GameObject tiro2;
    [SerializeField] private float velocidadeTiro = 2.5f;
    private float delayTiro = 1f;
    private float esperaTiro2 = 1f;
    [SerializeField] private string[] estados;
    private float esperaEstado = 10f;
    [SerializeField] private Image lifeBar;
    [SerializeField] private int vidaMaxima = 300;
    void Start()
    {
        meuRg = GetComponent<Rigidbody2D>();
        /*UMA BREVE EXPLICAÇÃO: 
         
           Se você dividir o valor de vida atual pelo valor de vida máxima, você obtem um valor entre 0 e 1;
         
         */

        //dando a minha vida inicial
        vidaInimigo = vidaMaxima;
    }

    
    void Update()
    {
        trocaEstado();
        switch (estado)
        {
            case "estado1":
                estado1();
                break;
            case "estado2":
                estado2();
                break;
            case "estado3":
                estado3();
                break;
        }

        //forçando o tipo de dado a ficar float -> type cast
        lifeBar.fillAmount = ((float)vidaInimigo / (float)vidaMaxima);
        //Converterdeno o valor do fillamount para alguma coisa entre 0 e 255 e garantindo que o valor dele seja do tipo byte
        //definindo a cor da barra de vida do boss
        lifeBar.color = new Color32(130, (byte)(lifeBar.fillAmount * 255), 59, 255);
    }

    private void estado1()
    {
        if(esperaTiro <= 0)
        {
            Tiro1();
            esperaTiro = delayTiro;
        }
        else
        {
            esperaTiro -= Time.deltaTime;
        }

        if (isRight)
        {
            Vector2 move = new Vector2(velocidade, 0f);
            meuRg.velocity = move;
            if (transform.position.x >= limiteHorizontal)
            {
                isRight = false;
            }
        }

        if (!isRight)
        {
            Vector2 move = new Vector2(-velocidade, 0f);
            meuRg.velocity = move;
            if (transform.position.x <= -limiteHorizontal)
            {
                isRight = true;
            }
        }
    }

    private void estado2()
    {
        //deixando o boss parado
        meuRg.velocity = Vector2.zero;
        if(esperaTiro <= 0)
        {
            Tiro2();
            esperaTiro = delayTiro / 2;
        }
        else
        {
            esperaTiro -= Time.deltaTime;
        }
    
    }

    private void estado3()
    {
        meuRg.velocity = Vector2.zero;
        if (esperaTiro <= 0f)
        {
            Tiro1();
            esperaTiro = delayTiro;
        }
        else
        {
            esperaTiro -= Time.deltaTime;
        }

        if(esperaTiro2 <= 0f)
        {
            Tiro2();
            esperaTiro2 = delayTiro;
        }
        else
        {
            esperaTiro2 -= Time.deltaTime;
        }
    }
    private void Tiro1()
    {
        //criando o tiro da esquerda
        GameObject tiro = Instantiate(tiro1, posicaoTiro1.position, transform.rotation);
        tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -velocidadeTiro);
        //criando tiro da direita
        tiro = Instantiate(tiro1, posicaoTiro2.position, transform.rotation);
        tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -velocidadeTiro);
    }

    private void Tiro2()
    {
        //fazendo os tiros do boss seguirem o player
        var player = FindObjectOfType<PlayerController>();/*ele está encontrando
        o player, tendo como referência o script dele*/
        if (player)//ele só vai atirar se o player estiver na cena
        {
            //criando tiro do meio
            var tiro = Instantiate(tiro2, posicaoTiro3.position, transform.rotation);
            Vector2 direcao = player.transform.position - tiro.transform.position;
            //normalizando a velocidade do tiro.todos os eixos serão números inteiros
            direcao.Normalize();
            //dando direção ao tiro
            tiro.GetComponent<Rigidbody2D>().velocity = direcao * velocidadeTiro;
            //dando o ângulo que o tiro tem que estar
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;/*esse código
            pega o ângulo através da direção do tiro. E depois converte o valor em graus*/
            tiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo + 90);/*coloca-se o 
            + 90 porque o angulo é atrasado em 90 graus*/
        }

        
    }

    private void trocaEstado()
    {
        if(esperaEstado <= 0f)
        {
            //escolhendo meu novo estado
            //escolher um valor aleatório entre 0 e a quantidade de estados
            int indiceEstado = Random.Range(0, estados.Length);
            estado = estados[indiceEstado];
            esperaEstado = 10f;
        }
        else
        {
            esperaEstado -= Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    [SerializeField] private GameObject[] inimigos;
    [SerializeField]private int pontos = 0;
    [SerializeField]private int level = 1;
    [SerializeField] private int baseLevel = 100;
    [SerializeField]private float esperaInimigo = 0f;
    [SerializeField] private float tempoEspera = 2f;
    [SerializeField] private int qtdInimigo = 0;
    void Start()
    {
        
    }

    
    void Update()
    {
        geraInimigos();
    }

    //ganhando pontos
    public void GanhandoPontos(int pontos)
    {
        this.pontos += pontos;
        if (this.pontos > this.level * this.baseLevel)
        {
            this.level++;
        }
    }
    public void DiminuiQuantidade()
    {
        this.qtdInimigo--;
    }

    //método para checar se a posição está livre

    private bool checaPosicao(Vector3 posicao, Vector3 size)
    {
        //checando se na posição tem alguém
        Collider2D hit = Physics2D.OverlapBox(posicao,size, 0f);

       /*se o hit é null, não houve colisão
        * posso criar inimigo ali
        se o hit não é null, não houve colisão
        * não posso criar inimigo ali
        */
  

        /*Quando se mexe com physics2D, o ideal é não colocar ele no update.
         mas como o método vai ser chamado em um while, nesse caso não tem
        problema.*/

        //Vector2.One = (1,1)

        if(hit == null)
        {
            return false;
            //não houve colisão
        }
        return true;
        //houve colisão
    }

    private void geraInimigos()
    {
        if(esperaInimigo > 0 && qtdInimigo <= 0 )
        {
            esperaInimigo-= Time.deltaTime;
        }

        if (esperaInimigo <= 0 && qtdInimigo <= 0 )
        {
            int quantidade = level * 2;
            int tentativas = 0;

            //controlando a quantidade de inimigos na tela
            if(quantidade > 12)
            {
                quantidade = 12;
            }

            //criando vários inimigos de uma só vez
            while (qtdInimigo < quantidade)
            {
                /*Fazendo ele sair da repetição se ele tentou muitas vezes*/
                //aumentando tentativas
                tentativas++;
                if(tentativas > 200)
                {
                    //desiste não vai dar certo
                    break;
                }
                //se ele tentou mais de 200 vezes, ele desiste

                GameObject inimigoCriado;
                //decidindo qual inimigo vai ser criado com base no level
                float chance = Random.Range(1f, level);
                if (chance > 2f)
                {
                    inimigoCriado = inimigos[1];
                }
                else
                {
                    inimigoCriado = inimigos[0];
                } 

                //definindo a posição do inimigo
                Vector3 posicao = new Vector3(Random.Range(-5.5f, 5.6f), Random.Range(5.5f, 12.8f), 0f);

                //preciso checar se a posição está livre
                //nessa posição não tem nínguem ainda
                bool colisao = checaPosicao(posicao, inimigoCriado.transform.localScale);
                //inimigoCriado.transform.localScale) -> tamanho do inimigo

                //CRIAR OS INIMIGOS SE NÃO HOUVE COLISÃO
                //se houve colisão, eu vou pular essa repetição
                if (colisao)
                {
                    continue;
                }

                //criando o inimigo
                Instantiate(inimigoCriado, posicao, transform.rotation);

                //aumentando a quantidade de inimigos
                qtdInimigo++;

                //reiniciando o tempo
                esperaInimigo = tempoEspera;
                //Testando no visual studio code
            }
        }
    }
}

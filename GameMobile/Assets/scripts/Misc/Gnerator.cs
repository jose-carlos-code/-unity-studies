using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnerator : MonoBehaviour
{
    [SerializeField] private GameObject[] collectibles;
    [SerializeField] private float timeGenerator = 4f;
    //quantidade objetos coletáveis na cena
    [SerializeField] private int quatity = 1;
    [SerializeField] private int amountNow;
    void Start()
    {
        
    }

    void Update()
    {
        GeneratorCollectibles();
    }

    public void GeneratorCollectibles()
    {
        if (timeGenerator <= 0 && amountNow <= 0)
        {
            int tentativas = 0;
            quatity *= 2;
            if(quatity > 8)
            {
                quatity = 8;
            }
            while(amountNow < quatity)
            {
                tentativas++;
                if(tentativas > 200)
                    //se tentativas de criar meu inimigo for maior que 200, eu desisto de criar.
                {
                    break;
                }

                GameObject inimigoCriado;
                Vector3 positionGenerator = new Vector3(Random.Range(-2.19f, 2.22f), 6.11f, 0f);
                float generatorCollectible = Random.Range(0, 2f);
                if (generatorCollectible <= 1f)
                {
                    inimigoCriado  = collectibles[0];
                    amountNow++;
                    //por algum motivo essas partes comentadas abaixo não estão pegando. ver isso amanhã 
                    /*bool colisao = ChecaPosicao(positionGenerator, inimigoCriado.localScale);*/
                }

                else if(generatorCollectible > 1f)
                {
                    inimigoCriado = collectibles[1];
                    amountNow++;
                   /* bool colisao = ChecaPosicao(positionGenerator, inimigoCriado.localScale);*/
                }

            }
            timeGenerator = 3f;
        }   
        else
        {
            timeGenerator -= Time.deltaTime;
        }
        
    }

    private bool ChecaPosicao(Vector3 position, Vector3 size)
    {
        Collider2D hit = Physics2D.OverlapBox(position, size, 0f);

        if (hit)
        {
            return false;
        }

        return true;
    }

    //diminuindo a quantidade de inimigos na variavel amountNow
    public void DecreaseQuantity()
    {
        this.amountNow--;
    }
}

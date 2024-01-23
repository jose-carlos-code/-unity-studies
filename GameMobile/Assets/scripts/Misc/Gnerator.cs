using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnerator : MonoBehaviour
{
    [SerializeField] private GameObject[] collectibles;
    [SerializeField] private float timeGenerator = 4f;
    //quantidade objetos colet�veis na cena
    [SerializeField] private int quatity = 1;
    [SerializeField] private int amountNow;
    public int level;
    public int baseLevel = 100;
    private int pontos;
    void Start()
    {
        
    }

    void Update()
    {
        GeneratorCollectibles();
    }

    public void AddPoints(int pontos)
    {
        this.pontos += pontos * level;

        if(this.pontos > baseLevel)
        {

            this.level++;
            baseLevel *= 2;
        }
    }

    public void GeneratorCollectibles()
    {
        if (timeGenerator <= 0 && amountNow <= 0)
        {
            int tentativas = 0;
            quatity *= level * 2;
            if (quatity > 8)
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

                GameObject inimigoCriado = null;
                float generatorCollectible = Random.Range(0, 2f);
                if (generatorCollectible <= 1f)
                {
                    inimigoCriado  = collectibles[0];

                }

                else if(generatorCollectible > 1f)
                {
                    inimigoCriado = collectibles[1];

                }
                Vector3 positionGenerator = new Vector3(Random.Range(-2.19f, 2.22f), 6.11f, 0f);
                bool colisao = ChecaPosicao(positionGenerator, inimigoCriado.transform.localScale);

                /*if (colisao)
                {
                    continue;
                }*/

                Instantiate(inimigoCriado, positionGenerator, transform.rotation);
                amountNow++;
            }
            timeGenerator = 2f;
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

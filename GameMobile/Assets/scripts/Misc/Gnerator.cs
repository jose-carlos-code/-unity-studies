using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnerator : MonoBehaviour
{
    [SerializeField] private GameObject[] collectibles;
    [SerializeField] private float timeGenerator = 4f;
    //quantidade objetos coletáveis na cena
    [SerializeField] private int amountCollectibles = 4;
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
        if (timeGenerator <= 0)
        {
            while(amountNow < amountCollectibles)
            {
                Vector3 positionGenerator = new Vector3(Random.Range(-2.19f, 2.22f), 6.11f, 0f);
                float generatorCollectible = Random.Range(0, 2f);
                if (generatorCollectible <= 1f)
                {
                    Instantiate(collectibles[0], positionGenerator, transform.rotation);
                    amountNow++;
                }

                else if(generatorCollectible > 1f)
                {
                    Instantiate(collectibles[1], positionGenerator, transform.rotation);
                    amountNow++;
                }
            }
            timeGenerator = 4f;
        }   
        else
        {
            timeGenerator -= Time.deltaTime;
        }
        
    }

    //diminuindo a quantidade de inimigos na variavel amountNow
    public void DecreaseQuantity()
    {
        this.amountNow--;
    }
}

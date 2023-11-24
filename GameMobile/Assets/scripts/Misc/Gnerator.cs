using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnerator : MonoBehaviour
{
    [SerializeField] private GameObject[] collectibles;
    [SerializeField] private float timeGenerator = 3f;
    //quantidade objetos coletáveis na cena
    [SerializeField] private int amountCollectibles = 4;
    [SerializeField] private int amountNow;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GeneratorCollectibles()
    {
        if(timeGenerator <= 0)
        {
            while(amountNow < amountCollectibles)
            {
                float generatorCollectible = Random.Range(0, 2f);
                if (generatorCollectible < 1.3f)
                {
                    Vector3 positionGenerator = new Vector3(Random.Range(-2.19f, 2.22f), 6.11f, 0f);
                    Instantiate(collectibles[0], positionGenerator, transform.rotation);
                    amountNow++;
                }
            }
            amountNow = 0;
            timeGenerator = 3f;
        }   
        else
        {
            timeGenerator -= Time.deltaTime;
        }
        

    }
}

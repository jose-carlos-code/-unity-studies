using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float limit1 = 1.48f;
    [SerializeField] private float limit2 = -2.21f;
    /*[SerializeField] private int limitEnemies = 4;*/
    [SerializeField] private float time = 2.5f;

    public int level = 1;
    [SerializeField] private float pontos = 0;
    /*[SerializeField] private int qtdEnemies = 0;*/
    void Start()
    {
        
    }

    void Update()
    {
        InstanceEnemies();
        EarnLevel();
    }

    private void InstanceEnemies()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            Vector3 positionEnemy = new Vector3(10.11f, Random.Range(limit1, limit2), 0f);
            int numEnemie = Random.Range(0, 3);
            GameObject enemieInstaced = this.enemies[numEnemie];
            Instantiate(enemieInstaced, positionEnemy, transform.rotation);
            if (level >= 4 && level < 6)
            { 
                this.time = Random.Range(2f, 2.5f);
            }
            else if(level >= 6 && level < 8)
            {
                this.time = Random.Range(1.5f, 2f);
            }
            else if(level >= 8) 
            {
                this.time = Random.Range(0.6f, 1.3f);
            }
            else
            {
            this.time = 2.5f;
            }

        }
    }

    private void EarnLevel()
    {
        this.pontos += Time.deltaTime;
        if (this.pontos > this.level * 5)
        {
            this.level++;
            this.pontos = 0;
        }
    }

  /*  public void ControlQtdEnemies(int quantity)
    {
        this.qtdEnemies -= quantity;
    }*/
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenearteEnemiesController : MonoBehaviour
{

    [SerializeField] private GameObject[] enemies;

    [SerializeField] private float spawnInterval = 3f; // Intervalo de tempo entre os spawns

    [SerializeField] private Transform[] spawnPoints; // Pontos de spawn para os inimigos

    void Start()
    {
        spawnPoints = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        GenerateEnemies();
    }

    void GenerateEnemies()
    {
        spawnInterval -= Time.deltaTime;
        if(spawnInterval <= 0)
        {
            Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemies[0], point.position, point.rotation);
            spawnInterval = 5f; // Reinicia o intervalo de tempo
        }
    }
}

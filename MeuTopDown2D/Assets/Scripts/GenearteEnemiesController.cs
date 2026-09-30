using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenearteEnemiesController : MonoBehaviour
{

    public List<WaveScriptable> waveList;

    [SerializeField] private int currentWave; // wave atual
    [SerializeField] private int left_monsters; // monstros restantes

    [SerializeField] private bool canSpawEnemies = true;

    [SerializeField] private int monsters_spawned;

    // [SerializeField] private int level = 1;
    // [SerializeField] private int baseLevel;

    // [SerializeField] private float spawnInterval = 3f; // Intervalo de tempo entre os spawns

    public float spawnCooldown = .4f;
    private float spawnCooldownCount = 1f;


    [SerializeField] private Transform spawnPoint; // Pontos de spawn para os inimigos


    public static GenearteEnemiesController Instance { get; set; }
    
    private void Awake()
    {
        left_monsters = waveList[0].n_monsters;  
        Instance = this;
        
    }
    

    void Start()
    {
        spawnPoint = GetComponentInChildren<Transform>();
        
    }

    void FixedUpdate()
    {
        if (canSpawEnemies == true)
        {
            GenerateEnemies(waveList[currentWave].monster);
        }
    }

    public void GenerateEnemies(GameObject enemie)
    {
       if(left_monsters <= 0)
        {
            if(currentWave > waveList.Count)
            {
                // Fim da primeira fase
            }
            canSpawEnemies = false;
            currentWave++;
            return;
        }
        if(monsters_spawned < waveList[currentWave].n_monsters && spawnCooldownCount < 0)
        {
            Instantiate(enemie, spawnPoint.position, Quaternion.identity);
            monsters_spawned++;
            spawnCooldownCount = spawnCooldown;

        }
        else
        {
            spawnCooldownCount -= Time.deltaTime;
            Debug.Log(spawnCooldownCount);
        }
    }

    
   
}

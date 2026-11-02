using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{ 
    public Vector3[] positionsSpawner;
    [SerializeField] private float cooldown = 2f;
    [SerializeField] private float cooldownCount = 2f;
    [SerializeField] private bool isSpawn = true;
    [SerializeField] GameObject enemie;
    void Start()
    {
        
    }


    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (isSpawn && cooldownCount > 0)
        {
            cooldownCount -= Time.deltaTime;
        }
        
        if(cooldownCount <= 0)
        {
            int pos = Random.Range(0, 3);
            Instantiate(enemie, positionsSpawner[pos], Quaternion.identity);
            cooldownCount = cooldown;
        }
    }
}

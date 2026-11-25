using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject projectTile;
    [SerializeField] private Transform positionInstanceProjectTile;
    [SerializeField] private float attackRange = 8f;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Shoot()
    {
        
    }

    private GameObject FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if(Vector2.Distance(transform.position, enemy.transform.position) <= attackRange)
            {
                return enemy;   
            }
        }
        return null;
    }
}

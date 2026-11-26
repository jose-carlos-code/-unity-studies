using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject projectTile;
    [SerializeField] private Transform positionInstanceProjectTile;
    [SerializeField] private float attackRange = 3f;
    [SerializeField] private float coolDownShoot = 1.2f;
    [SerializeField] private float coolDownCount = 0f;
    private GameObject targetEnemy;
    
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Shoot();
    }

    void Shoot()
    {
        if(targetEnemy == null || Vector2.Distance(transform.position, targetEnemy.transform.position) > attackRange)
        {
           targetEnemy = FindTarget();
        }
        else
        {
            if(coolDownCount > coolDownShoot)
            {
                GameObject project = Instantiate(projectTile, positionInstanceProjectTile.position, quaternion.identity);
                project.GetComponent<ProjetcTileTower>().target = targetEnemy.transform;
                coolDownCount = coolDownShoot;
            }
            else
            {
                coolDownCount += Time.deltaTime;
            }
        }
    }

    private GameObject FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if(Vector2.Distance(transform.position, enemy.transform.position) < attackRange)
            {
                return enemy;   
            }
        }
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public float attackDamage;
    public float attackRange;
    public float attackSpeed;
    public GameObject projectTile;
    GameObject targetEnemy;
    float attackCooldown;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Shoot();
    }

    void Shoot()
    {
        if(targetEnemy == null)
        {   
           targetEnemy =  FindTarget();
        }
        else
        {
            if(attackCooldown > attackSpeed)
        {
            GameObject projectTileInstance = Instantiate(projectTile, transform.position, Quaternion.identity);
            projectTileInstance.GetComponent<Project>().projectTileDamage = attackDamage;
            projectTileInstance.GetComponent<Project>().target_ = targetEnemy.transform;
            attackCooldown = 0f;
        }
        else
        {
            attackCooldown+= Time.deltaTime;
        }
        }
       
    }

    GameObject FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject e_ in enemies)
        {
            if (Vector2.Distance(transform.position, e_.transform.position) < attackRange)
            {
                return e_;
            }
        }
        return null;
    }
}

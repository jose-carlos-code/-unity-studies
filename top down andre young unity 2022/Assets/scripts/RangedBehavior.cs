using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBehavior : MonoBehaviour
{
    public GameObject projectile_;
    EntityStaps entityStaps;

    bool canAttack = true;
    float coolDown_;

    void Start()
    {
        entityStaps = GetComponent<EntityStaps>();
    }

    void Update()
    {
        if (canAttack)
        {
            GameObject projectile_instance = Instantiate(projectile_, transform.position, Quaternion.identity);
            projectile_instance.GetComponent<FireController>().projectileDamage = entityStaps.attack_damage; 
        }
    }
}

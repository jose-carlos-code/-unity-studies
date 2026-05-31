using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangedBehavior : MonoBehaviour
{
    public GameObject projectile_;
    EntityStaps entityStaps;

    bool canAttack = true;
    float coolDown_;
    GameObject player_object;

    void Start()
    {
        entityStaps = GetComponent<EntityStaps>();
        player_object = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (canAttack && player_object != null)
        {
            GameObject projectile_instance = Instantiate(projectile_, transform.position, Quaternion.identity);
            projectile_instance.GetComponent<FireController>().projectileDamage = entityStaps.attack_damage;

            projectile_instance.GetComponent<FireController>().projectTileLifeSpan = entityStaps.attack_life;

            Vector2 projetc_direction = player_object.transform.position - transform.position;
            projetc_direction.Normalize();

            Rigidbody2D rbProjectTile = projectile_instance.GetComponent<Rigidbody2D>();
            rbProjectTile.AddForce(projetc_direction * entityStaps.attack_range,
                ForceMode2D.Impulse);
  
          


            canAttack = false;
            coolDown_ = 0;

        }
        Cooldown();
    }

    void Cooldown()
    {
        if(coolDown_ > entityStaps.attack_speed && !canAttack)
        {
            canAttack = true;
        }
        else
        {
            coolDown_ += Time.deltaTime;
        }
    }
}

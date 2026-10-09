using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float enemy_speed;

    public float enemey_gold;

    public int enemy_max_hp;
    public float enemy_curr_hp;
    int nextPoint = 0;

    //Poison_effect
    public float poison_;
    public float poison_cooldown = 0f;
    void Start()
    {
        
    }
  

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, MapPointsManager.Instance.map_points[nextPoint].position, enemy_speed * Time.deltaTime);
        if(transform.position == MapPointsManager.Instance.map_points[nextPoint].position)
        {
            nextPoint++;
        }
    }

    void FixedUpdate()
    {
        IsPoisoned();
    }

    public void TakeDamage(float dmg)
    {
        enemy_curr_hp -= dmg;
        if(enemy_curr_hp <= 0)
        {
            WaveManager.Instance.n_monsters_left--;
            WaveManager.Instance.player_money += enemey_gold;
            WaveManager.Instance.UpdateHUD();
            Destroy(gameObject);
        }
    }

    void IsPoisoned()
    {
        if(poison_ > 0)
        {
            if(poison_cooldown > 1)
            {
                TakeDamage(poison_);
                poison_cooldown = 0;
            }       
             else
            {
                poison_cooldown += Time.deltaTime;
            }
        }
    }
}

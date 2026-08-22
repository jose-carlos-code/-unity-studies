using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float enemy_speed;

    public int enemy_max_hp;
    public float enemy_curr_hp;
    int nextPoint = 0;
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


    public void TakeDamage(float dmg)
    {
        enemy_curr_hp -= dmg;
        if(enemy_curr_hp <= 0)
        {
            WaveManager.Instance.n_monsters_left--;
            Destroy(gameObject);
        }
    }
}

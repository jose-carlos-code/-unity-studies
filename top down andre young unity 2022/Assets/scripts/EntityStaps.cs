using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStaps : MonoBehaviour
{

    public float max_hp = 10;
    public float hp = 10;
    public float speed = 5;
    public float attack_damage;
    public float attack_speed;
    public float attack_range;
    public int gold_carry = 60;
    void Start()
    {
        hp = max_hp;
    }

    void Update()
    {
       
    }

    void Death()
    {
        if(hp <= 0)
        {
            //Dá ouro pro player
            if(gameObject.tag != "Player")
            {
                InvontoryManager.instance.AddGold(gold_carry);
            }
            Destroy(gameObject);
        }
    }

    public void RemoveHp(float hp_to_remove)
    {
        hp -= hp_to_remove;
        Death();
    }
}

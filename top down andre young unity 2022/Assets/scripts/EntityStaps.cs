using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStaps : MonoBehaviour
{

    public float max_hp = 10;
    public float hp = 10;
    public float speed = 5;
    public float attack_damage;
    public float attack_speed = 0.2f;
    public float attack_life;
    public float attack_range;
    public int gold_carry = 60;

    // apenas inimgigos
    public SpawnManager spawn_manager;

    // apenas jogador
    public int level = 1;
    public int exp = 0;
    public float bonus_attack;
    public float bonus_atkspeed;


    
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
            // Dá ouro pro player
            if(gameObject.tag != "Player")
            {
                InvontoryManager.instance.AddGold(gold_carry);
                GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStaps>().AddExp(exp);
            }

            // Computa a morte do inimigo
            if(this.gameObject.tag == "Enemie")
            {
                spawn_manager.enemies_alive--;
            }

            Destroy(gameObject);
        }
    }

    public void RemoveHp(float hp_to_remove)
    {
        hp -= hp_to_remove;
        Death();
    }

    void AddExp(int exp_)
    {
        this.exp += exp_;
        if(this.exp > level * 100)
        {
            exp = 0;
            level++;
            HUD.instance.SetupLevelUp();
        }

    }
}

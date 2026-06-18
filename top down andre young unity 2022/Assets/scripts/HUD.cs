using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public EntityStaps player_stats;

    public Slider hp_bar;
    void Start()
    {
        player_stats = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStaps>();
    }

    void Update()
    {
        PlayerHp();
    }

    void PlayerHp()
    {
        hp_bar.maxValue = player_stats.max_hp;
        hp_bar.value = player_stats.hp;
    }
}

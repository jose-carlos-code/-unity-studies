using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD instance { get; private set; }

    public EntityStaps player_stats;

    public Slider hp_bar;

    public Slider exp_bar;

    public GameObject levelUpScreen;

    public Text[] stats_info;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player_stats = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStaps>();
    }

    void Update()
    {
        PlayerHud();
    }

    void PlayerHud()
    {

        // HP
        hp_bar.maxValue = player_stats.max_hp;
        hp_bar.value = player_stats.hp;

        // EXP
        exp_bar.maxValue = player_stats.level * 100;
        hp_bar.value = player_stats.exp;
    }

    public void SelectStat(string stat)
    {
        if(stat == "hp")
        {
            player_stats.max_hp += 5;
            player_stats.hp += 5;

        }   

        if(stat == "atk")
        {
            player_stats.bonus_attack += 5;
        }

        if(stat == "atkspeed")
        {
            player_stats.bonus_atkspeed += 2;
        }

        if (stat == "move")
        {
            player_stats.speed += 0.3f;
        }


        levelUpScreen.SetActive(false);
    }

    public void SetupLevelUp()
    {

        // fazendo o HUD capturar a alteração do código
        levelUpScreen.SetActive(true);
        stats_info[0].text = player_stats.max_hp.ToString();
        stats_info[1].text = player_stats.bonus_attack.ToString();
        stats_info[2].text = player_stats.bonus_atkspeed.ToString();
        // converte para inteiro caso seja um valor quebrado
        stats_info[3].text = Mathf.CeilToInt(player_stats.speed).ToString();

    }
}

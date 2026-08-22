using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements; // importa o textMeshPro

public class WaveManager : MonoBehaviour
{

    public int player_hp;
    public int player_money;

    public List<WaveScriptable> wavesList;

    public int wave_;   

    // Elementos de Ui

    public TMP_Text player_hp_text;
    public TMP_Text player_money_text;
    public TMP_Text wave_text;

    public int n_monsters_left;
    private int n_monsters_spawned;

    public GameObject game_over_screen;

    public GameObject victory_screen;
    public Transform spawn_location_monster;

    public float spawnCooldown;
    private float spawnCooldownCount;

    private bool canSpawEnemies = false;

    public GameObject nextWaveButton;

    
    public static WaveManager Instance { get; set; }


    private void Awake()
    {
        Instance = this;
        
    }


    void Start()
    {
        UpdateHUD();
    }

    void FixedUpdate()
    {
       if(canSpawEnemies == true) SpawEnemies(wavesList[wave_].monster);
    }

    void UpdateHUD()
    {
        player_hp_text.text = "HP: " + player_hp.ToString();
        player_money_text.text = "$" + player_money.ToString();
        wave_text.text = "Wave: " + wave_.ToString();
    }

    public void RemoveHp()
    {
        player_hp--;
        UpdateHUD();
        if(player_hp <= 0)
        {
            // game_over_screen.SetActive(true);
        }
    }

    public void StartWave()
    {
        nextWaveButton.SetActive(false);
        n_monsters_left = wavesList[wave_].n_monsters;
        n_monsters_spawned = 0;
        canSpawEnemies = true;
    }

    void SpawEnemies(GameObject enemie)
    {
        // END OF THE WAVE
        if(n_monsters_left <= 0)
        {
            if(wave_ > wavesList.Count)
            {
                victory_screen.SetActive(true);
            }
            canSpawEnemies = false;
            wave_++;
            UpdateHUD();
            nextWaveButton.SetActive(true);
        }
        if(n_monsters_spawned < wavesList[wave_].n_monsters && spawnCooldownCount < 0)
        {
            Instantiate(enemie, spawn_location_monster.position, Quaternion.identity);
            n_monsters_spawned++;
            spawnCooldownCount = spawnCooldown;
        }
        else
        {
            spawnCooldownCount -= Time.deltaTime;
        }
    }
}

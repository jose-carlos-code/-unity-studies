using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public PlayerController playerController;

    public Slider hpBar;

   
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        PlayerHpBar(); 
    }

    void PlayerHpBar()
    {
        hpBar.maxValue = playerController.MaxhealthPlayer;
        hpBar.value = playerController.currentHealthPlayer;
    }
}

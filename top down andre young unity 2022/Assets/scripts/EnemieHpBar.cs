using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemieHpBar : MonoBehaviour
{
    private Slider hp_slider;
    private EntityStaps entity_stats;
    void Start()
    {
        // pegagando o componente do filho direto do Canvas hp bar
        hp_slider = GetComponentInChildren<Slider>();
        // pegando o componente pai direto do canvas hp bar
        entity_stats = GetComponentInParent<EntityStaps>();
    }

    void Update()
    {
        hp_slider.maxValue = entity_stats.max_hp;
        hp_slider.value = entity_stats.hp;
    }
}

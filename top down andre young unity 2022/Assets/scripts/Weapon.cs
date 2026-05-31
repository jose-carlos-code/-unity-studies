using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon")]
public class Weapon : ScriptableObject
{
    public string weapon_name;
    public float weapon_damage;
    public float weapon_speed;
    public float weapon_life;
    public float weapon_range;
    public Sprite weapon_icon;
    public int weapon_value;

}

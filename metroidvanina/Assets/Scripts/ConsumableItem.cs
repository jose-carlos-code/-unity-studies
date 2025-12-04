using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 [CreateAssetMenu]
public class ConsumableItem : ScriptableObject
{
    public int id;
    public string itemName;
    public string description;
    public Sprite image;
    public int healthGain;
    public int manaGain;
    public string message;

}

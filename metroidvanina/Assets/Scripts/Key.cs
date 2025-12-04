using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Faz com que seja possível criar chaves no Unity Editor

[CreateAssetMenu]
public class Key : ScriptableObject
{
    public int itemID;
    public string keyName;
    public string description;
    public Sprite image;
    public string message;

}

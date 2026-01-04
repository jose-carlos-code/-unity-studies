using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory inventory;
    public List<Weapon> weapons;
    public List<Key> keys;
    public List<ConsumableItem> items;
    void Start()
    {
        
    }

    private void Awake()
    {
        if(inventory == null)
        {
            inventory = this;
        }else if(inventory != this)
        {
            Destroy(gameObject);
        }
        //não destrua meu inventário quando carregar uma nova cena
        DontDestroyOnLoad(gameObject);
    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }

    public void AddKey(Key key)
    {
        keys.Add(key);
    }

    public bool ChekKey(Key key) 
    {
        for (int i = 0; i < keys.Count; i++)
        {
            if (keys[i] == key)
            {
                return true;
            }
        }
        return false;
    }

    public void AddItem(ConsumableItem item)
    {
        items.Add(item);
    }

    public void RemoveItem(ConsumableItem item)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i] == item)
            {
                // removo o item da lista
                // removo só o primeiro item encontrado na lista referente ao item passado por parâmetro
                // pois pode haver mais de um item igual na lista, e ai eu quero remover só um
                items.RemoveAt(i);
                break;
            }
           
        }
    }
}


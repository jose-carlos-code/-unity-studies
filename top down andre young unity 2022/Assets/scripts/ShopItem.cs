using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Weapon w_;

    public Text item_name_holder;
    public Text item_value_holder;
    public Image item_icon_holder;
    public Text item_info_holder;
    public Button shop_button;
    void Start()
    {
      shop_button = this.gameObject.GetComponent<Button>(); 
    }

    void Update()
    {
        
    }

   public void Setup(Weapon w)
    {
        item_name_holder.text = w.weapon_name;
        item_value_holder.text = w.weapon_value.ToString();
        item_icon_holder.sprite = w.weapon_icon;
        item_info_holder.text = "Attack Damage " + w.weapon_damage.ToString() + "\n Attack Speed: " + w.weapon_speed
            .ToString() + "\nRange: " + w.weapon_range.ToString();

        // Garantindo que o usuário só compre uma Arma quando tiver dinheiro o suficiente
        if (InvontoryManager.instance.gold_coins < w.weapon_value)
        {
            shop_button.interactable = false;
        }
        else
        {
            shop_button.interactable = true;
        }
    }

    public void BuyWeapon()
    {
        if(InvontoryManager.instance.inventory_[4] != null)
        {
           
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                if (InvontoryManager.instance.inventory_[i] == null)
                {
                    InvontoryManager.instance.inventory_[i] = w_;
                    break;
                }
            }

            //InvontoryManager.instance.inventory_.Add(w_);
            // Gastando dinheiro do jogador
            InvontoryManager.instance.AddGold(w_.weapon_value * -1);
            RefreshShop();
            Destroy(this.gameObject);
        }
            
    }

    void RefreshShop()
    {
        GameObject[] shop_items = GameObject.FindGameObjectsWithTag("ShopItem");
        foreach (GameObject go in shop_items)
        {
            go.GetComponent<ShopItem>().Setup(go.GetComponent<ShopItem>().w_);
        }
    }

}

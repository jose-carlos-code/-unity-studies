using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class InvontoryManager : MonoBehaviour
{

    public static InvontoryManager instance { get; private set; }
    public GameObject inv_background;
    public GameObject inv_slot;


    public int active_slot;

    public List<Weapon> inventory_;
    int selected_slot = 0;

    EntityStaps player_stats;
    public int gold_coins;
    public Text gold_text;

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
        player_stats = GameObject.FindAnyObjectByType<PlayerMovement>().GetComponent<EntityStaps>();
        SelectWeapon(0);
    }

    void Update()
    {
        IventorySelection();
    }

    public void RefreshInentory()
    {

        gold_text.text = gold_coins.ToString();

        GameObject[] destroy_slots = GameObject.FindGameObjectsWithTag("Slot");
        foreach (GameObject go in destroy_slots)
        {
            Destroy(go);
        }

        int hotKey_ = 1;
        if (hotKey_ >= inventory_.Count)
        {
            Debug.LogWarning("Slot " + (hotKey_ + 1) + " vazio!");
            return;
        }
        foreach (Weapon w in inventory_)
        {
            // instancia o mesmo prefab sempre, mas com o sprite diferente
            GameObject slot_instance = Instantiate(inv_slot, inv_background.transform);
            if(w == null)
            {
                slot_instance.GetComponentInChildren<Image>().enabled = false; 
            }
            else
            {
                slot_instance.GetComponentInChildren<Image>().enabled = true;
                slot_instance.GetComponentInChildren<Image>().sprite = w.weapon_icon;
                slot_instance.GetComponentInChildren<Outline>().enabled = false;

                if (selected_slot + 1 == hotKey_) slot_instance.GetComponentInChildren<Outline>().enabled = true;
            }
                

            slot_instance.GetComponentInChildren<Text>().text = hotKey_.ToString();
            hotKey_++;

        }
    }

    void SelectWeapon(int hotKey)
    {

        active_slot = hotKey;
        Weapon selected_weapon = inventory_[hotKey];
        player_stats.attack_damage = selected_weapon.weapon_damage;
        player_stats.attack_speed = selected_weapon.weapon_speed;
        player_stats.attack_range = selected_weapon.weapon_range;
        player_stats.attack_life = selected_weapon.weapon_life;
        selected_slot = hotKey;
        RefreshInentory();
    }

    void IventorySelection()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectWeapon(2);
        }
    }
    
    public void AddGold(int g) { 
        gold_coins += g;
        RefreshInentory();
    }

    public void DiscardWeapon()
    {
        if(active_slot != 0)
        {
            inventory_[active_slot] = null;
            SelectWeapon(0);
            RefreshInentory();
        }
    }
}
 
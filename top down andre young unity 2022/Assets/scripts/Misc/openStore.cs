using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openStore : MonoBehaviour
{
    public GameObject store_object; // UI DA LOJA
    public GameObject store_warning; //TEXTO DE AVISO PARA O JOGADOR

    GameObject player_obj;
    public ShopItem shop_item_prefab;
    public GameObject shop_bg;
    private float dist;

    public List<Weapon> weapons_sold;

    void Start()
    {
        RandomItems();
        store_object.SetActive(false);
        player_obj = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Update()
    {
        if (player_obj != null)
        {
           dist  = Vector2.Distance(transform.position, player_obj.transform.position);
        }
        
        if (dist <= 3.7f)
        {
            store_warning.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                store_object.SetActive(true);
            }
        }
        else
        {
            store_warning.SetActive(false);
            store_object.SetActive(false);
        }
    }

    void RandomItems()
    {
        for(int i = 0; i < 3; i++)
        {   
            int random_number = Random.Range(0, weapons_sold.Count);
            Instantiate(shop_item_prefab, shop_bg.transform);
            shop_item_prefab.GetComponent<ShopItem>().w_ = weapons_sold[random_number];
            shop_item_prefab.GetComponent<ShopItem>().Setup(weapons_sold[random_number]);
            

        }
    }
}

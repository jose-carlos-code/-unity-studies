using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject porta_;
    public List<GameObject> spaw_points;
    public List<GameObject> Enemies;
    public int enemies_alive = 0;
    public bool dungeon_active = false;
    void Start()
    {
        
    }

    void Update()
    {
        CheckDungeonEnd();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            porta_.SetActive(true);
            SpawEnimies();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            dungeon_active = true;
        }
    }

    void SpawEnimies()
    {
        foreach (GameObject sp in spaw_points) 
        {
            int randomEnemie = Random.Range(0, 2);
            GameObject new_enemie = Instantiate(Enemies[randomEnemie], sp.transform.position, Quaternion.identity);
            new_enemie.GetComponent<EntityStaps>().spawn_manager = this;
            enemies_alive++;
        }
    }

    void CheckDungeonEnd()
    {
        if(dungeon_active && enemies_alive == 0)
        {
            // fazendo a porta desaparecer depois que o player matar todos os inimigos
            porta_.SetActive(false);
            // fazendo o usuario poder recolocar a porta e matar mais inimigos
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameController : MonoBehaviour
{
    
    public int level = 1;
    public int exp = 0;
    [SerializeField] private List<EnemieController> currentEnemies;

    [SerializeField] private GenearteEnemiesController generateEnemieScript;

    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text levelText;

    [SerializeField] private GameObject Enemie;

    void Start()
    {
        
    }


    void Update()
    {
        // if(level >= 2)
        // {
        //     GenearteEnemiesController.Instance.GenerateEnemies(Enemie);
            
        // }
    }

     public void AddExp(int exp)
    {
        this.exp += exp;
        if(this.exp > level * 100)
        {
            level++;
            levelText.text = "Level : " + level.ToString();
            this.exp = 0 ;
        }
    }

}

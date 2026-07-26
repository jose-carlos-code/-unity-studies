using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public int level = 1;
    public int exp = 0;

    GenearteEnemiesController generateEnemieScript;

    void Start()
    {
        
    }


    void Update()
    {
          if(level >= 2)
        {
            generateEnemieScript.GenerateEnemies();
            
        }
    }

     public void AddExp(int exp)
    {
        this.exp += exp;
        if(this.exp > level * 100)
        {
            level++;
            this.exp = 0 ;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D myRb;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        myRb.velocity = new Vector2(-speed, 0f);

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Destroyer")
        {
            Destroy(gameObject);
          /*  var decreaseAmount = FindObjectOfType<GeneratorEnemies>();
            decreaseAmount.ControlQtdEnemies(1);*/
        }
    }

    //AUMENTANDO A VELOCIDADE DOS INIMGOS CONFORME O LEVEL AUMENTA
    private void ControlSpeed()
    {
        var generator = FindObjectOfType<GeneratorEnemies>();
        int level = generator.level;
        if(level >= 4 && level < 6)
        {
            this.speed = Random.Range(6f, 7.5f);
        }

        if(level >=6 && level < 8)
        {
            this.speed = Random.Range(8f, 9.5f);
        }

        if(level >= 8)
        {
            this.speed = Random.Range(9.5f, 11f);
        }
    }

    private void Awake()
    {
        ControlSpeed();
    }
}

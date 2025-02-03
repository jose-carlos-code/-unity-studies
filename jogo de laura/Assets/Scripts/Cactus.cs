using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameController gameController;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // encontrando o gameController da cena atual
        gameController = FindObjectOfType<GameController>();
        int speedLevel = gameController.returnLevel();

        rb.velocity = Vector2.left * (speed + speedLevel);

        Debug.Log("Velocidade do cactus " + speedLevel);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }

}

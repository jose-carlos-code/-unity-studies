using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Renderer background;
    private float xOffset = 0f;
    public float speed = 0.5f;
    void Start()
    {
        background = GetComponent<Renderer>();
    }

    void Update()
    {
        /*var level = FindObjectOfType<GeneratorEnemies>();
        if (level.level >= 5)
        {
            speed = 0.65f;
        }*/

        //dimunuindo o valor do x do offset
        xOffset += Time.deltaTime * speed;
        //fazendo o fundo se mover
        background.material.mainTextureOffset = new Vector2(xOffset, 0f);

    }

    /*public void increaseSpeed(float newSpeed)
    {
        if(this.speed >= 1f)
        {
            speed = 1f;
        }
        else
        {
            this.speed = newSpeed;
            Debug.Log("velocidade do background: " + this.speed);
        }
    }*/
}

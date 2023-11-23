using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosaoController : MonoBehaviour
{

    //pegando o AudioClip
    [SerializeField] private AudioClip meuSom;  
    void Start()
    {
        if (transform.position.y <= 4.30f && transform.position.y >= -4.84f)
        {
            //Qual é o som e a posição. A posição é a da camera
            AudioSource.PlayClipAtPoint(meuSom, Vector3.zero);
        }


    }
    
    void Update()
    {
        
    }

    public void morrendo()
    {

        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMagnect : MonoBehaviour
{
    public GameObject magnect_position; 
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
           
            Camera.main.GetComponent<CameraBehavior>().target_object = magnect_position;
        
        }
    }

     private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            Camera.main.GetComponent<CameraBehavior>().target_object = collision.gameObject;
            
        }
    }


}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    public GameObject target_object;

    public GameObject player_object;
    void Start()
    {
        player_object = GameObject.FindGameObjectWithTag("Player");
        target_object = player_object;
    }

    void FixedUpdate()
    {
        if (target_object != null) 
        {
            // fazendo a câmera seguir o jogador com um delay
            transform.position = Vector3.Lerp(this.transform.position, 
            new Vector3(target_object.transform.position.x, target_object.transform.position.y, -10),1 * Time.fixedDeltaTime);
            
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject target_object;
    Vector3 targetTransform;

    public GameObject player_object;

    [SerializeField] private List<Transform> boundaries;
    void Start()
    {
        player_object = GameObject.FindGameObjectWithTag("Player");
        target_object = player_object;
    }

    void FixedUpdate()
    {   
        if (target_object != null) 
        {
            if ((player_object.transform.position.x < boundaries[0].transform.position.x ||
            player_object.transform.position.x > boundaries[1].transform.position.x) && (player_object.transform.position.y < boundaries[2].transform.position.y ||
            player_object.transform.position.y > boundaries[3].transform.position.y))
            {
                targetTransform = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
            }

            else if(player_object.transform.position.x < boundaries[0].transform.position.x ||
            player_object.transform.position.x > boundaries[1].transform.position.x)
            {
            targetTransform = new Vector3(gameObject.transform.position.x, target_object.transform.position.y, -10);
            }
            else if(player_object.transform.position.y < boundaries[2].transform.position.y ||
            player_object.transform.position.y > boundaries[3].transform.position.y)
            {
                targetTransform = new Vector3(target_object.transform.position.x, gameObject.transform.position.y, -10);
            }

            else
            {
                targetTransform = new Vector3(target_object.transform.position.x, target_object.transform.position.y, -10);
            }
            // fazendo a camera seguir o jogador com um delay
            transform.position = Vector3.Lerp(this.transform.position, 
            new Vector3(targetTransform.x, targetTransform.y, -10),1 * Time.fixedDeltaTime);
        }
    }
}

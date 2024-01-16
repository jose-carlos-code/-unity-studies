using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var player = FindObjectOfType<PlayerController>();
        if(player.transform.position.y > -5.9f)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}

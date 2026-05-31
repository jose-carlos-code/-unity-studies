using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject fire1;
    //[SerializeField] private float baseSpeed = 5f;
 
    public Transform postionFire1;
    public EntityStaps entity_stats;

    void Start()
    {
        entity_stats = gameObject.GetComponent<EntityStaps>();
    }
    void Update()
    {
        Fire();
    }

    private void FixedUpdate()
    {
        MoveWASD();
        if(Input.GetKeyDown(KeyCode.G))
        {
            InvontoryManager.instance.DiscardWeapon();
        }
    }

    void MoveWASD()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(horizontal, vertical, 0f).normalized;
        transform.position += move * entity_stats.speed * Time.fixedDeltaTime;
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject fireInstance = Instantiate(fire1, postionFire1.position, Quaternion.identity);
            fireInstance.GetComponent<FireController>().speedFire = entity_stats.attack_range;
            fireInstance.GetComponent<FireController>().projectTileLifeSpan = entity_stats.attack_life;

            fireInstance.GetComponent<FireController>().isPlayerProjectile = true; // ← marca que foi o player que atirou
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class GunController : MonoBehaviour

{
    [SerializeField] private GameObject fireHeart;
    [SerializeField] private Transform fireHeartPos;
    [SerializeField] private float speedShot = 5f;
    void Start()
    {
        
    }

    void Update()

    {
        RotationGun();
        Fire();
        RotationYGun();
    }

    public void RotationGun()
    {
        Vector2 direction = MouseDirection();
        // calcula o ângulo em graus
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        /*transform.up = direction;*/ 
        
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseDirection = MouseDirection();
            GameObject shot = Instantiate(fireHeart, fireHeartPos.position, transform.rotation);
            shot.GetComponent<Rigidbody2D>().velocity = mouseDirection * speedShot;
        }
    }

    public Vector2 MouseDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        direction.Normalize();
        return direction;
    }

    private void RotationYGun()
    {
        if (transform.rotation.z < -90f || transform.rotation.z > 100f)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }
}

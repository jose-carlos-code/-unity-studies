using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{

    public float moveSpeedSlime = 3.5f;
    private Vector2 slimeDirection;
    private Rigidbody2D slimeRB2D;

    private SpriteRenderer spriteRenderer;

    public DetectionController detectionArea;
    void Start()
    {
        slimeRB2D = GetComponent<Rigidbody2D>();  
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        slimeDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        if (detectionArea.detectedsObjs.Count > 0)
        {
            slimeDirection = (detectionArea.detectedsObjs[0].transform.position - transform.position).normalized;
            slimeRB2D.MovePosition(slimeRB2D.position + slimeDirection * moveSpeedSlime * Time.fixedDeltaTime);

            if (slimeDirection.x > 0)
            {
                //vou continuar olhando para o lado direito
                spriteRenderer.flipX = false;

            }
            else if (slimeDirection.x < 0)
            {
                spriteRenderer.flipX = true;
            }
        }

    }
}

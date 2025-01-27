using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    [SerializeField] private float speed = 0.22f;
    private Renderer background;
    private float xOffset = 0f;
    private Vector2 texturaOffset;

    void Start()
    {
        background = GetComponent<Renderer>();
    }

   
    void Update()
    {
        xOffset += Time.deltaTime * speed;

        texturaOffset.x = xOffset;
        background.material.mainTextureOffset = texturaOffset;
    }

}

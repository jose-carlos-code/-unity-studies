using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    void Start()
    {
        // pegando o spriterenderer do objeto filho do background
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        Vector3 scaleTemp = GetComponentInChildren<Transform>().transform.localScale;
        float width = sprite.bounds.size.x; // valor do tamanho do x da sprite
        float height = sprite.bounds.size.y; // valor do tamanho do y da sprite
        // pegando o valor ortográfico da camêra.
        // quando o valor ortográfico aumenta, a visualização diminui. e vice e versa
        float heightCamera = Camera.main.orthographicSize * 2.0f;

        float widthWorld = heightCamera / Screen.height * Screen.width;

        scaleTemp.x = widthWorld / width;
        scaleTemp.y = heightCamera / height;
        transform.localScale = scaleTemp;
    }
}

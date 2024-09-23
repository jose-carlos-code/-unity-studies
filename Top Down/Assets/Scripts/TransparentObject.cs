using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentObject : MonoBehaviour
{

    [Range(0, 1)] // limita o valor que pode ser atribuído a transparenceValue
    [SerializeField] private float transparenceValue = 0.6f;
    [SerializeField] private float transparenceFadeTime = .4f;

   

    private SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(FadeTree(sprite, transparenceFadeTime, sprite.color.a, transparenceValue));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(FadeTree(sprite, transparenceFadeTime, sprite.color.a, 1));
        }
    }

    //qual o sprite que vai ter transparênicia, duração da transparencia, valor inicial, destino da transparência
    private IEnumerator FadeTree(SpriteRenderer spriteTransparency, float fadeTime, float startValue, float targetTransparency)
    {
        float timeElapsed = 0; // começa a contar do zero 
        while(timeElapsed < fadeTime)
        {
            timeElapsed += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, targetTransparency, timeElapsed / fadeTime);
            spriteTransparency.color = new Color(spriteTransparency.color.r, spriteTransparency.color.g,
            spriteTransparency.color.b, newAlpha);
            yield return null;
        }
    }

  
}

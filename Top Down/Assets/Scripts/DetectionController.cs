using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionController : MonoBehaviour
{
    public string tagTargetDetection = "Player";

    public List<Collider2D> detectedsObjs = new List<Collider2D> ();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagTargetDetection)
        {
            detectedsObjs.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagTargetDetection)
        {
            detectedsObjs.Remove(collision);
        }
    }
}

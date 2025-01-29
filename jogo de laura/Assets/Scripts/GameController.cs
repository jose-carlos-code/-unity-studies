using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject cactus;
    [SerializeField] private float timer = 1f;
    [SerializeField] private Vector3 position;
    [SerializeField] private float points = 0f;

    [SerializeField] private Text textPoints;

    void Start()
    {

    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            Instantiate(cactus, position, Quaternion.identity);
            timer = 1f;

        }

        AddPoints();
    }

    void AddPoints()
    {
        points += Time.deltaTime;
        textPoints.text = ((float)Math.Round(points)).ToString();
    }
}

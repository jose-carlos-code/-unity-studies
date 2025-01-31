using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject cactus;
    [SerializeField] private float timer = 4f;
    [SerializeField] private Vector3 position;
    [SerializeField] private float points = 0f;
    [SerializeField] private int baseLevel = 30;
    [SerializeField] private float level = 1;
    [SerializeField] private Text textPoints;

    void Start()
    {

    }

    void Update()
    {
        AddPoints();
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            Instantiate(cactus, position, Quaternion.identity);
            timer = 1f;

        } 
    }

    void AddPoints()
    {
        this.points += Time.deltaTime * this.level;
        this.level += this.points;
        if (this.points > this.baseLevel)
        {
            this.level++;
            this.baseLevel *= 2;
        }
        textPoints.text = ((float)Math.Round(this.level)).ToString();
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject cactus;
    [SerializeField] private float timer = 4f;
    [SerializeField] private Vector3 position;
    [SerializeField] private float points = 0f;
    [SerializeField] private float nextLevel = 10f;

    [SerializeField] private Text textPoints;
    [SerializeField] private Text textLevel;
    [SerializeField] private float positionXInstance;

    private float timerMin = 1f;
    private float timerMax = 4f;
    private int level = 1;

    void Start()
    {

    }

    void Update()
    {
        AddPoints();
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            positionXInstance = UnityEngine.Random.Range(3.99f, 5.5f);
            position = new Vector3(positionXInstance, -2.26f, 0f);
            Instantiate(cactus, position, Quaternion.identity);
            timer = UnityEngine.Random.Range(timerMin, timerMax);


        } 
    }

    void AddPoints()
    {
        this.points += Time.deltaTime;
        if (this.points > this.nextLevel)
        {
            this.level++;
            this.nextLevel *= 2;
        }
        textPoints.text = ((int)Math.Round(this.points)).ToString();
        textLevel.text = this.level.ToString();
    }

    public int returnLevel()
    {
        return this.level;
    }
}

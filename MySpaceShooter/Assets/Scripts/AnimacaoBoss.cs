using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoBoss : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void criaBoss()
    {
        Instantiate(boss, transform.position, transform.rotation);
    }
}

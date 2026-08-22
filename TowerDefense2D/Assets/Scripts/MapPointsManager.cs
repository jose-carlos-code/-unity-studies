using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPointsManager : MonoBehaviour
{
    
    public List<Transform> map_points;
 
    public static MapPointsManager Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }


    public void Metodo()
    {
        //Faz coisas
    }


    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public GameObject returnButton;

    public GameObject buildPanel;

    public GameObject buildUI;


    public static BuildManager Instance { get; set; }


    private void Awake()
    {
        Instance = this;
        
    }



    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OpenBuildPanel()
    {
        buildPanel.SetActive(true);
    }

    public void CloseBuildPanel()
    {
        buildPanel.SetActive(false);
    }

    public void SelectTower(GameObject towerPrefab)
    {
        buildUI.SetActive(false);
        GameObject selectdTower = Instantiate(towerPrefab, new Vector3(0,0,0), quaternion.identity);
    }
}

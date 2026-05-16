using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private bool pauseMenu = false;

    public GameObject pausePanel;
    public Transform cursor;
    public GameObject[] menuOptions;
    //private bool itemListActive = false;
    public Text description;

    public GameObject optionPanel;
    public GameObject itemList;
    public GameObject itemLisPrefab;
    public Inventory inventory;
    public RectTransform content;

    public List<ItemList> items;


    public int cursorIndex = 0;

    private void Awake()
    {   
        pausePanel.SetActive(false);
    }

    void Start()
    {
        inventory = Inventory.inventory;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu = !pauseMenu;
            cursorIndex = 0;
            //itemListActive = false;
            itemList.SetActive(false);  
            optionPanel.SetActive(true);
            if (pauseMenu)
            {
                pausePanel.SetActive(true);
            }
            else
            {
                pausePanel.SetActive(false);
            }
        }

        if (pauseMenu)
        {
            if(cursorIndex > menuOptions.Length - 1)
            {
                cursorIndex = menuOptions.Length - 1;
            }
            if(cursorIndex < 0)
            {
                cursorIndex = 0;
            }  
            Vector3 cursorPosition = menuOptions[cursorIndex].transform.position;
            cursor.position = new Vector3(cursorPosition.x - 100, cursorPosition.y, cursorPosition.z);
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                cursorIndex++;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                cursorIndex--;
            }

            if (Input.GetButtonDown("Submit"))
            {
                optionPanel.SetActive(false);
                itemList.SetActive(true);
                RefreshItemList();
                UpadteItemsList(cursorIndex);
            }
        }
    }

    void RefreshItemList()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Destroy(items[i].gameObject);
        }
        items.Clear();
    }

    void UpadteItemsList(int option)
    {
        if(option == 0)
        {
            for (int i = 0; i < inventory.weapons.Count; i++)
            {
                GameObject tempItem = Instantiate(itemLisPrefab, content.transform);
                tempItem.GetComponent<ItemList>().SetUpWeapon(inventory.weapons[i]);
                items.Add(tempItem.GetComponent<ItemList>());
            }
        }
    }
}

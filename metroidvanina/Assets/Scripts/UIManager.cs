using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private bool pauseMenu = false;

    public GameObject pausePanel;
    public Transform cursor;
    public GameObject[] menuOptions;

    public int cursorIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu = !pauseMenu;
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
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            menu.SetActive(true);
            Look.cursorLock = false;
        }
    }

    //public void MenuInGame(GameObject Menu)
    //{
    //    Menu.SetActive(true);
    //}

    public void ContinueEnter(GameObject Continue)
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
        Look.cursorLock = true;
    }
}

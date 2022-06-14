using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameMenu : MonoBehaviour
{
    MusicManager MM;
    AudioManager AM;
    public Slider mV;
    public Slider sV;

    private void Start()
    {
        MM = FindObjectOfType<MusicManager>();
        AM = FindObjectOfType<AudioManager>();
        mV.value = MM.musics[1].source.volume;
        sV.value = AM.sounds[1].source.volume;
    }

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

    public void ContinueEnter()
    {
        AM.Play("Click");
        Time.timeScale = 1f;
        menu.SetActive(false);
        Look.cursorLock = true;
    }

    public void MenuON(GameObject MenuON)
    {
        AM.Play("Click");
        MenuON.SetActive(true);
    }

    public void MenuOFF(GameObject menuOff)
    {
        menuOff.SetActive(false);
    }

    public void ExitGame()
    {
        AM.Play("Click");
        Time.timeScale = 1f;
        FindObjectOfType<MusicManager>().Stop("Game");
        SceneManager.LoadScene(0);
    }

    public void MusicVolume()
    {
        MM.Changed(mV);
    }

    public void SoundsVolume()
    {
        AM.Changed(sV);
    }

}

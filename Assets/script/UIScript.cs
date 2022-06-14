using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    MusicManager MM;
    AudioManager AM;

    private void Start()
    {
        MM = FindObjectOfType<MusicManager>();
        AM = FindObjectOfType<AudioManager>();
        MM.Play("Menu");
    }

    // Start is called before the first frame update
    public void menuStart()
    {

        AM.Play("Click");
        SceneManager.LoadScene(1);
        FindObjectOfType<MusicManager>().Stop("Menu");
    }

    // Update is called once per frame
    public void menuExit()
    {
        AM.Play("Click");
        Application.Quit();
    }

    public void menuOFF(GameObject menuCanvas)
    {
       
        menuCanvas.SetActive(false);
        //settingsCanvas.SetActive(true);
    }
    public void menuSettings(GameObject settingsCanvas)
    {
        // menuCanvas.SetActive(false);
        AM.Play("Click");
        settingsCanvas.SetActive(true);
    }
}

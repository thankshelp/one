using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<MusicManager>().Play("Menu");
    }

    // Start is called before the first frame update
    public void menuStart()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<MusicManager>().Stop("Menu");
    }

    // Update is called once per frame
    public void menuExit()
    {
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
        settingsCanvas.SetActive(true);
    }
}

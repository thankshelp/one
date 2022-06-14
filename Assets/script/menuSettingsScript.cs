using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class menuSettingsScript : MonoBehaviour
{
    AudioManager AM;
    public Slider Sens_Slider;
    public Slider Sounds_Slider;
    public Slider Music_Slider;

   
    private void Start()
    {

        AM = FindObjectOfType<AudioManager>();

        
       Sens_Slider.value = FindObjectOfType<MusicManager>().s;
        Sounds_Slider.value = AM.sounds[1].source.volume;
        Music_Slider.value = FindObjectOfType<MusicManager>().musics[1].source.volume;
    }
    // Start is called before the first frame update
    public void menuON(GameObject menuCanvas)
    {
        AM.Play("Click");
        menuCanvas.SetActive(true);
        //settingsCanvas.SetActive(true);
    }
    public void menuSettings(GameObject settingsCanvas)
    {
        // menuCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
    }
}

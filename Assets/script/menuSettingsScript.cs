using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class menuSettingsScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void menuON(GameObject menuCanvas)
    {
        menuCanvas.SetActive(true);
        //settingsCanvas.SetActive(true);
    }
    public void menuSettings(GameObject settingsCanvas)
    {
        // menuCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
    }
}

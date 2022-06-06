using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadingScript : MonoBehaviour
{
    public Slider progressBar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevel());
    }

   private IEnumerator LoadLevel()
    {
        AsyncOperation asyncload = SceneManager.LoadSceneAsync(2);

        while (!asyncload.isDone)
        {
            progressBar.value = asyncload.progress;
            yield return null;
        }
    }
}

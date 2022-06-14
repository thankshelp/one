using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static float PlayerHealth;
    public static bool GameOver;
    public Slider PlayerHealthSlider;


    public GameObject DeathScrene;
    public GameObject GameScrene;
    void Start()
    {
        PlayerHealth = 100;
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHealthSlider.value = PlayerHealth/100;

        if (GameOver)
        {
            Time.timeScale = 0f;
            DeathScrene.SetActive(true);
            GameScrene.SetActive(false);
            Look.cursorLock = false;
        }
    }

    public static void TakeDamage(float damage)
    {
        PlayerHealth -= damage;

        if(PlayerHealth <= 0)
        {
            GameOver = true;
        }
    }
}

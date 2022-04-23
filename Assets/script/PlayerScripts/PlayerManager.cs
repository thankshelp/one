using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static int PlayerHealth;
    public static bool GameOver;
    public TextMeshProUGUI PlayerHealthText;

    void Start()
    {
        PlayerHealth = 100;
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHealthText.text = "" + PlayerHealth;

        if (GameOver)
        {
            SceneManager.LoadScene("rooms");
        }
    }

    public static void TakeDamage(int damage)
    {
        PlayerHealth -= damage;

        if(PlayerHealth <= 0)
        {
            GameOver = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    GameObject Slime;

    void Start()
    {
        Slime = GameObject.FindGameObjectWithTag("Slime");
    }

    private void OnCollisionEnter(Collision collision)
    {
         PlayerManager.TakeDamage(Slime.GetComponent<SlimeScript>().SlimeDamage);

    }
}

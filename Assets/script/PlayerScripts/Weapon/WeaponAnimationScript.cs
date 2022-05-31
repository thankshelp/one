using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WeaponAnimationScript : MonoBehaviour
{
    
    Animator anim;
    public GameObject player;

    public int curAmmo, baseAmmo;

    public TextMeshProUGUI ammo;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //anim.enabled = false;
        //ammo.text = curAmmo + "/" + baseAmmo;
    }

    // Update is called once per frame
    void LateUpdate()
    { 
        if (player.GetComponent<playerMove>().movement != new Vector3(0.0f, 0.0f, 0.0f))
        {
            anim.SetInteger("State", 1);
            //Debug.Log(anim.GetInteger("State"));

            if (player.GetComponent<playerMove>().sprint)
            {
                anim.SetInteger("State", 2);
            }
            else if (player.GetComponent<playerMove>().sprint == false)
            {
                anim.SetInteger("State", 1);
            }
        }
        else if (player.GetComponent<playerMove>().movement == new Vector3(0.0f, 0.0f, 0.0f))
        {
            anim.SetInteger("State", 0);
        }


        if (player.GetComponent<playerMove>().jump)
        {
            anim.SetInteger("State", 3);
        }

        if (Input.GetButtonDown("Fire1") && curAmmo >= 0)
        {
            if (curAmmo == 0)
            {
                anim.SetInteger("State", 5);
            }
            else
            {
                anim.SetInteger("State", 4);
            }
            
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.R) && curAmmo < baseAmmo)
        {
            anim.SetInteger("State", 5);
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            anim.SetInteger("State", 0);
        }
       // }
    }
}

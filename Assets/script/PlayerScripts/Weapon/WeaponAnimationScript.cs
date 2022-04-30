using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationScript : MonoBehaviour
{
    
    Animator anim;
    public GameObject player;
    PistolScript pistol;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pistol = GetComponent<PistolScript>();
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

        if (Input.GetButtonDown("Fire1")  && pistol.currentAmmo >= 0)
        {
            // if(CanAttack)
            // {
           

            if (pistol.currentAmmo == 0)
            {
                anim.SetInteger("State", 5);
            }
            else
            {
                anim.SetInteger("State", 4);
            }
            // CanAttack = false;
            // StartCoroutine(ResetAttackCD());
            //}

        }
        else if (Input.GetButtonUp("Fire1"))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.R) && pistol.currentAmmo < pistol.pistol.BaseAmmo)
        {
            anim.SetInteger("State", 5);
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            anim.SetInteger("State", 0);
        }

    }
}

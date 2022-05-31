using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int weaponSwitch = 0;
    public int currentWeapon;
    Animator anim;
    //public GameObject Pistol;
    //TakeWeaponScript Count;

    void Start()
    {
        anim = GetComponent<Animator>();
        //Count = GetComponent<TakeWeaponScript>();
        SelectWeapon();
        anim.SetBool("isDrop", false);
    }

    // Update is called once per frame
    void Update()
    {
        //weaponCount = GetComponentInChildren<TakeWeaponScript>().WeaponCount;

        //weaponCount = Count.WeaponCount;
       // Debug.Log(weaponCount);

        currentWeapon = weaponSwitch;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (transform.childCount != 1)
            {
                if (weaponSwitch >= transform.childCount - 1)
                    weaponSwitch = 0;
                else
                    weaponSwitch++;

            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (transform.childCount != 1)
            {
                if (weaponSwitch <= 0)
                    weaponSwitch = transform.childCount - 1;
                else
                    weaponSwitch--;

            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSwitch = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (transform.childCount != 1)
            {
               
                weaponSwitch = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (transform.childCount == 3)
            {
                anim.SetBool("isDrop", true);
                weaponSwitch = 2;
            }
        }

        //Debug.Log("current" + currentWeapon);
        //Debug.Log("switch" + weaponSwitch);

        if (currentWeapon != weaponSwitch)
        {
            
            SelectWeapon();
            anim.SetBool("isDrop", false);
        }
    }

    public void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == weaponSwitch)
            {
                
                weapon.gameObject.SetActive(true);
                weapon.gameObject.GetComponent<GenericGun>().isTaken = true;
               
            }
            else
            {
                
                weapon.gameObject.SetActive(false);
                weapon.gameObject.GetComponent<GenericGun>().isTaken = false;
            }
            i++;
        }

        
    }
}
